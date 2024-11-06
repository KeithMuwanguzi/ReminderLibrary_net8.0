using System;
using NotificationReminderLibrary;
using System.Threading;

namespace NotificationReminderTest
{
    internal abstract class Program
    {
        private const string SmtpHost = "smtp.gmail.com";
        private const int SmtpPort = 587;
        private const string SenderEmail = "jeysmuwanguzi@gmail.com";
        private const string SenderPassword = "tisk ulzh ddmc dyrm";

        private static void Main(string[] args)
        {
            
            var api = new LibraryApi(
                smtpServer: SmtpHost, 
                smtpPort: SmtpPort,                              
                smtpUsername: SenderEmail,      
                smtpPassword: SenderPassword,              
                senderEmail: SenderEmail   
            );
            
            var reminderId = api.ScheduleMedication("Paracetamol", "100mg", DateTime.Now.AddSeconds(5), "Shanita","shanitadith@gmail.com");
            
            Thread.Sleep(5000);
            
            api.TriggerReminder(reminderId);
            
            api.ShowLogs();
            
            //Download Rider {JetBrains Rider}
            //Change my email to yours and send me emails = keithjeyson@gmail.com
            //Google Account settings - Search {App passwords}
            
            //Version is V3.5 - .NET9.0
            
            //Look for more functionalities of the system
            //-removing reminder after it has been run
            //Also use a while loop in the testing
            //-to have a system like simulation of the library usage
            
            
            //User manual
            //-Methods in the api - Explain then and explain their usages {In the documentation of the
            //give usage examples before taking it to him - It shows you are better prepared
        }
    }
}