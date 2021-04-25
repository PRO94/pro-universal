namespace Pro.Universal.Data.Repositories.Interfaces
{
    public interface IRepositoryWrapper
    {
        ICustomerRepository Customer { get; }
        IRoleRepository Role { get; }
        void Save();
    }
}