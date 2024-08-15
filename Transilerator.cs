namespace GanjoorTransilerator
{
    public static class Transilerator
    {
        public static string Trasilerate(string input)
        {
            input = CleanTextForTransileration(input);

            //TODO: add transileration code here


            return input;
        }

        public static string CleanTextForTransileration(string text)
        {
            if (string.IsNullOrEmpty(text)) return text;
            return text.Replace("‌", " ")//replace zwnj with space
                       .Replace("ّ", "")//tashdid
                       .Replace("َ", "")//a
                       .Replace("ِ", "")//e
                       .Replace("ُ", "")//o
                       .Replace("ً", "")//an
                       .Replace("ٍ", "")//en
                       .Replace("ٌ", "")//on
                       .Replace("ٔ", "")//ye
                       .Replace("ْ", "")//sokoon
                       ;
        }
    }
}
