using System;
using System.Collections.Generic;
using System.Text;

namespace Asdf.Users.Agregates
{
    public class LoginStateDto
    {
        public Guid Id { get; set; }
        public List<string> Errors { get; set; }
    }
}
