namespace AmountArabicToText
{
    class Converter1
    {
        // Arabic words for numbers
        static string[] ones = { "", "واحد", "اثنان", "ثلاثة", "أربعة", "خمسة", "ستة", "سبعة", "ثمانية", "تسعة" };
        static string[] teens = { "عشرة", "أحدى عشر", "إثنا عشر", "ثلاثة عشر", "أربعة عشر", "خمسة عشر", "ستة عشر", "سبعة عشر", "ثمانية عشر", "تسعة عشر" };
        static string[] tens = { "", "عشرة", "عشرون", "ثلاثون", "أربعون", "خمسون", "ستون", "سبعون", "ثمانون", "تسعون" };
        static string[] hundreds = { "", "مائة", "مئتان", "ثلاثمائة", "أربعمائة", "خمسمائة", "ستمائة", "سبعمائة", "ثمانمائة", "تسعمائة" };
        static string[] thousands = { "", "ألف", "ألفان", "آلاف" };
        static string[] millions = { "", "مليون", "مليونان", "ملايين" };
        static string[] billions = { "", "مليار", "ملياران", "مليارات" };



        // Function to convert an amount to Arabic text
        public static string ConvertToArabic(int amount)
        {
            if (amount == 0)
                return "صفر";

            var total = ConvertAmount(amount);
            if (total.StartsWith("و")) total = total.Substring(1);
            return total;
            //.Replace("وو", "و")
            ;
        }

        static string ConvertAmount(int amount)
        {
            string result = "";

            if (amount >= 1000000000)
            {
                result += ConvertBillions(amount / 1000000000, amount);
                amount %= 1000000000;
            }

            if (amount >= 1000000)
            {
                result += ConvertMillions(amount / 1000000, amount);
                amount %= 1000000;
            }

            if (amount >= 1000)
            {
                result += ConvertThousands(amount / 1000, amount);
                amount %= 1000;
            }

            if (amount > 0)
            {
                result += ConvertHundredsAndBelow(amount, amount);
            }

            return result;
        }

        static string ConvertBillions(int amount, int orginalAmount)
        {
            return $"{ConvertHundredsAndBelow(amount, orginalAmount)}{billions[Form(amount)]} ";
        }

        static string ConvertMillions(int amount, int orginalAmount)
        {
            return $"{ConvertHundredsAndBelow(amount, orginalAmount)}{millions[Form(amount)]} ";
        }

        static string ConvertThousands(int amount, int orginalAmount)
        {
            return $"{ConvertHundredsAndBelow(amount, orginalAmount)}{thousands[Form(amount)]} ";
        }

        static string ConvertHundredsAndBelow(int amount, int orginalAmount)
        {
            var earseOnes =
                amount != orginalAmount &&
                orginalAmount.ToString().Length % 3 == 1 &&
                (Form(amount) == 1 || Form(amount) == 2);

            string result = "";

            if (amount >= 100)
            {
                result += $"و{hundreds[amount / 100]} ";
                amount %= 100;
            }

            if (amount >= 10 && amount < 20)
            {
                result += $"و{teens[amount - 10]} ";
                amount = 0;
            }

            if (amount % 10 > 0 && !earseOnes)
            {
                result += $"و{ones[amount % 10]} ";
                amount -= (amount % 10);
            }

            if (amount >= 20)
            {
                result += $"و{tens[amount / 10]} ";
                amount %= 10;
            }

            return result;
        }

        static int Form(int amount)
        {
            var index = int.Parse(amount.ToString().Substring(0, 1));
            return index switch
            {
                0 => 1,
                1 => 1,
                2 => 2,
                _ => 3
            };
        }
    }
}
