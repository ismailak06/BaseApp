using BaseApp.Domain.Common;
using BaseApp.Domain.Common.EntityRules;
using BaseApp.Domain.Interfaces;
using System.Text;
using System.Text.RegularExpressions;

namespace BaseApp.Domain.Entities
{
    public class User : AuditableEntity, ISoftDelete
    {
        public static UserRules rules = new UserRules();
        public User() { }
        public User(string username, string password, string passwordConfirm, string email)
        {
            SetUserName(username);
            SetPassword(password, passwordConfirm);
            SetEmail(email);
        }
        public User(int userId)
        {
            Id = userId;
        }
        public string Username { get; private set; }
        public byte[] PasswordHash { get; private set; }
        public byte[] PasswordSalt { get; private set; }
        public string Email { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime? DeletionDate { get; private set; }

        public void SoftDelete()
        {
            IsDeleted = true;
            DeletionDate = DateTime.Now;
        }

        public static bool IsValidUsername(string username)
        {
            var isMatch = new Regex(rules.UsernameRules.UsernameRegex).IsMatch(username);

            if (!isMatch && username.Length < rules.UsernameRules.MinLength && username.Length > rules.UsernameRules.MaxLength) throw new Exception(string.Format(rules.UsernameRules.ErrorMessage, rules.UsernameRules.MinLength, rules.UsernameRules.MaxLength));

            return true;
        }

        private void SetUserName(string username)
        {
            IsValidUsername(username);
            Username = username;
        }

        public static bool IsValidPassword(string password, string confirmPassword)
        {
            if (password != confirmPassword) throw new Exception(rules.PasswordRules.NotMatchedErrorMessage);
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword)) throw new Exception(rules.PasswordRules.IsNullErrorMessage);
            if (password.Length < rules.PasswordRules.MinLength) throw new Exception(rules.PasswordRules.MinLengthErrorMessage);

            return true;
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void SetPassword(string password, string passwordConfirm)
        {
            IsValidPassword(password, passwordConfirm);

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
        }

        public static bool IsValidEmail(string email)
        {
            if (email.Length > rules.EmailRules.MaxLength) throw new Exception(rules.EmailRules.ErrorMessageForLength);
            if (!new Regex(rules.EmailRules.EmailRegex).IsMatch(email)) throw new Exception(rules.EmailRules.ErrorMessageForRegex);

            return true;
        }

        private void SetEmail(string email)
        {
            IsValidEmail(email);
            Email = email;
        }
    }
}