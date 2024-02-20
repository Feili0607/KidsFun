using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;

namespace KidsFun.Models
{
    
    public record KidDetail
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string EmailAddress { get; set; }

        public MailAddress Email
        {
            get => new MailAddress(EmailAddress);
        }

        public int Points { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Gender { get; set; }

        void test(KidDetail entity)
        {
            IEmailSender emailSender;
        }
    }

    public interface IEmailSender
    {
        void SendEmail(MailAddress mail);
    }
}