namespace CarPeak.Components.Classes
{
    public class User
    {
        public int Id { get; set; }
        public string UserRole { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string UserLicenseCountry { get; set; }
        public string UserLicenseCreDate { get; set; }
        public string UserLicenseExpDate { get; set; }

        public void SetEmptyStrings()
        {
            if(FullName == null) FullName = string.Empty;
            if(Address == null) Address = string.Empty;
            if(Phone == null) Phone = string.Empty;
            if(Email == null) Email = string.Empty;
            if(UserLicenseCountry == null) UserLicenseCountry = string.Empty;
            if (UserLicenseCreDate == null) UserLicenseCreDate = string.Empty;
            if(UserLicenseExpDate == null) UserLicenseExpDate = string.Empty;
        }
    }
}
