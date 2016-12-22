using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC.Models;
using MVC.Models.Interface;
using MVC.Models.Repository;
using Service.Interface;

namespace Service
{
    public class StructureService : IStructureService
    {
        private readonly IRepository<Structure> repository = new GenericRepository<Structure>();

        public void Create(Structure entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            else
            {
                repository.Create(entity);
            }
        }

        public void Update(Structure entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            else
            {
                repository.Update(entity);
            }
        }

        public void Delete(Guid id)
        {
            if (!IsExists(id))
            {

            }
            else
            {
                var entity = GetById(id);
                repository.Delete(entity);
            }
        }

        public bool IsExists(Guid id)
        {
            return repository.GetAll().Any(x => x.Id == id);
        }

        public Structure GetById(Guid id)
        {
            return repository.Get(x => x.Id == id);
        }

        public IEnumerable<Structure> GetAll()
        {
            return repository.GetAll();
        }
    }
}
