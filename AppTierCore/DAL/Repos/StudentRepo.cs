using DAL.EF;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repos
{
    public class StudentRepo
    {
        CoreUMSContext db;
        public StudentRepo(CoreUMSContext db)
        {
            this.db = db;
        }

        // GET ALL
        public List<Student> GetAll()
        {
            return db.Students.ToList();
        }

        // GET BY ID
        public Student Get(int id)
        {
            return db.Students.Find(id);
        }

        // CREATE
        public bool Create(Student student)
        {
            db.Students.Add(student);
            return db.SaveChanges() > 0;
        }

        // UPDATE
        public bool Update(Student student)
        {
            var existing = db.Students.Find(student.Id);
            if (existing == null) return false;

            existing.Name = student.Name;
            existing.Cgpa = student.Cgpa;

            return db.SaveChanges() > 0;
        }

        // DELETE
        public bool Delete(int id)
        {
            var student = db.Students.Find(id);
            if (student == null) return false;

            db.Students.Remove(student);
            return db.SaveChanges() > 0;
        }
    }

}
