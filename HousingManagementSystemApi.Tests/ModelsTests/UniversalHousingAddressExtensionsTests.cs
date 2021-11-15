namespace HousingManagementSystemApi.Tests.ModelsTests
{
    using FluentAssertions;
    using HACT.Dtos;
    using Models;
    using Xunit;

    public class UniversalHousingAddressExtensionsTests
    {
        [Fact]
#pragma warning disable CA1707
        public void GivenEmptyUniversalHousingAddress_WhenConvertingToHactPropertyAddress_ThenPropertyAddressShouldBeEmpty()
#pragma warning restore CA1707
        {
            // Arrange

            // Act
            var actual = new UniversalHousingAddress().ToHactPropertyAddress();

            // Assert
            actual.Should().BeEquivalentTo(new PropertyAddress());
        }

        [Fact]
#pragma warning disable CA1707
        public void GivenUniversalHousingAddressWithPostCodeOnly_WhenConvertingToHactPropertyAddress_ThenPropertyAddressShouldOnlyContainPostalCode()
#pragma warning restore CA1707
        {
            // Arrange
            var postCode = "a postcode";

            // Act
            var actual = new UniversalHousingAddress { PostCode = postCode }.ToHactPropertyAddress();

            // Assert
            actual.Should().BeEquivalentTo(new PropertyAddress { PostalCode = postCode });
        }

        [Fact]
#pragma warning disable CA1707
        public void GivenUniversalHousingAddressWithAddressOnly_WhenConvertingToHactPropertyAddress_ThenPropertyAddressShouldOnlyContainAddress()
#pragma warning restore CA1707
        {
            // Arrange
            var address = "an address";

            // Act
            var actual = new UniversalHousingAddress { ShortAddress = address }.ToHactPropertyAddress();

            // Assert
            actual.Should().BeEquivalentTo(new PropertyAddress { AddressLine = new[] { address } });
        }

        [Fact]
#pragma warning disable CA1707
        public void GivenUniversalHousingAddressWithPostDesigOnly_WhenConvertingToHactPropertyAddress_ThenPropertyAddressShouldOnlyContainBuildingNumber()
#pragma warning restore CA1707
        {
            // Arrange
            var doorNumber = "a door number";

            // Act
            var actual = new UniversalHousingAddress { PostDesig = doorNumber }.ToHactPropertyAddress();

            // Assert
            actual.Should().BeEquivalentTo(new PropertyAddress { BuildingNumber = doorNumber });
        }
    }
}
