using System;

namespace Equipments
{
	public abstract class Equipment
	{

		bool _use;
		public bool Use{
			get{ return this._use; }
			set{ this._use = value; } 
		}

		int _priority;
		public int Priority{
			get{ return this._priority; }
			set{ this._priority = value; }
		}

		int _luckyTouch;
		public int LuckyTouch{
			get{ return this._luckyTouch; }
			set{ this._luckyTouch = value; }
		}

		private string _name;
		public string Name{
			get{ return this._name; }
			set{ this._name = value;}
		}

		private int _point;
		public int Point{
			get{ return this._point; }
			set{ this._point = value;}
		}

		public Equipment (string name, int point)
		{
			this.Name = name;
			this.Point = point;
		}

	}
}

