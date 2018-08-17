using System;
using System.Linq;

namespace BarcodeLibrary
{
    public static class Barcode
    {
        public enum BarcodeFormat
        {
            Aztec,
            Codabar,
            Code39,
            Code93,
            Code128,
            DataMatrix,
            Ean8,
            Ean13,
            Itf,
            Maxicode,
            Pdf417,
            QrCode,
            Rss14,
            RssExpanded,
            UpcA,
            UpcE,
            UpcEanExtension
        }

        public static int CalculateCheckDigit(string barcode)
        {
            var newArray = barcode.ToList();
            newArray.Reverse();
            var byThree = 0;
            var byOne = 0;
            while (newArray.Count > 0)
            {
                var calc = Convert.ToInt16(newArray[0].ToString()) * 3;
                byThree = byThree + calc;
                newArray.RemoveAt(0);
                if (newArray.Count == 0)
                    break;
                calc = Convert.ToInt16(newArray[0].ToString());
                byOne = byOne + calc;
                newArray.RemoveAt(0);
            }

            var result = byThree + byOne;
            var round = result;
            var check = 0;
            while ((check + round) % 10 != 0)
                check++;


            return check;
        }

        public static BarcodeFormat GetBarcodeType(string barcode)
        {
            return BarcodeFormat.Ean13;
        }
    }
}