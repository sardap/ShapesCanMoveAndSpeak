using System;
using System.Diagnostics;
using SharedLibary;
using System.Collections.Generic;
using System.Linq;

namespace Game.src
{
	/// <summary>
	/// Purpose: The Timer which can have a multiplier to increase the speed of time 
	/// </summary>
	public class GameTimer
	{
		private Stopwatch _tmr = new Stopwatch();
		private TimeSpan _lastTime = new TimeSpan(0);
		// I couldn't get delta time to work i sound like an idiot Mostly because i am
		private TimeSpan _deltaTime;

		public GameTimer(double speed)
		{
			Speed = speed;
		}

		public long DeltaTime
		{
			get
			{
				return Convert.ToInt64(Speed);
				// The Reason why i am not using .TotalMillisecound is because it returns a double
				return Math.Max(_deltaTime.Ticks / TimeSpan.TicksPerMillisecond, Convert.ToInt64(1 * Speed));
			}
		}

		public double Speed
		{
			get;
			set;
		}

		public void Restart()
		{
			_tmr.Stop();
			TimeSpan now = _tmr.Elapsed.Multiply(Speed);
			_deltaTime = now.Subtract(_lastTime);
			_lastTime = now;
			_tmr.Reset();
			_tmr.Start();
		}
	}
}
