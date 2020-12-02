using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asdf.UserDomain.Services.Contexts
{
    public class AuthOptions
    {
        public const string ISSUER = "AsdfAuthServer";
        public const string AUDIENCE = "!!!AsdfServiceFaceName!!!";
        const string KEY = "mysupersecret_secretkey!123";
        public const int LIFETIME = 10000;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
