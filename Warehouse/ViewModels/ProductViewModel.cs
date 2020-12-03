using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.ClassLibrary;

namespace Warehouse.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите имя продукта")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Выберите единицу измерения")]
        public int UnitId { get; set; }
        public UnitViewModel Unit { get; set; }

        [DataType(DataType.MultilineText)]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Введите вес")]
        [Range(0.0f, float.MaxValue, ErrorMessage = "Некорректное число")]
        public float Weight { get; set; }
        public Price Price { get; set; }
        [Required(ErrorMessage = "Введите цену")]
        [RegularExpression("^[0-9]+(\\.[0-9]{1,2})?$", ErrorMessage ="Некорректная цена")]
        public string PriceString { 
            get 
            {
                return Price?.RoublesString;
            }
            set
            {
                Price = Price.Parse(value);
            }
        }

        [Range(0, int.MaxValue, ErrorMessage = "Некорректное число")]
        public int? ShelfLife { get; set; }

        [Required(ErrorMessage = "Выберите страну происхождения")]
        public int ManufactureCountryId { get; set; }
        public CountryViewModel ManufactureCountry { get; set; }

        [Required(ErrorMessage = "Введите количество на складе")]
        [Range(0,int.MaxValue, ErrorMessage = "Некорректное число")]
        public int CountInStock { get; set; }
        public List<UrlViewModel> Pictures { get; set; }

        public string GetCountString() => $"{CountInStock} {Unit}";
        public string GetShelfLifeString() => (ShelfLife != int.MaxValue ? $"{ShelfLife} дней" : "неограничен");
        public string GetWeightString() => (Weight > 1 ? Weight + " кг" : Weight * 1000 + " г");
    }
}
