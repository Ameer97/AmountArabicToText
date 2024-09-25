namespace AmountArabicToText
{
    class Converter1
    {
        public static string ConvertToArabic(int amount)
        {
            if (amount == 0)
                return "صفر";

            string[] thousands = { "", "ألف", "ألفان", "آلاف" };
            string[] millions = { "", "مليون", "مليونان", "ملايين" };
            string[] billions = { "", "مليار", "ملياران", "مليارات" };

            string result = "";
            Convert(ref amount, ref result, billions, divitBy: 1000000000);
            Convert(ref amount, ref result, millions, divitBy: 1000000);
            Convert(ref amount, ref result, thousands, divitBy: 1000);

            if (amount > 0)
                result += ConvertHundredsAndBelow(amount, amount);


            if (result.StartsWith("و")) result = result.Substring(1);
            return result;

            static void Convert(ref int amount, ref string result, string[] billions, int divitBy)
            {
                if (amount >= divitBy)
                {
                    result += $"{ConvertHundredsAndBelow(amount / divitBy, amount)}{billions[Form(amount)]} ";
                    amount %= divitBy;
                }
            }

            static string ConvertHundredsAndBelow(int amount, int orginalAmount)
            {
                string[] ones = { "", "واحد", "اثنان", "ثلاثة", "أربعة", "خمسة", "ستة", "سبعة", "ثمانية", "تسعة" };
                string[] teens = { "عشرة", "أحدى عشر", "إثنا عشر", "ثلاثة عشر", "أربعة عشر", "خمسة عشر", "ستة عشر", "سبعة عشر", "ثمانية عشر", "تسعة عشر" };
                string[] tens = { "", "عشرة", "عشرون", "ثلاثون", "أربعون", "خمسون", "ستون", "سبعون", "ثمانون", "تسعون" };
                string[] hundreds = { "", "مائة", "مئتان", "ثلاثمائة", "أربعمائة", "خمسمائة", "ستمائة", "سبعمائة", "ثمانمائة", "تسعمائة" };

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
}
