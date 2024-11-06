# NotificationReminderLibrary

A C# library designed for scheduling notifications and reminders, specifically useful in applications requiring patient medication reminders. This library currently supports sending email notifications to users at scheduled times, with adherence tracking.

## Features

- **Reminder Scheduling**: Schedule reminders with details like medication name, dosage, and reminder time.
- **Email Notifications**: Sends email reminders to patients when medication is due.
- **Adherence Logging**: Logs adherence with statuses (Taken, Missed, Rescheduled) to track medication compliance.

## Getting Started

### Prerequisites

- **.V3.5 SDK** or later
- **SMTP Server** for sending email notifications (e.g., Gmail, SendGrid, or any SMTP-compatible email provider)

### Installation

1. Clone this repository or download the source code.
2. Open the solution in **Visual Studio**.
3. Build the solution to restore any dependencies and ensure the project is configured correctly.

### Project Structure

- `LibraryAPI`: The main API interface to interact with the library.
- `ReminderScheduler`: Manages reminder scheduling, including adding, updating, and removing reminders.
- `NotificationService`: Sends email notifications for reminders.
- `AdherenceLogger`: Logs adherence actions, such as "Taken," "Missed," or "Rescheduled."

### Database Integration (Optional)
For production usage, you may want to save reminder and adherence data to a database rather than relying on in-memory storage. Consider setting up a simple database integration by updating the ReminderScheduler and AdherenceLogger to interface with a database, using Entity Framework or Dapper.

### Configuration

In order to send email notifications, you’ll need SMTP credentials. Update the test project or your application with the appropriate SMTP details:

```csharp
var api = new LibraryAPI(
    smtpServer: "smtp.your-email-provider.com",  // Replace with your SMTP server
    smtpPort: 587,                               // Replace with your SMTP port
    smtpUsername: "your-email@domain.com",       // Replace with your email
    smtpPassword: "your-email-password",         // Replace with your email password
    senderEmail: "your-email@domain.com"         // Replace with your sender email
);
