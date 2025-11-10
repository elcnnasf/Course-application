using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IGroupService
    {
        Groups Create(Groups group);
        Groups Update(int id, Groups group);
        Groups Get(int id);
        List<Groups> GetAll();
        void Delete(int id);
    }
}
