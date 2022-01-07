using HogwartsPotions.DAL.Interfaces;
using HogwartsPotions.Models;
using HogwartsPotions.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogwartsPotions.DAL
{
    public class StudentRepository : IStudentRepository
    {
        private readonly HogwartsContext _context;

        public StudentRepository(HogwartsContext context)
        {
            _context = context;
        }

        public Task Add(Student item)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(long id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Student> Get(long studentId)
        {
            return _context.Students
                    .Where(student => student.ID == studentId)
                    .SingleAsync();
        }

        public Task<List<Student>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task Update(Student item)
        {
            throw new System.NotImplementedException();
        }
    }
}
