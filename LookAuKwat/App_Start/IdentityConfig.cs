using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using LookAuKwat.Models;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Diagnostics;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace LookAuKwat
{
    public class EmailService : IIdentityMessageService
    {
        public async Task SendAsync(IdentityMessage message)
        {
            // Indiquez votre service de messagerie ici pour envoyer un e-mail.
            await configSendGridasync(message);
        }

        private async Task configSendGridasync(IdentityMessage message)
        {
            
            var apikey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");       
            var client = new SendGridClient(apikey);
            var from = new EmailAddress("contact@lookaukwat.com", "(Ne pas répondre ici)");
            var subject = message.Subject;
            var to = new EmailAddress(message.Destination);
            var plainTextContent = message.Body;

            var htmlContent = message.Body;

            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

            // Send the email.
            if (client != null)
            {

                await client.SendEmailAsync(msg);

            }
            else
            {
                Trace.TraceError("Failed to create Web transport.");
                await Task.FromResult(0);
            }
        }
    }


    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Connectez votre service SMS ici pour envoyer un message texte.

            var accountSid = System.Configuration.ConfigurationManager.AppSettings["SMSAccountIdentification"];
            var authToken = System.Configuration.ConfigurationManager.AppSettings["SMSAccountPassword"];
            var fromNumber = System.Configuration.ConfigurationManager.AppSettings["SMSAccountFrom"];

            TwilioClient.Init(accountSid, authToken);
            if (message.Destination.StartsWith("+"))
            {

                try
                {
                    MessageResource result = MessageResource.Create(
               new PhoneNumber(message.Destination),
               from: new PhoneNumber(fromNumber),
               body: message.Body
               );



                    //Status is one of Queued, Sending, Sent, Failed or null if the number is not valid
                    Trace.TraceInformation(result.Status.ToString());
                }
                catch (Exception e) { Console.WriteLine(e.ToString()); }
            }
            //Twilio doesn't currently have an async API, so return success.
            return Task.FromResult(0);



            //var soapSms = new LookAuKwat.ASPSMSX2.ASPSMSX2SoapClient("ASPSMSX2Soap");
            //soapSms.SendSimpleTextSMS(
            //    System.Configuration.ConfigurationManager.AppSettings["ASPSMSUSERKEY"],
            //    System.Configuration.ConfigurationManager.AppSettings["ASPSMSPASSWORD"],
            //    message.Destination,
            //    System.Configuration.ConfigurationManager.AppSettings["ASPSMSORIGINATOR"],
            //    message.Body);
            //soapSms.Close();
            //return Task.FromResult(0);
        }
    }

    // Configurer l'application que le gestionnaire des utilisateurs a utilisée dans cette application. UserManager est défini dans ASP.NET Identity et est utilisé par l'application.
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context) 
        {
            var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>()));
            // Configurer la logique de validation pour les noms d'utilisateur
            manager.UserValidator = new UserValidator<ApplicationUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configurer la logique de validation pour les mots de passe
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
               // RequireNonLetterOrDigit = true,
               // RequireDigit = true,
               // RequireLowercase = true,
                //RequireUppercase = true,
            };

            // Configurer les valeurs par défaut du verrouillage de l'utilisateur
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            // Inscrire les fournisseurs d'authentification à 2 facteurs. Cette application utilise le téléphone et les e-mails comme procédure de réception de code pour confirmer l'utilisateur
            // Vous pouvez écrire votre propre fournisseur et le connecter ici.
            manager.RegisterTwoFactorProvider("Code téléphonique ", new PhoneNumberTokenProvider<ApplicationUser>
            {
                MessageFormat = "Votre code de sécurité est {0}"
            });
            manager.RegisterTwoFactorProvider("Code d'e-mail", new EmailTokenProvider<ApplicationUser>
            {
                Subject = "Code de sécurité",
                BodyFormat = "Votre code de sécurité est {0}"
            });
            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = 
                    new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"))
                    {
                        TokenLifespan = TimeSpan.FromHours(3)
                    };
            }
            return manager;
        }
    }

    // Configurer le gestionnaire de connexion d'application qui est utilisé dans cette application.
    public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
        {
            return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }
    }
}
