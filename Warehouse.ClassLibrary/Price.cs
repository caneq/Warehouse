using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse.ClassLibrary
{
    public class Price : IComparable
    {
        public long Penny { get; private set; }

        public Price(long penny)
        {
            this.Penny = penny;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(Penny.ToString());
            if (sb.Length > 2)
            {
                if (sb.ToString(sb.Length - 2, 2) == "00")
                    sb.Remove(sb.Length - 2, 2);

                else sb.Insert(sb.Length - 2, ".");
            }
            else if (sb.Length == 2)
            {
                sb.Insert(0, "0.");
            }
            else
            {
                sb.Insert(0, "0.0");
            }
            sb.Append(" Руб");
            return sb.ToString(); ;
        }
        public static Price operator +(Price c1, Price c2) => new Price(c1.Penny + c2.Penny);
        public static Price operator -(Price c1, Price c2) => new Price(c1.Penny - c2.Penny);
        public static bool operator >(Price c1, Price c2) => c1.Penny > c2.Penny;
        public static bool operator <(Price c1, Price c2) => c1.Penny < c2.Penny;

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            Price otherPrice = obj as Price;
            if (otherPrice == null)
            {
                throw new ArgumentException($"Object is not a {this.GetType().FullName}");
            }
            return Math.Sign(Penny - otherPrice.Penny);
        }
    }
}
