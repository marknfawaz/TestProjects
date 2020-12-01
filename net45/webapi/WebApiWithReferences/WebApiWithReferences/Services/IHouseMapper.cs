using WebApiWithReferences.Models;

namespace WebApiWithReferences.Services
{
    public interface IHouseMapper
    {
        HouseDto MapToDto(HouseEntity houseEntity);
        HouseEntity MapToEntity(HouseDto houseDto);
    }
}