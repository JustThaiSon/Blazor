using FE.Model;

namespace FE.Service
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAll();
        Task<Employee> GetById(Guid id);

        Task Create(Employee sv);
        Task Update(Guid id, string name, string address, int age);
        Task Delete(Guid id);
    }
}
