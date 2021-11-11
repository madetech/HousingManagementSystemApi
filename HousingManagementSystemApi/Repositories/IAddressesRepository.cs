namespace HousingManagementSystemApi.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using HACT.Dtos;

    public interface IAddressesRepository
    {
        Task<IEnumerable<PropertyAddress>> GetAddressesByPostcode(string postcode);
    }
}
