using System.ComponentModel.DataAnnotations;
using PhoneNumbers;

namespace Igloocoder.PhoneAnnotation
{
    public class PhoneNumberAttribute:ValidationAttribute
    {
        private readonly string[] _regionsToCheck;

        public PhoneNumberAttribute():this(new [] {"US"})
        {}

        public PhoneNumberAttribute(string regionToCheck):this(new[]{regionToCheck})
        {}

        public PhoneNumberAttribute(string[] regionsToCheck)
        {
            _regionsToCheck = regionsToCheck;
        }

        public override bool IsValid(object value)
        {
            var valueString = value as string;
            if (string.IsNullOrWhiteSpace(valueString))
            {
                return true;
            }

            var numberUtil = PhoneNumberUtil.GetInstance();
            var returnValue = false;
            foreach (var t in _regionsToCheck)
            {
                try
                {
                    var number = numberUtil.Parse(valueString, t);
                    returnValue = numberUtil.IsValidNumber(number);
                    if (returnValue) break;
                }
                catch (NumberParseException)
                {
                }
            }
            return returnValue;
        }
    }
}