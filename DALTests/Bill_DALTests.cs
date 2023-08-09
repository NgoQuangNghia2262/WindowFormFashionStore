using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Tests
{
    [TestClass()]
    public class Bill_DALTests
    {
        [TestMethod()]
        public  void findAllTest()
        {
            Bill_DAL dal = new Bill_DAL();
            var data =  dal.findAll();
            Console.WriteLine();
        }
    }
}