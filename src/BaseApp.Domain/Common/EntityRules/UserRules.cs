using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseApp.Domain.Common.EntityRules
{
    public class UserRules
    {
        public UserRules()
        {
            InitializeRules();
        }
        public UsernameRules UsernameRules { get; private set; }
        public PasswordRules PasswordRules { get; private set; }
        public EmailRules EmailRules { get; private set; }

        private void InitializeRules()
        {
            UsernameRules = new UsernameRules();
            PasswordRules = new PasswordRules();
            EmailRules = new EmailRules();
        }
    }

    public class UsernameRules
    {
        public UsernameRules()
        {
            MinLength = 5;
            MaxLength = 15;
            UsernameRegex = @"^(?=.{3,16}$)(?![_.])(?!.*[_.]{2})[a-zA-Z0-9._]+(?<![_.])$";
            ErrorMessage = "Kullanıcı adı uzunluğu {0} ile {1} karakter arasında olmalıdır. Boşluk ve özel karakter içermemelidir.";
        }
        public int MinLength { get; private set; }
        public int MaxLength { get; private set; }
        public string UsernameRegex { get; private set; }
        public string ErrorMessage { get; private set; }
    }

    public class PasswordRules
    {
        public PasswordRules()
        {
            MinLength = 8;
            MinLengthErrorMessage = "Şifre uzunluğu en az {0} karakter olmalıdır.";
            NotMatchedErrorMessage = "Şifre ve şifre tekrarı eşleşmedi.";
            IsNullErrorMessage = "Şifre ve şifre tekrarı boş geçilemez.";
        }
        public int MinLength { get; private set; }
        public string MinLengthErrorMessage { get; private set; }
        public string NotMatchedErrorMessage { get; private set; }
        public string IsNullErrorMessage { get; private set; }
    }

    public class EmailRules
    {
        public EmailRules()
        {
            MaxLength = 75;
            ErrorMessageForLength = "Email adresi en fazla {0} karakter uzunluğunda olmalıdır.";
            EmailRegex = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            ErrorMessageForRegex = "Lütfen geçerli bir email adresi giriniz.";
        }
        public int MaxLength { get; private set; }
        public string ErrorMessageForLength { get; private set; }
        public string EmailRegex { get; private set; }
        public string ErrorMessageForRegex { get; private set; }
    }
}