namespace PhoneNumbers.Providers
{
    internal class PhoneNumberProvider : IPhoneNumberProvider
    {
        public string GetAreaCode(string phoneNumber, string country)
        {
            PhoneNumberUtil phoneUtil = PhoneNumberUtil.GetInstance();

            return phoneUtil.Parse(phoneNumber, country).CountryCode.ToString();
        }
    }
}
