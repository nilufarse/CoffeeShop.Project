using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using CoffeeShop.DAL.Data;
using CoffeeShop.DAL.DBModel;
using CoffeeShop.BLL.Services.Inerfaces;
using System.Threading.Tasks;
using CoffeeShop.DAL.Dtos;

namespace CoffeeShop.UI.Controllers
{
    //[Authorize(Roles = "Operator")]
    public class ContactController : Controller
    {
        private readonly IGenericService<ContactDto, Contact> _service;

        public ContactController(IGenericService<ContactDto, Contact> service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var contacts = await _service.GetListAsync();
            return View(contacts);
        }

        public async Task<IActionResult> AnswerAsync(int id)
        {
            var contacts = await _service.GetByIdAsync(id);
            return View(contacts);
        }

        [HttpPost]
        public IActionResult Answer(ContactDto contacts)
        {
            if (ModelState.IsValid)
            {

                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
                var configuration = builder.Build();
                var host = configuration["Gmail:Host"];
                var port = int.Parse(configuration["Gmail:Port"]);
                var username = configuration["Gmail:Username"];
                var password = configuration["Gmail:Password"];
                var displayName = configuration["Gmail:DisplayName"];

                var enable = bool.Parse(configuration["Gmail:SMTP:starttls:enable"]);

                MailMessage mail = new MailMessage($"{contacts.Email}", $"{username}");
                mail.Subject = displayName;


                mail.Body = $@"
               <html>
               <head> 
               <style>
              

              </style>
              </head>
              <body>
              <h6>Email: {contacts.Email} </h6>
              <h6>Name: {displayName}</h6> 
               <p>{contacts.Answer}</p>
            </body>
            </html>";
                mail.IsBodyHtml = true;




                SmtpClient smtpClient = new SmtpClient(host, port);
                smtpClient.Credentials = new NetworkCredential(username, password);
                smtpClient.EnableSsl = true;
                smtpClient.Send(mail);


                ViewBag.msg = "Your message has been sent successfully";
            }
            return View(contacts);
        }
    }
}
