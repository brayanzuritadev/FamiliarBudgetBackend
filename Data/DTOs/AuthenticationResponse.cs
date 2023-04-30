using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTOs
{
    public class AuthenticationResponse
    {
        public int UserId { get; set; }
        public int FamilyId { get; set; }
        public int RoleId { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
