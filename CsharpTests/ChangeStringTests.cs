using Microsoft.VisualStudio.TestTools.UnitTesting;
using Csharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.Tests
{
    [TestClass()]
    public class ChangeStringTests
    {
        [TestMethod()]
        public void buildTest()
        {
            ChangeString chns = new ChangeString();
            Assert.AreEqual(chns.build("123 abcd*3"), "123 bcde*3");
            Assert.AreEqual(chns.build("**Casa 52"), "**Dbtb 52");
        }
    }
}