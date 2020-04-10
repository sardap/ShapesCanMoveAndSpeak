using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibary;

namespace Game.src
{
	/// <summary>
	/// Purpose: Hold all info for the world this includes a factory, List of world objects
	/// It updates each world objects and spawns new objects created in the factory
	/// </summary>
	public class World : GameObjectHolder, IHaveUpdate
	{
		private readonly List<GameObject> _gameObjects = new List<GameObject>();
		private Factory _factory;
		private delegate Point2D Postion();
		private Postion _spawnPostion;
		//Next Spawn Time
		private long _spawnTime;

		public World(Factory factory, string backgroundMusicFileName)
		{
			_factory = factory ?? throw new NullReferenceException();

			ResetSpawnTime();
			SetUpWorldObjects();
		}

		public override List<GameObject> GameObjects
		{
			get
			{
				return _gameObjects.OfType<GameObject>().ToList();
			}
		}

		public void Add(GameObject toAdd)
		{
			if(toAdd != null)
			{
				_gameObjects.Add(toAdd);
			}
		}

		public void Update(long deltaTime)
		{
			DeleteTagged();
			SpawnBelivers(deltaTime);
			UpdateWorldObjects(deltaTime);
		}

		private void SetUpWorldObjects()
		{
			// Amount of objects differs between Screen only and not
			if (Settings.SCREENONLY)
			{
				_spawnPostion = new Postion(Utils.RandomScreenPoint);
				Pouplate(0, 0, 0, 10, 1, _spawnPostion);
			}
			else
			{
				_spawnPostion = new Postion(Utils.RandomWorldPoint);
				Pouplate(10, 10, 10, 10, 20, _spawnPostion);
			}
		}

		// Reason for not using an array is for clarity 
		private void Pouplate
		(
			int NumberOfCircles,
			int NumberOfTriangles,
			int NumberOfHexagons,
			int NumberOfSquares,
			int NumberOfMines,
			Postion PostionType
		)
		{
			for (int i = 0; i < NumberOfCircles; i++)
			{
				Add(_factory.CreateCircle(PostionType()));
			}

			for (int i = 0; i < NumberOfTriangles; i++)
			{
				Add(_factory.CreateTriangle(PostionType()));
			}

			for (int i = 0; i < NumberOfHexagons; i++)
			{
				Add(_factory.CreateHexagon(PostionType()));
			}

			for(int i = 0; i < NumberOfSquares; i++)
			{
				Add(_factory.CreateBeliver(new Rectangle(PostionType(), 0)));
			}

			for (int i = 0; i < NumberOfMines; i++)
			{
				Add(_factory.CreateMine(PostionType()));
			}
		}

		private void DeleteTagged()
		{
			foreach(Component i in GetComponents<DeleteComponet>().FindAll(i => i.Delete))
			{
				_gameObjects.Remove(i.Holder as GameObject);
			}
		}

		private void SpawnBelivers(long deltaTime)
		{
			_spawnTime = _spawnTime - deltaTime;

			List<Shape> _shapes = new List<Shape> { new Circle(), new Rectangle(), new Hexagon(), new Triangle() };


			if (_spawnTime <= 0 && _gameObjects.Count < Settings.MAX_OBJECTS)
			{
				int numberOfNewBelivers = Utils.Random(0, 10);

				for (int i = 0; i < numberOfNewBelivers; i++)
				{
					Shape shape = _shapes.RandomElement();
					shape.Center = _spawnPostion();

					Add(_factory.CreateBeliver(shape));
				}


				ResetSpawnTime();
			}
		}

		private void ResetSpawnTime()
		{
			_spawnTime = Settings.SPAWN_INTERVAL;
		}

		private void UpdateWorldObjects(long deltaTime)
		{
			foreach (GameObject i in _gameObjects)
			{
				i.Update(deltaTime);
			}
		}
	}
}
