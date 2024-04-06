using Numbers;

namespace PhoneNumbers.Providers.UniTest
{
    public class PhoneNumberTest
    {
        private IPhoneNumberProvider _phoneNumberProvider;
        [SetUp]
        public void Setup()
        {
            _phoneNumberProvider = new PhoneNumberProvider();
        }

        [Test]
        public void IsValidNumeberTest()
        {
            string phoneNumber = "78585225";
            string country = "SV";
            bool isValid = _phoneNumberProvider.IsValidPhoneNumber(phoneNumber, country);
            Assert.IsTrue(isValid, "The phone number is not valid.");
        }

        [Test]
        public void GetCountryCatalog_ReturnsValidCountryList()
        {

            List<CountryInformation> countryList = _phoneNumberProvider.GetCountryCatalog();
            // Assert
            Assert.IsNotNull(countryList);
            Assert.IsNotEmpty(countryList);
            CountryInformation? elSalvador = countryList.SingleOrDefault(c => c.RegionCode == "SV");
            Assert.IsNotNull(elSalvador, "El Salvador is not included in the list.");
            Assert.That(elSalvador.CountryCode, Is.EqualTo("503"), "Text strings are not equal");
        }
    }
}