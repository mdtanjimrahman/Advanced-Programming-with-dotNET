using AutoMapper;
using BLL.DTOs;
using DAL.EF;
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

        public List<StudentDTO> GetAll()
        {
            var data = repo.Get();
            var mapper = GetMapper();
            return mapper.Map<List<StudentDTO>>(data);
        }

        public StudentDTO GetbyId(int id)
        {
            var data = repo.GetId(id);
            var mapper = GetMapper();
            return mapper.Map<StudentDTO>(data);
        }

        public StudentDTO Scholar()
        {
            var data = (from s in repo.Get()
                        where s.Cgpa >= 3.75
                        select s).ToList();

            var Mapper = GetMapper();
            return Mapper.Map<StudentDTO>(data);
        }
    }
}
