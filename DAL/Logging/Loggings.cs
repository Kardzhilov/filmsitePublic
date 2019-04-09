using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DAL
{
    public static class Loggings
    {
        
        public static void LogToDB(LoggTypeDAL logData)
        {
            var db = new DB(false);
            Guid NewID = Guid.NewGuid();
            logData.LogID = NewID;

            try {
                using (db = new DB(false)) {
                    db.Logs.Add(logData);
                    db.SaveChanges();
                }
            } catch (Exception exception){
                var ErrlogData = new LoggTypeDAL()
                {
                    LogID = new Guid(),
                    EventType = "Error",
                    Created_By = "System",
                    LogMessage = exception.Message,
                    Created_date = DateTime.Now
                };
                db.Logs.Add(ErrlogData);
                db.SaveChanges();
            }
        }

        public static List<LoggTypeDAL> GetAllLogs()
        {
            try
            {
                using (var DBConnection = new DB())
                {
                    var logs = DBConnection.Logs.ToList();
                    return logs;
                    
                }
            }
            catch (Exception ex)
            {
                return new List<LoggTypeDAL>();
            }
        }

        public static void LogToFile(LoggTypeDAL logData)
        {
            Guid NewID = Guid.NewGuid();
            logData.LogID = NewID;

            string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(mydocpath, "FilmLogs.txt"), true))
            {
                    outputFile.WriteLine(
                       " LogID: "+logData.LogID + 
                       " Event Type: " + logData.EventType + 
                       " Created By: " + logData.Created_By + 
                       " Message: " + logData.LogMessage +
                       " Date/Time: "+ logData.Created_date);
            }

        }

        public static void LogToBoth(LoggTypeDAL logData)
        {
            LogToDB(logData);
            LogToFile(logData);
        }

        public static void GeneralLog(String Message)
        {
            var logg = new LoggTypeDAL()
            {
                EventType = "General",
                Created_By = "System",
                LogMessage = Message,
                Created_date = DateTime.Now
            };
            LogToBoth(logg);
        }
    }
}
