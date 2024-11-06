using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace NotificationReminderLibrary
{
    public class NotificationService
    {
        private readonly string _smtpServer;
        private readonly int _smtpPort;
        private readonly string _smtpUsername;
        private readonly string _smtpPassword;
        private readonly string _senderEmail;
        
        public NotificationService(string smtpServer, int smtpPort, string smtpUsername, string smtpPassword, string senderEmail)
        {
            _smtpServer = smtpServer;
            _smtpPort = smtpPort;
            _smtpUsername = smtpUsername;
            _smtpPassword = smtpPassword;
            _senderEmail = senderEmail;
        }

        public void SendEmailNotification(Reminder reminder)
        {
            try
            {
                const string templatePath = @"D:\code\C#\NotificationReminderLibrary\NotificationReminderLibrary\email_template.html";
                var htmlBody = File.ReadAllText(templatePath);

                var emailNameList = reminder.PatientName.Split(' ');
                
                var emailName = emailNameList.Length > 1 ? emailNameList[1] : emailNameList[0];
                
                htmlBody = htmlBody.Replace("{{patientName}}", emailName)
                    .Replace("{{medicationName}}", reminder.MedicationName)
                    .Replace("{{dosage}}", reminder.Dosage)
                    .Replace("{{time}}", reminder.ReminderTime.ToString(CultureInfo.CurrentCulture))
                    .Replace("{{hospitalName}}", "Edith General Hospital")
                    .Replace("{{currentYear}}", DateTime.Now.Year.ToString());
                
                var smtpClient = new SmtpClient(_smtpServer, _smtpPort)
                {
                    Credentials = new NetworkCredential(_smtpUsername, _smtpPassword),
                    EnableSsl = true,
                };

                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress(_senderEmail),
                    Subject = "Medication Alert",
                    Body = htmlBody,
                    IsBodyHtml = true
                };
                mailMessage.To.Add(reminder.PatientEmail);

                smtpClient.Send(mailMessage);
                Console.WriteLine($"Email notification sent to {reminder.PatientEmail} for reminder: {reminder.MedicationName} at {reminder.ReminderTime}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to send email notification: {ex.Message}");
            }
        }
    }
}
