using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAssessment.Models
{
    public class Rented
    {
        [Key]
        public int RId { get; set; }
        public Books BookId { get; set; }
        public Users UsersId { get; set; }

        public string DeleteMe { get; set; }
    }
}
