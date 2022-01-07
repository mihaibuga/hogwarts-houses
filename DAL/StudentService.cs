using HogwartsPotions.Models.Entities;
using System.Collections.Generic;
using HogwartsPotions.DAL.Interfaces;
using System.Threading.Tasks;

namespace HogwartsPotions.DAL
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
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
            return _studentRepository.Get(studentId);
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
