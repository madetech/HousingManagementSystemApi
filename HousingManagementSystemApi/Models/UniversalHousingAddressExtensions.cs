namespace HousingManagementSystemApi.Models
{
    using HACT.Dtos;

    public static class UniversalHousingAddressExtensions
    {
        public static PropertyAddress ToHactPropertyAddress(this UniversalHousingAddress universalHousingAddress)
        {
            var result = new PropertyAddress
            {
                AddressLine = string.IsNullOrWhiteSpace(universalHousingAddress.ShortAddress) ? null : new[] { universalHousingAddress.ShortAddress },
                PostalCode = universalHousingAddress.PostCode,
                BuildingNumber = universalHousingAddress.PostDesig,
                //??? = universalHousingAddress.PropertyReference,
                //??? = universalHousingAddress.Uprn
            };

            return result;
        }
    }
}
