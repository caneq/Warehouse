using System;
using System.Collections.Generic;
using System.Text;
using Warehouse.BusinessLogicLayer.DataTransferObjects;

namespace Warehouse.BusinessLogicLayer.Interfaces
{
    public interface ICountriesService
    {
        IEnumerable<CountryDTO> ReadAll();
    }
}
