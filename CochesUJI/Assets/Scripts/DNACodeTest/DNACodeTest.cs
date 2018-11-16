using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace DNACodeTest
{
    [TestClass]
    public class DNACodeTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            DNACode codigo = new DNACode();
            foreach (String key in DNACode.KEYS) 
            {
                Assert.AreEqual(DNACode.GEN_MIN_VALUE, codigo.getGen(key));
            }
        }
    }
}
