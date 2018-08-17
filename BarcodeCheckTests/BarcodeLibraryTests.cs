using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarcodeLibrary;

namespace BarcodeCheckTests
{
    [TestFixture]
    public class BarcodeLibraryTests
    {
        [Test]
        public void CalculateCheckDigitTest()
        {
            Assert.AreEqual(Barcode.CalculateCheckDigit("941474767735"), 6);
            Assert.AreEqual(Barcode.CalculateCheckDigit("941349400047"), 9);
        }

        [Test]
        public void GetBarcodeType()
        {
            Assert.AreEqual(Barcode.GetBarcodeType("9414747677356"),Barcode.BarcodeFormat.Ean13);
        }
    }
}
