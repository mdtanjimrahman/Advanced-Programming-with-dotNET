using AutoMapper;
using BLL.DTOs;
using DAL.EF.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class StudentService
    {
        StudentRepo repo;
        public StudentService(StudentRepo repo)
        {
            this.repo = repo;
        }

        Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Student, StudentDTO>().ReverseMap();
            });
            return new Mapper(config);
        }

        // GET ALL
        public List<StudentDTO> GetAllStudent()
        {
            var data = repo.GetAll();
            return GetMapper().Map<List<StudentDTO>>(data);
        }

        // GET BY ID
        public StudentDTO GetStudent(int id)
        {
            var student = repo.Get(id);
            if (student == null) return null;

            return GetMapper().Map<StudentDTO>(student);
        }

        // CREATE
        public bool Create(StudentDTO s)
        {
            var student = GetMapper().Map<Student>(s);
            return repo.Create(student);
        }

        // UPDATE
        public bool Update(StudentDTO s)
        {
            var student = GetMapper().Map<Student>(s);
            return repo.Update(student);
        }

        // DELETE
        public bool Delete(int id)
        {
            return repo.Delete(id);
        }
    }
}
