using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse.BusinessLogicLayer.DataTransferObjects
{
    public class PriceDTO : IComparable
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
        PriceDTO(long penny)
        {
            this.Penny = penny;
        }
        public override string ToString()
        {
            return $"{Roubles} руб.";
        }
        public static PriceDTO operator +(PriceDTO c1, PriceDTO c2)
        {
            return new PriceDTO(c1.Penny + c2.Penny);
        }
        public static PriceDTO operator -(PriceDTO c1, PriceDTO c2)
        {
            return new PriceDTO(c1.Penny - c2.Penny);
        }
        public static bool operator >(PriceDTO c1, PriceDTO c2)
        {
            return c1.Penny > c2.Penny;
        }
        public static bool operator <(PriceDTO c1, PriceDTO c2)
        {
            return c1.Penny < c2.Penny;
        }
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            PriceDTO otherPrice = obj as PriceDTO;
            if (otherPrice != null)
            {
                return Math.Sign(Penny - otherPrice.Penny);
            }
            else
                throw new ArgumentException($"Object is not a {this.GetType().FullName}");
            
        }
    }
}
