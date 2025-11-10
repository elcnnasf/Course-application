using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Interface
{
    public interface IStudentRepository<T> where T : BaseEntity
    {
        void Create(T data);
        void Update(T data, int id);
        void Delete(T data, int id);
        T GetById(int id);
        List<T> GetAll();
        List<T> GetByAge(int age);
        List<T> GetByGroupId(int groupId);
        List<T> SearchByNameOrSurname(string text);
    }
}
