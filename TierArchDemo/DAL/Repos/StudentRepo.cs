using DAL.EF;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repos
{
    public class StudentRepo
    {
        TierArchContext db;
        public StudentRepo(TierArchContext db)
        {
            this.db = db;
        }

        public List<Student> Get()
        {
            return db.Students.ToList();
        }

        public Student GetId(int id)
        {
            return db.Students.Find(id);
        }
    }
}
