
using Numbers;
using System.Globalization;
using System.Linq;

namespace PhoneNumbers.Providers
{
    public class PhoneNumberProvider : IPhoneNumberProvider
    {
        public PhoneNumber GePhoneNumber(string phoneNumber, string country)
        {
            return PhoneNumberUtil.GetInstance().Parse(phoneNumber, country);
        }

        public string FormatPhoneNumber(string phoneNumber, string country)
        {
            return PhoneNumberUtil.GetInstance().Format(GePhoneNumber(phoneNumber, country), PhoneNumberFormat.INTERNATIONAL);
        }

        public List<CountryInformation> GetCountryCatalog()
        {
            PhoneNumberUtil phoneUtil = PhoneNumberUtil.GetInstance();

            HashSet<string> regionCodes = phoneUtil.GetSupportedRegions();
            return regionCodes.Select(regionCode => new CountryInformation(
                                        RegionCode: regionCode,
                                        Name: GetNameCountry(regionCode),
                                        CountryCode: phoneUtil.GetCountryCodeForRegion(regionCode).ToString(),
                                        Icon: GetIconByCountry(regionCode))).ToList();
        }

        string? GetNameCountry(string regionCode)
        {
            try
            {
                return new RegionInfo(regionCode).DisplayName;
            }
            catch { }
            return null;
        }

        string GetIconByCountry(string regionCode) => $"https://flagpedia.net/data/flags/mini/{regionCode.ToLower()}.png";

        public bool IsValidPhoneNumber(string phoneNumber, string country)
        {
            return PhoneNumberUtil.GetInstance().IsValidNumber(GePhoneNumber(phoneNumber, country));
        }
    }
}
