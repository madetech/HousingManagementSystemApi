namespace HousingManagementSystemApi.Models
{
    using HACT.Dtos;

    public static class UniversalHousingAddressExtensions
    {
        public static PropertyAddress ToHactPropertyAddress(this UniversalHousingAddress universalHousingAddress)
        {
            var propertyReference = universalHousingAddress.PropertyReference == null
                ? null
                : new Reference
                {
                    ID = universalHousingAddress.PropertyReference,
                    AllocatedBy = "Universal Housing",
                };

            var result = new PropertyAddress
            {
                AddressLine = string.IsNullOrWhiteSpace(universalHousingAddress.ShortAddress) ? null : new[] { universalHousingAddress.ShortAddress },
                PostalCode = universalHousingAddress.PostCode,
                BuildingNumber = universalHousingAddress.PostDesig,
                Reference = propertyReference
            };

            return result;
        }
    }
}
