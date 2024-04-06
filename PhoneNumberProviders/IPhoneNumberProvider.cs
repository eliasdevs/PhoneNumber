namespace PhoneNumbers.Providers
{
    public interface IPhoneNumberProvider
    {
        string GetAreaCode(string phoneNumber, string country);
    }
}
