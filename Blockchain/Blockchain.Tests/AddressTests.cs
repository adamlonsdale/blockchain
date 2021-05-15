using Blockchain.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blockchain.Tests
{
    [TestClass]
    public class AddressTests
    {
        [TestMethod]
        public void AddressesAreDifferentWithSameSeed()
        {
            var address1 = new Address();
            var address2 = new Address();

            Assert.AreNotEqual(address1.ToString(), address2.ToString());
        }
    }
}
