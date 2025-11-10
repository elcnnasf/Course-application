using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IStudentService
    {
        Student Create(Student student);
        Student Update(int id, Student student);
        void Delete(int id);
        Student Get(int id);
        List<Student> GetAll();
        List<Student> GetAllByGroupId(int id);
        List<Student> SearchByNameOrSurname(string keyword);
    }
}
