using Microsoft.VisualStudio.TestTools.UnitTesting;
using GBX_Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBX_Calculator.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void productTest()
        {
            string makeformula = Program.product();
            Assert.IsTrue(makeformula != null);//判断生成的不为空式子
        }
        [TestMethod()]
        public void CountTest()
        {
            string result = "6*6-6";
            string Answer = "30";
            string An = Program.Count(result);
            Assert.AreEqual(Answer, An);
        }
    }
}