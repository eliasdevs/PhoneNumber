using Numbers;

namespace PhoneNumbers.Providers
{
    public interface IPhoneNumberProvider
    {
        PhoneNumber GePhoneNumber(string phoneNumber, string country);

        string FormatPhoneNumber(string phoneNumber, string country);

        List<CountryInformation> GetCountryCatalog();

        bool IsValidPhoneNumber(string phoneNumber, string country);
    }
}
