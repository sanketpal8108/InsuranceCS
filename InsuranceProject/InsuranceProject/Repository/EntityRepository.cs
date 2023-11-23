using InsuranceProject.Data;
using Microsoft.EntityFrameworkCore;

namespace InsuranceProject.Repository
{
    public class EntityRepository<T> : IEntityRepository<T> where T : class
    {
        private MyContext _context;
        private readonly DbSet<T> _table;

        public EntityRepository(MyContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public IQueryable<T> Get()
        {
            return _table.AsQueryable();
        }

        public T Get(int id)
        {
            var entity = _table.Find(id);
            if (entity != null)
                _context.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public int Add(T entity)
        {
            var newUser = _table.Add(entity);
            return _context.SaveChanges();

        }

        public T Update(T entity)
        {
            _table.Update(entity);
            _context.SaveChanges();
            return entity;
        }
        public void Delete(T entity)
        {
            //soft del ---->isActive exists?
            _context.Entry(entity).State = EntityState.Modified;
            var isActiveProperty = entity.GetType().GetProperty("IsActive");

            isActiveProperty.SetValue(entity, false);
            _table.Update(entity);

            _context.SaveChanges();
        }

       
    }
}
