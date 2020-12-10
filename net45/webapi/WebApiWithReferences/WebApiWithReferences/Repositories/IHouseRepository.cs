using System.Collections.Generic;
using WebApiWithReferences.Models;
using System.ComponentModel;

namespace WebApiWithReferences.Repositories
{
    [Description("Test")]
    public interface IHouseRepository
    {
        List<HouseEntity> GetAll();
        HouseEntity GetSingle(int id);
        HouseEntity Add(HouseEntity toAdd);
        HouseEntity Update(HouseEntity toUpdate);
        void Delete(int id);
    }
}
