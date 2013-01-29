namespace KataRomanNumerals
{
    public class RomanNumeralConverter
    {
        public string Convert(int number)
        {
            if (number >= 1000) return "M" + Convert(number - 1000);
            if (number >= 900) return "CM" + Convert(number - 900);
            if (number >= 500) return "D" + Convert(number - 500);
            if (number >= 400) return "CD" + Convert(number - 400);
            if (number >= 100) return "C" + Convert(number - 100);
            if (number >= 90) return "XC" + Convert(number - 90);
            if (number >= 50) return "L" + Convert(number - 50);
            if (number >= 40) return "XL" + Convert(number - 40);
            if (number >= 10) return "X" + Convert(number - 10);
            if (number >= 9) return "IX" + Convert(number - 9);
            if (number >= 5) return "V" + Convert(number - 5);
            if (number >= 4) return "IV" + Convert(number - 4);
            if (number >= 1) return "I" + Convert(number - 1);
            return string.Empty;
        }
    }
}
