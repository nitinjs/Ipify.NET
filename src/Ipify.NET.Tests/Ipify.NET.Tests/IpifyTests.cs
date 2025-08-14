using NUnit.Framework;
using System.Net;
using Ipify.Net;
using System.Threading.Tasks;

namespace Ipify.Net.Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public async Task GetAddress_ReturnsStringContainingAnIPAddress()
        {
            string ip = await Ipify.GetPublicAddress();
            IPAddress ipAddress;
            Assert.IsTrue(IPAddress.TryParse(ip, out ipAddress));
        }

        [Test]
        public async Task GetAddress_ReturnsStringContainingAnIPAddressUsingHttps()
        {
            string ip = await Ipify.GetPublicAddress(useHttps: true);
            IPAddress ipAddress;
            Assert.IsTrue(IPAddress.TryParse(ip, out ipAddress));
        }

        [Test]
        public async Task GetIPAddress_ReturnsIPAddressInstance()
        {
            IPAddress ipAddress = await Ipify.GetPublicIPAddress();
            Assert.IsNotNull(ipAddress);
            Assert.AreNotEqual(IPAddress.None, ipAddress);
        }

        [Test]
        public async Task GetIPAddress_ReturnsIPAddressInstanceUsingHttps()
        {
            IPAddress ipAddress = await Ipify.GetPublicIPAddress(useHttps: true);
            Assert.IsNotNull(ipAddress);
            Assert.AreNotEqual(IPAddress.None, ipAddress);
        }
    }
}