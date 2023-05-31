global using MimeKit;
global using MailKit.Net.Smtp;
global using MimeKit.Text;



namespace SprintathonAPI.Controllers
{

    [ApiController]
    [Route("/[Controller]")]
    public class MailController : ControllerBase
    {

        public MailController()
        {
        }


        [HttpGet]
        public async Task<ActionResult> SendMail(MailMessage mail)
        {
            string failed = null;
            var mailMessage = new MimeMessage();
            mailMessage.To.Add(MailboxAddress.Parse(mail.Email));
            mailMessage.From.Add(MailboxAddress.Parse("ittai1tumelo@gmail.com"));
            mailMessage.Subject = mail.Subject;
            mailMessage.Body = new TextPart(TextFormat.Html)
            {
                Text = mail.Message
            };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate("ittai1tumelo@gmail.com", "oboesevbwetsuien");

            try
            {
                var response = await smtp.SendAsync(mailMessage);

            }
            catch (Exception ex)
            {
                failed = ex.Message;
            }
            finally
            {
                smtp.Disconnect(true);

            }
            if (failed is null)

                return Ok("Success");
            else return BadRequest(failed);


        }
    }
}
