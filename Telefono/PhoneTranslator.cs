using System;
using System.Text;

namespace Telefono
{
    public class PhoneTranslator
    {
        string Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string Numbers = "22233344455566677778889999";
        public string ToNumber(string alfanumericPhoneNumber)
        {
            var NumericPhoneNumber = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(alfanumericPhoneNumber))
            {
                alfanumericPhoneNumber = alfanumericPhoneNumber.ToUpper(); foreach (var c in alfanumericPhoneNumber)
                {
                    var Index = Letters.IndexOf(c); if (Index >= 0)
                    {
                        // Es una letra, obtener el dígito equivalente
                        NumericPhoneNumber.Append(Numbers[Index]);
                    }
                    else
                    {
                        NumericPhoneNumber.Append(c);
                    }
                }
            }
            return NumericPhoneNumber.ToString();
        }
        public PhoneTranslator()
        {
        }
    }
}
