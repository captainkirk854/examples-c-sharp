using System;

namespace UpperCase.Model
{
    public class TextConverter
    {
        private readonly Func<string, string> pConversionFunc;

        public TextConverter(Func<string, string> incomingConversionFunc)
        {
            pConversionFunc = incomingConversionFunc;
        }

        public string ConvertText(string inputText)
        {
            return pConversionFunc(inputText);
        }
    }
}