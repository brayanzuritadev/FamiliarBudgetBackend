using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTOs
{
    public class FamilyCreation
    {
        [Required]
        public string FamilyName { get; set; }
    }
}
