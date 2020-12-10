using SampleWebApi.Models;
using System.Collections.Generic;
using System.ComponentModel;

namespace SampleWebApi.Repositories
{
    [Description("Test")]
    public interface ITestInterface
    {
        List<HouseEntity> GetAll();
        HouseEntity GetSingle(int id);
        HouseEntity Add(HouseEntity toAdd);
        HouseEntity Update(HouseEntity toUpdate);
        void Delete(int id);
    }
}
