using EducationalPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalPortal.Domain.Interfaces.Repositories
{
    public interface IAuthorRepository
    {
        Author Create(Author obj);

        Author GetById(int id);

        bool Update(Author obj);

        void Delete(int id);
    }
}
