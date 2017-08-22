using System.Collections.Generic;
using System.Linq;
using ConfigReader.Contract;
using ConfigReader.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConfigReader.Tests
{
    [TestClass]
    public class SimpleConfigReaderTests
    {
        private const string SampleCfg = "config.cfg";

        [TestMethod]
        public void BasicTest()
        {
            IConfigReader cfgReader = new SimpleConfigReader(SampleCfg);

            var value = cfgReader.GetValue<string>("TestKey");

            Assert.AreEqual("TestValue", value);
        }

        [TestMethod]
        public void IntParseTest()
        {
            IConfigReader cfgReader = new SimpleConfigReader(SampleCfg);

            var value = cfgReader.GetValue<int>("TestInt");

            Assert.AreEqual(1, value);
        }

        [TestMethod]
        public void DoubleParseTest()
        {
            IConfigReader cfgReader = new SimpleConfigReader(SampleCfg);

            var value = cfgReader.GetValue<double>("TestDouble");

            Assert.AreEqual(1.1, value);
        }

        [TestMethod]
        public void EnumerableTest()
        {
            List<KeyValuePair<string, string>> excepted = new Dictionary<string, string>
            {
                {"TestKey","TestValue"},
                {"TestInt","1"},
                {"TestDouble","1.1" }
            }.ToList();
            IConfigReader cfgReader = new SimpleConfigReader(SampleCfg);

            List<KeyValuePair<string, string>> actual = cfgReader.ToList();

            CollectionAssert.AreEquivalent(excepted, actual);
        }
    }
}