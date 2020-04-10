using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SharedLibary;

namespace Game.src
{
	/// <summary>
	/// Purpose: Used to create World Objects / UI elements
	/// </summary>
	public class Factory
	{
		private Dictionary<Type, BeliverFactoryData> _believerData = new Dictionary<Type, BeliverFactoryData>();
		private Random _rnd = new Random();

		public Factory()
		{
			// belviers have different names depending on the holder type
			_believerData.Add(typeof(Circle), new BeliverFactoryData { Names = IniliseBeliverNames(":CIRCLES:"),  FileNameBase = "Normal"});
			_believerData.Add(typeof(Triangle), new BeliverFactoryData { Names = IniliseBeliverNames(":TRIANGLES:"), FileNameBase = "Triangle" });
			_believerData.Add(typeof(Hexagon), new BeliverFactoryData { Names = IniliseBeliverNames(":HEXAGONS:"), FileNameBase = "Hex" });
			_believerData.Add(typeof(Rectangle), new BeliverFactoryData { Names = IniliseBeliverNames(":SQAURES:"), FileNameBase = "Sqaure" });
		}

		public GameObject CreateBeliver(Shape shape)
		{
			GameObject newBeleiver = new GameObject();

			newBeleiver.Add(new InventoryComponent(shape.GetType().ToString(), newBeleiver));
			newBeleiver.Add(GetRandomBeleif(GetRandomShapeName(shape.GetType()), newBeleiver));
			newBeleiver.Add(new MoveComponet(Settings.BELIVER_SPEED_MIN + _rnd.NextDouble(), shape, newBeleiver));
			newBeleiver.Add(new BelieverGraphicalComponent(shape, newBeleiver));
			newBeleiver.Add(new BeliverCollisionComponent(newBeleiver));
			newBeleiver.Add(new SelectComponent(newBeleiver));
			newBeleiver.Add(new BeleiverDeleteComponet(newBeleiver));
			newBeleiver.Add(new SoundComponet(newBeleiver));
			AddSoundsToSoundComponet(newBeleiver.GetComponent<SoundComponet>(), SoundType.Select, GetBeleiverSoundFileName(Settings.Instance.BelieverSelectSoundFileName, shape.GetType()));
			AddSoundsToSoundComponet(newBeleiver.GetComponent<SoundComponet>(), SoundType.Move, Settings.Instance.BeliverMoveSoundFileName);
			AddSoundsToSoundComponet(newBeleiver.GetComponent<SoundComponet>(), SoundType.Delete, Settings.Instance.BeliverDeathSoundFileName);

			return newBeleiver;
		}

		public GameObject CreateTriangle(Point2D startLocaion)
		{
			return CreateBeliver(new Triangle(startLocaion));
		}

		public GameObject CreateCircle(Point2D startLocaion)
		{
			return CreateBeliver(new Circle(startLocaion, 0));
		}

		public GameObject CreateHexagon(Point2D startLocaion)
		{
			return CreateBeliver(new Hexagon(startLocaion, 0));
		}

		public GameObject CreateSquare(Point2D startLocation)
		{
			return CreateBeliver(new Rectangle(startLocation, 0));
		}

		public GameObject CreateMine(Rectangle rect)
		{
			List<Money> money = new List<Money>();

			int n = Utils.Random(0, 100);

			for (int i = 0; i < n; i++)
			{
				money.Add(new Money(Utils.Random(1, 10)));
			}

			GameObject newMine = new GameObject();

			newMine.Add(new InventoryComponent("mine", money, newMine));
			newMine.Add(new MineGraphicalComponent(rect, newMine));
			newMine.Add(new MineCollsionComponent(rect, newMine));
			newMine.Add(new MineDeleteComponet(newMine));
			newMine.Add(new SelectComponent(newMine));
			newMine.Add(new SoundComponet(newMine));
			newMine.GetComponent<SoundComponet>().Add(SoundType.Select, new Sound(Settings.MINE_SOUND_FILENAME));
			return newMine;
		}

		public GameObject CreateMine(Point2D location)
		{
			return CreateMine(new Rectangle(location, _rnd.Next(50, 200), _rnd.Next(50, 200)));
		}

		public GameObject CreateMiniMap(World world, Rectangle bounds)
		{
			GameObject newMiniMap = new GameObject();

			newMiniMap.Add(new MiniMapInputComponent(bounds, newMiniMap));
			newMiniMap.Add(new MiniMapGraphicsComponent(world, bounds, newMiniMap));

			return newMiniMap;
		}

		public GameObject CreateBoxSelect(Selector selector)
		{
			GameObject newBoxSelect = new GameObject();

			newBoxSelect.Add(new BoxSelectGraphicalComponent(newBoxSelect));
			newBoxSelect.Add(new BoxSelectCollsionComponent(selector, newBoxSelect.GetComponent<BoxSelectGraphicalComponent>().HitBox, newBoxSelect));
			newBoxSelect.Add(new BoxSelectInputComponent(Settings.Instance.Gamebounds, selector, newBoxSelect));

			return newBoxSelect;
		}

		public GameObject CreatePortart(Selector selector, GameObject gameObject, Shape bounds)
		{
			IHavePortrait portraitGraphics = null;

			if (gameObject.GetComponent<GraphicsComponent>() is IHavePortrait)
			{
				portraitGraphics = gameObject.GetComponent<GraphicsComponent>() as IHavePortrait;
			}
			else
			{
				throw new Exception("Provied component is not a IHavePortrait");
			}

			GameObject newPortart = new GameObject();

			newPortart.Add(new PortatGraphicsComponent(portraitGraphics,bounds,newPortart));
			newPortart.Add(new PortraitUserInputComponent(selector, gameObject, newPortart));

			return newPortart;
		}

		public GameObject CreatePanel(Shape bounds)
		{
			GameObject newPanel = new GameObject();

			newPanel.Add(new PanelUserInputComponent(bounds, newPanel));
			newPanel.Add(new PanelGraphicalompment(bounds, newPanel));

			return newPanel;
		}

		public UserInterlfaceContainer CreateInfoPannel(Selector selector, Shape bounds)
		{
			UserInterlfaceContainer ui = new UserInterlfaceContainer(selector, true);

			GameObject pannel = CreatePanel(bounds);

			ui.Add(pannel);

			Point2D startLocation = bounds.Copy().Add(Settings.PORTRAT_SPACING);
			Rectangle portratBounds = new Rectangle(startLocation, Settings.PORTRAT_SIZE, Settings.PORTRAT_SIZE);

			foreach (GameObject i in selector.GameObjects)
			{
				ui.Add(CreatePortart(selector, i, portratBounds.Copy()));

				portratBounds.Add(new Point2D(portratBounds.Size + Settings.PORTRAT_SPACING, 0));

				if(!CollsionDetector.Inside(portratBounds, bounds.HitBox))
				{
					portratBounds.X = startLocation.X;
					portratBounds.Y += portratBounds.Height + Settings.PORTRAT_SPACING;
				}

				if(!CollsionDetector.Inside(portratBounds, bounds.HitBox))
				{
					break;
				}
			}

			return ui;
		}

		private BeliverBeliefComponent GetRandomBeleif(string name, GameObject holder)
		{
			BeliverBeliefComponent result;

			switch (Utils.Random(0, 2))
			{
				case 0:
					{
						result = new MoneyFavouredBeliefComponent(name, holder);
						break;
					}
				case 1:
					{
						result = new AgeFavouredBeliefComponent(name, holder);
						break;
					}

				default:
					{
						throw new NotImplementedException();
					}
			}

			return result;
		}

		private List<string> IniliseBeliverNames(string start)
		{
			List<string> result = new List<string>();

			try
			{
				using (StreamReader reader = new StreamReader(Settings.Instance.NamesFileName))
				{
					result = new List<string>();

					string line = "";

					while (reader.ReadLine() != start && line != null) ;

					line = reader.ReadLine();

					while (line != null && !line.Contains(':'))
					{
						result.Add(line);
						line = reader.ReadLine();

					}
				}

				return result;
			}
			catch (Exception)
			{
				throw new IOException("Unable to open file");
			}
		}

		private string GetRandomShapeName(Type type)
		{
			return _believerData[type].Names.RandomElement();
		}

		private void AddSoundsToSoundComponet(SoundComponet sound, SoundType type,  string baseFileName)
		{
			foreach (string i in Utils.GetFileSequnce(baseFileName))
			{
				sound.Add(type, new Sound(i));
			}

		}

		private string GetBeleiverSoundFileName(string basefileName, Type type)
		{
			return basefileName.Insert(basefileName.IndexOf('.'), _believerData[type].FileNameBase);
		}
	}
}
