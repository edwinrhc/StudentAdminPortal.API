﻿using Microsoft.AspNetCore.Mvc;
using StudentAdminPortal.API.DomainModels;
using StudentAdminPortal.API.Repositories;
using System.Collections.Generic;

namespace StudentAdminPortal.API.Controllers
{
    [ApiController]
    public class StudentsController : Controller
    {
        private readonly IStudentRepository studentRepository;

        public StudentsController(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        [HttpGet]
        [Route("[controller]")]
        public IActionResult GetAllStudents()
        {

            var students = studentRepository.GetStudents();

            var domainModelsStudents = new List<Student>();

            foreach (var student in students)
            {
                domainModelsStudents.Add(new Student
                {
                    Id = student.Id,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    DateOfBirth = student.DateOfBirth,
                    Email = student.Email,
                    Mobile = student.Mobile,
                    ProfileImageUrl = student.ProfileImageUrl,
                    GenderId = student.GenderId,
                    Address = new Address
                    {
                        Id = student.Address.Id,
                        PhysicalAddress = student.Address.PhysicalAddress,
                        PostalAddress = student.Address.PostalAddress
                    },
                    Gender = new Gender
                    {
                        Id = student.Gender.Id,
                        Description = student.Gender.Description
                    }
                });
            }
            
            return Ok(domainModelsStudents);
        }

    }
}
