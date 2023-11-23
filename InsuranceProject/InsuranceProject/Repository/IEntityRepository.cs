namespace InsuranceProject.Repository
{
    public interface IEntityRepository<T>
    {
        public IQueryable<T> Get();

        public T Get(int id);

        public int Add(T entity);
        public T Update(T entity);
        public void Delete(T entity);
    }
}
