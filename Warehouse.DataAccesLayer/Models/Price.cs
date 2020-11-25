using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse.DataAccessLayer.Models
{
    class Price : IComparable
    {
        public long Penny { get; private set; }
        public decimal Roubles {
            get 
            {
                return ((decimal)Penny) / 100;
            } 
            private set
            {
                Penny = (int)(value * 100);
            }
        }
        Price(long penny)
        {
            this.Penny = penny;
        }
        public override string ToString()
        {
            return $"{Roubles} руб.";
        }
        public static Price operator +(Price c1, Price c2)
        {
            return new Price (c1.Penny + c2.Penny);
        }
        public static Price operator -(Price c1, Price c2)
        {
            return new Price(c1.Penny - c2.Penny);
        }
        public static bool operator >(Price c1, Price c2)
        {
            return c1.Penny > c2.Penny;
        }
        public static bool operator <(Price c1, Price c2)
        {
            return c1.Penny < c2.Penny;
        }
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            Price otherPrice = obj as Price;
            if (otherPrice != null)
            {
                return Math.Sign(Penny - otherPrice.Penny);
            }
            else
                throw new ArgumentException($"Object is not a {this.GetType().FullName}");
            
        }
    }
}
