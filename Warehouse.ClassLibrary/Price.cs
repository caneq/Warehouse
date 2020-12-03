using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Warehouse.ClassLibrary.Exceptions;

namespace Warehouse.ClassLibrary
{
    public class Price : IComparable
    {
        public long Penny { get; private set; }

        public Price(long penny)
        {
            this.Penny = penny;
        }
        static public Price Parse(string str)
        {
            if (!Regex.Match(str, "^[0-9]+(\\.[0-9]{1,2})?$").Success)
            {
                throw new ParseException();
            }
            try
            {
                long resLong;
                var pointIndex = str.IndexOf(".");
                if (pointIndex == -1)
                {
                    resLong = long.Parse(str)*100;
                }
                else if (pointIndex == str.Length - 1 - 1)
                {
                    resLong = long.Parse(str.Replace(".", "")) * 10;
                }
                else
                {
                    resLong = long.Parse(str.Replace(".", ""));
                }
                return new Price(resLong);
            }
            catch
            {
                throw new ParseException();
            }
        }
        public string RoublesString
        {
            get
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
                return sb.ToString();
            }
            private set
            {
                try
                {
                    Penny = Parse(value).Penny;
                }
                catch
                {
                    return;
                }
            }
        }
        public string GetRoublesString()
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

            return sb.ToString();
        }
        public override string ToString()
        {
            return $"{RoublesString} Руб";
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
        public override bool Equals(object obj)
        {
            try
            {
                return CompareTo(obj) == 0;
            }
            catch
            {
                return false;
            }
        }
        public override int GetHashCode()
        {
            return Penny.GetHashCode();
        }
    }
}
