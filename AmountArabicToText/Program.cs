namespace AmountArabicToText
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = "";
            result += 123456789 + "\n" + Converter1.ConvertToArabic(123456789) + "\n\n\n";
            result += 70019 + "\n" + Converter1.ConvertToArabic(70019) + "\n\n\n";
            result += 5800 + "\n" + Converter1.ConvertToArabic(5800) + "\n\n\n";
            result += 12 + "\n" + Converter1.ConvertToArabic(12) + "\n\n\n";
            result += 50 + "\n" + Converter1.ConvertToArabic(50) + "\n\n\n";
            result += 140 + "\n" + Converter1.ConvertToArabic(140) + "\n\n\n";
            result += 99 + "\n" + Converter1.ConvertToArabic(99) + "\n\n\n";
            result += 7785214 + "\n" + Converter1.ConvertToArabic(7785214) + "\n\n\n";
            result += 5 + "\n" + Converter1.ConvertToArabic(5) + "\n\n\n";
            result += 1 + "\n" + Converter1.ConvertToArabic(1) + "\n\n\n";
            result += 21 + "\n" + Converter1.ConvertToArabic(21) + "\n\n\n";
            result += 2147483647 + "\n" + Converter1.ConvertToArabic(2147483647) + "\n\n\n";
            result += 2000 + "\n" + Converter1.ConvertToArabic(2000) + "\n\n\n";
            Console.ReadKey();
        }
    }
}
