using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibary;

namespace Game.src
{
	/// <summary>
	/// AUTHOR : Steven Lambert
	/// URL : https://gamedevelopment.tutsplus.com/tutorials/quick-tip-use-quadtrees-to-detect-likely-collisions-in-2d-space--gamedev-374
	/// Modified / Translated by : Paul Sarda
	/// </summary>
	public class QuadTree
	{
		private int _level;
		private List<CollsionComponent> _objects;
		private Rectangle _bounds;
		private QuadTree[] _nodes;

		public QuadTree(int pLevel, Rectangle pBounds)
		{
			_level = pLevel;
			_objects = new List<CollsionComponent>();
			_bounds = pBounds;
			_nodes = new QuadTree[4];
		}

		public void Process(List<CollsionComponent> collisions)
		{
			Clear();
			Populate(collisions);
			CheckCollsions(collisions);
		}

		private void Populate(List<CollsionComponent> collisions)
		{
			foreach (CollsionComponent i in collisions)
			{
				Insert(i);
			}
		}

		private void CheckCollsions(List<CollsionComponent> collisions)
		{
			foreach (CollsionComponent i in collisions)
			{
				foreach (CollsionComponent j in Retrieve(i))
				{
					i.CheckCollsion(j);
				}
			}
		}

		private void Clear()
		{
			_objects.Clear();

			for (int i = 0; i < _nodes.Length; i++)
			{
				if (_nodes[i] != null)
				{
					_nodes[i].Clear();
					_nodes[i] = null;
				}
			}
		}

		private void Insert(CollsionComponent pRect)
		{
			if (_nodes[0] != null)
			{
				int i = GetIndex(pRect);

				if (i != -1)
				{
					_nodes[i].Insert(pRect);

					return;
				}
			}

			_objects.Add(pRect);

			if (_objects.Count > Settings.QUADTREE_MAX_OBJECTS && _level < Settings.QUADTREE_MAX_LEVELS)
			{
				if (_nodes[0] == null)
				{
					Split();
				}

				int j = 0;

				while (j < _objects.Count)
				{
					int index = GetIndex(_objects[j]);

					if (index != -1)
					{
						_nodes[index].Insert(_objects[j]);
						_objects.RemoveAt(j);
					}
					else
					{
						j++;
					}
				}
			}
		}

		private List<CollsionComponent> Retrieve(HashSet<CollsionComponent> returnedObjs, CollsionComponent obj)
		{
			if (_nodes[0] != null)
			{
				var index = GetIndex(obj);
				if (index != -1)
				{
					_nodes[index].Retrieve(returnedObjs, obj);
				}
				else
				{
					for (int i = 0; i < _nodes.Length; i++)
					{
						_nodes[i].Retrieve(returnedObjs, obj);
					}
				}
			}

			foreach (CollsionComponent i in _objects)
			{
				returnedObjs.Add(i);
			}

			return returnedObjs.ToList();
		}

		private List<CollsionComponent> Retrieve(CollsionComponent pRect)
		{
			return Retrieve(new HashSet<CollsionComponent>(), pRect);
		}

		private void Split()
		{
			int subWidth = Convert.ToInt32(_bounds.Width) >> 1;
			int subHeight = Convert.ToInt32(_bounds.Height) >> 1;
			int newX = Convert.ToInt32(_bounds.X);
			int newY = Convert.ToInt32(_bounds.Y);

			_nodes[0] = new QuadTree(_level + 1, new Rectangle(newX + subWidth, newY, subWidth, subHeight));
			_nodes[1] = new QuadTree(_level + 1, new Rectangle(newX, newY, subWidth, subHeight));
			_nodes[2] = new QuadTree(_level + 1, new Rectangle(newX, newY + subHeight, subWidth, subHeight));
			_nodes[3] = new QuadTree(_level + 1, new Rectangle(newX + subWidth, newY + subHeight, subWidth, subHeight));
		}

		private int GetIndex(CollsionComponent pRect)
		{
			int index = -1;
			double verticalMidpoint = _bounds.X + (_bounds.Width / 2);
			double horizontalMidpoint = _bounds.Y + (_bounds.Height / 2);

			// Object can completely fit within the top quadrants
			bool topQuadrant = (pRect.Bounds.Y < horizontalMidpoint && pRect.Bounds.Y + pRect.Bounds.Height < horizontalMidpoint);

			// Object can completely fit within the bottom quadrants
			bool bottomQuadrant = (pRect.Bounds.Y > horizontalMidpoint);

			// Object can completely fit within the left quadrants
			if (pRect.Bounds.X < verticalMidpoint && pRect.Bounds.X + pRect.Bounds.Width < verticalMidpoint)
			{
				if (topQuadrant)
				{
					index = 1;
				}
				else if (bottomQuadrant)
				{
					index = 2;
				}
			}
			// Object can completely fit within the right quadrants
			else if (pRect.Bounds.X > verticalMidpoint)
			{
				if (topQuadrant)
				{
					index = 0;
				}
				else if (bottomQuadrant)
				{
					index = 3;
				}
			}
			return index;
		}


	}
}
