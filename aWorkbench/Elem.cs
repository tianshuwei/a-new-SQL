using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace aWorkbench
{
	class Elem :Object
	{
		public enum VALTYPE{INT=233,STRING=666};
		private int? numVal;
		private string strVal;
		private VALTYPE _type;
		public VALTYPE type {get { return _type; }}
		public Elem(int n) {
			numVal = n;
			strVal = null;
			_type = VALTYPE.INT;
		}
		public Elem(string str) {
			numVal = null;
			strVal = (string)str.Clone();
			_type = VALTYPE.STRING;
		}

		public object value {
			get {
				switch (_type) {
					case VALTYPE.INT:
						return numVal;
					case VALTYPE.STRING:
						return strVal;
				}

				return null;
			}

			set {
				if (value.GetType() == typeof(int))
					numVal = (int?)value;
				else if (value.GetType() == typeof(string))
					strVal = (string)value;
				else throw new InvalidCastException();
			}
		}

		public override bool Equals(object obj)
		{
            try
            {
                if (((Elem)obj).type != this.type) return false;
                return ((Elem)obj).value == this.value;
            }
            catch
            { }
			return base.Equals(obj);
		}

		public override string ToString()
		{
			if (this.type == VALTYPE.INT) return numVal.ToString();
			else return strVal;
        }

		public static implicit operator int (Elem ele) {
			if (ele.type == VALTYPE.INT) return (int)ele.numVal;
			else throw new InvalidCastException();
		}

		public static implicit operator string (Elem ele)
		{
			if (ele.type == VALTYPE.STRING) return ele.strVal;
			else throw new InvalidCastException();
		}


	}
}
