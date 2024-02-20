using System.Net.Mail;

namespace KidsFun.Models
{
    
    public record KidDetail
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
       
        public DateTime BirthDate { get; set; }

        public int Points { get; set; }
    }
}