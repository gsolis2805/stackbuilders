using Microsoft.VisualStudio.TestTools.UnitTesting;
using PicoYPlacaPredictor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestPredictor
{
    [TestClass]
    public class PredictorTests
    {
        [TestMethod]
        public void validateDayRules()
        {
            DateTime date = new DateTime(2016,10,05);
           
            DayRules d = new DayRules(date);
            d.GetRestrictedNumbers();
            Assert.IsTrue(d.GetRestrictedNumbers().Count > 0);
        }
    }
}
