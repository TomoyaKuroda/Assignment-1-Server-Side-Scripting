using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment1.Models
{
    public class EFAquestioners : IquestionersMock
    {
        private QuestionModel db = new QuestionModel();

        public IQueryable<questioner> questioners { get { return db.questioner; } }

        public IQueryable<question> question { get { return db.question; } }

        public void Delete(questioner questioner)
        {
            db.questioner.Remove(questioner);
        }

        public questioner Save(questioner questioner)
        {
            if (questioner.questioner_id == 0)
            {
                //insert
                db.questioner.Add(questioner);
            }
            else
            {
                //update
                db.Entry(questioner).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            return questioner;
        }
    }
}