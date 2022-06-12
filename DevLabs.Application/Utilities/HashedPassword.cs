namespace DevLabs.Application.Utilities
{
    public class HashedPassword
    {
        public string Password { get; private set; }

        public void ChangePassword(string password)
        {
            Password = password;
        }
    }
}