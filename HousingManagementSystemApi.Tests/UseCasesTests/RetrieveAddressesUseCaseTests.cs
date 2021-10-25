using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using HACT.Dtos;
using HousingManagementSystemApi.Gateways;
using HousingManagementSystemApi.UseCases;
using Moq;
using Xunit;
namespace HousingManagementSystemApi.Tests
{

    public class RetrieveAddressesUseCaseTests
    {
        private readonly Mock<IAddressesGateway> retrieveAddressesGateway;
        private readonly RetrieveAddressesUseCase retrieveAddressesUseCase;

        public RetrieveAddressesUseCaseTests()
        {
            retrieveAddressesGateway = new Mock<IAddressesGateway>();
            retrieveAddressesUseCase = new RetrieveAddressesUseCase(retrieveAddressesGateway.Object);

        }
        [Fact]
        public async Task GivenAPostcode_WhenExecute_GatewayReceivesCorrectInput()
        {
            const string TestPostcode = "postcode";
            retrieveAddressesGateway.Setup(x => x.SearchByPostcode(TestPostcode));
            await retrieveAddressesUseCase.Execute(TestPostcode);
            retrieveAddressesGateway.Verify(x => x.SearchByPostcode(TestPostcode), Times.Once);
        }
        [Fact]
        public async Task GivenAPostcode_WhenAnAddressExists_GatewayReturnsCorrectData()
        {
            const string TestPostcode = "postcode";
            retrieveAddressesGateway.Setup(x => x.SearchByPostcode(TestPostcode))
                .ReturnsAsync(new PropertyAddress[] { new() { PostalCode = TestPostcode } });
            var result = await retrieveAddressesUseCase.Execute(TestPostcode);
            result.First().PostalCode.Should().Be(TestPostcode);
        }

        [Fact]
        public async void GivenNullPostcode_WhenExecute_ThrowsNullException()
        {
            Func<Task> act = async () => await retrieveAddressesUseCase.Execute(null);
            await act.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async void DoesNotCallAddressGatewayWhenPostcodeIsEmpty()
        {
            const string TestPostcode = "";
            await retrieveAddressesUseCase.Execute(postcode: TestPostcode);
            retrieveAddressesGateway.Verify(x => x.SearchByPostcode(TestPostcode), Times.Never);
        }
    }

}
