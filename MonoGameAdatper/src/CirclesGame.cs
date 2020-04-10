using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PrimitiveBuddy;

namespace MonoGameAdatper
{
	public class CirclesGame : Game
	{
		private GraphicsDeviceManager _graphics;
		private SpriteBatch _spriteBatch;
		private Primitive _prim;
		private KeyboardState _keys;
		private float _step = 200f;

		public CirclesGame()
		{
			_graphics = new GraphicsDeviceManager(this);
			_keys = new KeyboardState();
		}

		public void SetGraphicsWindow(int width, int height)
		{
			_graphics.PreferredBackBufferWidth = width;
			_graphics.PreferredBackBufferHeight = height;
			_graphics.ApplyChanges();
		}

		protected override void Initialize()
		{
			base.Initialize();
			_prim = new Primitive(_graphics.GraphicsDevice, _spriteBatch);
			_prim.NumCircleSegments = 3;
		}

		protected override void LoadContent()
		{
			_spriteBatch = new SpriteBatch(GraphicsDevice);
		}

		protected override void Update(GameTime gameTime)
		{
			var curKeys = Keyboard.GetState();
			if (_keys.IsKeyUp(Keys.A) && curKeys.IsKeyDown(Keys.A))
			{
				_prim.NumCircleSegments = _prim.NumCircleSegments + 1;
			}
			else if (_keys.IsKeyUp(Keys.S) && curKeys.IsKeyDown(Keys.S))
			{
				_prim.NumCircleSegments = _prim.NumCircleSegments - 1;
			}
			_keys = curKeys;

			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.White);

			_spriteBatch.Begin();

			_prim.Circle(new Vector2(128f, 128f), 64f, Color.White);
			_prim.Pie(new Vector2(256f, 256f), 64f, MathHelper.PiOver2, MathHelper.PiOver2, Color.White);

			_prim.SineWave(new Vector2(300, 200), new Vector2(500, 200), 20f, 30f, Color.White);
			_prim.SineWave(new Vector2(300, 300), new Vector2(400, 400), 20f, 30f, Color.Red);
			_prim.SineWave(new Vector2(300, 400), new Vector2(400, 550), 20f, 30f, Color.White);
			_prim.SineWave(new Vector2(200, 400), new Vector2(300, 300), 20f, 30f, Color.Green);

			_prim.SineWave(new Vector2(_step, 100), new Vector2(200, 100), 20f, 30f, Color.Green);
			_step += 2f;
			if (_step >= 1000)
			{
				_step = 200f;
			}

			_spriteBatch.End();

			base.Draw(gameTime);
		}
	}
}
