using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class EmailSender
    {
        public static void EnviarEmailRecuperacion(string email, string password)
        {
            const string EmailOrigen = "gestionescolar1234@gmail.com";
            const string Contraseña = "gestionescolar1901";
            MailMessage oMailMessage = new MailMessage(
                EmailOrigen,
                email,
                "Solicitud de Recuperacion de Contraseña",
                $"<p>Hola {email}, usted solicito su contraseña</p><br>" +
                $"<p>Su contraseña es: {password}</p><br>" +
                "<p>Si usted no solicito esto, desestime el mensaje.</p><br>");

            oMailMessage.IsBodyHtml = true;

            SmtpClient oSmtpClient = new SmtpClient("smtp.gmail.com")
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Port = 587,
                Credentials = new System.Net.NetworkCredential(EmailOrigen, Contraseña)
            };

            oSmtpClient.Send(oMailMessage);

            oSmtpClient.Dispose();
        }

        public static void EnviarEmailRegistro(string email, string password)
        {
            const string EmailOrigen = "gestionescolar1234@gmail.com";
            const string Contraseña = "gestionescolar1901";
            MailMessage oMailMessage = new MailMessage(
                EmailOrigen,
                email,
                "Registro en Gestion Escolar",
                $"<p>Hola {email}, usted se ha registrado correctamente y se le ha asignado una contraseña aleatoria</p><br>" +
                $"<p>Su contraseña es:  {password}</p><br>" +
                "<p>Una vez ingresado al sistema, se le pedira crear una nueva</p><br>");

            oMailMessage.IsBodyHtml = true;

            SmtpClient oSmtpClient = new SmtpClient("smtp.gmail.com")
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Port = 587,
                Credentials = new System.Net.NetworkCredential(EmailOrigen, Contraseña)
            };

            oSmtpClient.Send(oMailMessage);

            oSmtpClient.Dispose();
        }
    }
}
