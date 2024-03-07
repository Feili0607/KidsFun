using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;
using System.Text.Json.Serialization;

namespace KidsFun.Models
{
    
    public record KidDetail
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string EmailAddress { get; set; }

        [JsonIgnore]
        public MailAddress Email
        {
            get => new MailAddress(EmailAddress);
        }

        public int Points { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Gender { get; set; }

        public int SchoolYear { get; set; }

    }

 
}