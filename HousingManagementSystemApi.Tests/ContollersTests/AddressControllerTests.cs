using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using HACT.Dtos;
using HousingManagementSystemApi.Controllers;
using HousingManagementSystemApi.UseCases;
using Moq;
using Xunit;

namespace HousingManagementSystemApi.Tests
{

    public class AddressControllerTests : ControllerTests
    {
        private readonly AddressesController systemUnderTest;
        private readonly Mock<IRetrieveAddressesUseCase> retrieveAddressesUseCaseMock;
        private readonly string postcode;
        public AddressControllerTests()
        {
            postcode = "postcode";
            var dummyList = new List<PropertyAddress> { new() { PostalCode = this.postcode } };
            retrieveAddressesUseCaseMock = new Mock<IRetrieveAddressesUseCase>();
            retrieveAddressesUseCaseMock
                .Setup(x => x.Execute(this.postcode))
                .ReturnsAsync(dummyList);
            systemUnderTest = new AddressesController(retrieveAddressesUseCaseMock.Object);
        }
        [Fact]
        public async Task GivenAPostcode_WhenAValidAddressRequestIsMade_ItReturnsASuccessfullResponse()
        {

            var result = await systemUnderTest.Address(this.postcode);
            retrieveAddressesUseCaseMock.Verify(x => x.Execute(this.postcode), Times.Once);
            GetStatusCode(result).Should().Be(200);
        }
        [Fact]
        public async Task GivenAPostcode_WhenAValidAddressRequestIsMade_ItReturnsCorrectData()
        {

            var result = await systemUnderTest.Address(postcode);
            GetResultData<List<PropertyAddress>>(result).First().PostalCode.Should().Be(this.postcode);
        }

    }

}
