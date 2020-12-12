using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISP_Lab15
{
    public class PhoneNumber
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Number { get; set; }
        [Required]
        public User Owner { get; set; }

        public override string ToString()
        {
            return string.Format("PhoneNumber({0}, {1})", Id, Number);
        }
    }
}
