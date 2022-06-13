using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace DevLabs.Application.Utilities.Hash
{
    public static class PasswordHasherManager
    {
        public static HashedPassword ConvertPasswordToHash(string password)
        {
            HashedPassword hashedPassword = new();
            PasswordHasher<HashedPassword> passwordHasher = new();
            hashedPassword.ChangePassword(passwordHasher.HashPassword(hashedPassword, password));
            return hashedPassword;
        }

        public static async Task<bool> ValidatePassword(string hash, string password)
        {
            HashedPassword hashedPassword = new();
            PasswordHasher<HashedPassword> passwordHasher = new();
            var status = passwordHasher.VerifyHashedPassword(hashedPassword, hash, password);
            await Task.CompletedTask;

            return status switch
            {
                PasswordVerificationResult.Failed => false,
                PasswordVerificationResult.Success => true,
                PasswordVerificationResult.SuccessRehashNeeded => true,
                _ => throw new InvalidOperationException(),
            };
        }
    }
}