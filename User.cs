using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISP_Lab15
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        public List<PhoneNumber> Phones { get; set; } = new List<PhoneNumber>();

        public override string ToString()
        {
            return string.Format("User({0}, {1}, {2}, {3})", Id, FirstName, LastName, Birthday.ToShortDateString());
        }
    }
}
