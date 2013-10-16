using System;

namespace Equipments
{
	public abstract class Equipment
	{

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

