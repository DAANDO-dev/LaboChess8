using System.Net.Mail;

namespace LaboChess8.Interface.Repositories
{
    public interface IMailer
    {
        void Send(string to, string subject, string body, params Attachment[] attachments);
    }
}
