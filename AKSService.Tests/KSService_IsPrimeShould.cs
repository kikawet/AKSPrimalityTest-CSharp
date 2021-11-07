using Xunit;
using AKS.Services;

namespace Prime.UnitTests.Services
{
    public class AKSService_IsPrimeShould
    {
        [Fact]
        public void IsPrime_InputIs1_ReturnFalse()
        {
            var primeService = new AKSService();
            bool result = primeService.IsPrime(1);

            Assert.False(result, "1 should not be prime");
        }
    }
}