using System.ComponentModel.DataAnnotations;

namespace GerenciamentoDeContatosWeduka.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }

        public List<Contact>? Contacts { get; set; }
    }

    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Type { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Value { get; set; }

        public int PersonId { get; set; }

    }
}
