using Model;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DAL.Repositories
{
    public class FAQDAL
    {
        public bool Create(FAQModelDAL Question)
        {
            try
            {
                using (var DBConnection = new DB())
                {
                    DBConnection.FAQs.Add(Question);
                    DBConnection.SaveChanges();
                    Loggings.GeneralLog("Created User Question with ID: " + Question.ID);
                    return true;
                }
            }
            catch (Exception ex)
            {
                var logg = new LoggTypeDAL()
                {
                    EventType = "Exception",
                    Created_By = "System",
                    LogMessage = ex.ToString(),
                    Created_date = DateTime.Now
                };
                Loggings.LogToBoth(logg);
                return false;
            }
        }
        public bool UpVote(int IDin) {
            try
            {
                using (var DBConnection = new DB())
                {
                    var question = new FAQModelDAL();
                    question.ID = IDin;
                    var questionFound = DBConnection.FAQs.Find(question.ID);

                    if (questionFound == null)
                    {
                        Loggings.GeneralLog("Could not find Question with ID: " + question.ID);
                        return false;
                    }

                    questionFound.Score = questionFound.Score + 1;
                    DBConnection.SaveChanges();
                    Loggings.GeneralLog("Updated Question with ID: " + question.ID);
                    return true;
                }
            }
            catch (Exception ex)
            {
                var logg = new LoggTypeDAL()
                {
                    EventType = "Exception",
                    Created_By = "System",
                    LogMessage = ex.ToString(),
                    Created_date = DateTime.Now
                };
                Loggings.LogToBoth(logg);
                return false;
            }
        }

        public bool DownVote(int IDin)
        {
            try
            {
                using (var DBConnection = new DB())
                {
                    var question = new FAQModelDAL();
                    question.ID = IDin;
                    var questionFound = DBConnection.FAQs.Find(question.ID);

                    if (questionFound == null)
                    {
                        Loggings.GeneralLog("Could not find Question with ID: " + question.ID);
                        return false;
                    }

                    questionFound.Score = questionFound.Score - 1;
                    DBConnection.SaveChanges();
                    Loggings.GeneralLog("Updated Question with ID: " + question.ID);
                    return true;
                }
            }
            catch (Exception ex)
            {
                var logg = new LoggTypeDAL()
                {
                    EventType = "Exception",
                    Created_By = "System",
                    LogMessage = ex.ToString(),
                    Created_date = DateTime.Now
                };
                Loggings.LogToBoth(logg);
                return false;
            }
        }
        public List<FAQModelDAL> GetAll()
        {
            try
            {
                using (var DBConnection = new DB())
                {
                    var allQuestions = DBConnection.FAQs.ToList();
                    return allQuestions;
                }
            }
            catch (Exception ex)
            {
                var logg = new LoggTypeDAL()
                {
                    EventType = "Exception",
                    Created_By = "System",
                    LogMessage = ex.ToString(),
                    Created_date = DateTime.Now
                };
                Loggings.LogToBoth(logg);
                return null;
            }
        }

    }
}
