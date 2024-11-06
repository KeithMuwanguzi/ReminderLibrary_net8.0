using System;
using System.Collections.Generic;

namespace NotificationReminderLibrary
{
    public class AdherenceLogger
    {
        private readonly List<AdherenceLog> _adherenceLogs = new List<AdherenceLog>(); //This could also be a database

        public void LogAdherence(int reminderId, AdherenceStatus status)
        {
            _adherenceLogs.Add(new AdherenceLog
            {
                ReminderId = reminderId,
                Status = status,
                Timestamp = DateTime.Now
            });
        }

        public List<AdherenceLog> GetAdherenceLogs()
        {
            return _adherenceLogs;
        }
    }

    public class AdherenceLog
    {
        public int ReminderId { get; set; }
        public AdherenceStatus Status { get; set; }
        public DateTime Timestamp { get; set; }
    }

    public enum AdherenceStatus
    {
        Taken,
        Missed,
        Rescheduled
    }
}