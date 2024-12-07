using FE.Model;

namespace FE.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient _httpClient;
        public EmployeeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task Create(Employee sv)
        {
            await _httpClient.PostAsJsonAsync("api/Employee/Create", sv);
        }

        public async Task Delete(Guid id)
        {
            await _httpClient.DeleteAsync($"api/Employee/Delete/{id}");
        }

        public async Task<List<Employee>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<List<Employee>>("api/Employee/GetAll");
        }

        public async Task<Employee> GetById(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<Employee>($"api/Employee/GetById/{id}");
        }

        public async Task Update(Guid id, string name, string address, int age)
        {
            await _httpClient.GetAsync($"api/Employee/Update/{id}?name={name}&address={address}&age={age}");
        }
    }
}
