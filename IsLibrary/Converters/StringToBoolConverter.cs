namespace IsLibrary.Converters
{
    public class StringToBoolConverter
    {
        public static bool Convert(string text)
        {
            if (text.ToLower() == "true")
                return true;
            else
                return false;
        }
    }
}
