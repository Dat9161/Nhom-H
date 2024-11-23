using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;
using KoiFarmShop.Services.Interfaces;

namespace KoiFarmShop.Services
{
    public class CustomerServices : ICustomerServices
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerServices(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        // Đăng nhập
        public async Task<Customer?> LoginAsync(string email, string password)
        {
            var customer = await _customerRepository.GetCustomerByEmailAsync(email);
            if (customer == null || customer.Password != password)
            {
                return null; // Kiểm tra mật khẩu
            }

            return customer; // Trả về khách hàng nếu đăng nhập thành công
        }

        // Đăng ký
        public async Task<bool> RegisterAsync(Customer customer)
        {
            // Kiểm tra xem email đã tồn tại chưa
            var existingCustomer = await _customerRepository.GetCustomerByEmailAsync(customer.Email);
            if (existingCustomer != null)
            {
                return false; // Nếu email đã tồn tại, không thể đăng ký
            }

            await _customerRepository.AddCustomerAsync(customer);
            return true; // Đăng ký thành công
        }

        // Cập nhật thông tin khách hàng
        public async Task<bool> UpdateCustomerAsync(Customer customer)
        {
            // Kiểm tra xem khách hàng có tồn tại trong CSDL không
            var existingCustomer = await _customerRepository.GetCustomerByEmailAsync(customer.Email);
            if (existingCustomer == null)
            {
                return false; // Nếu không tìm thấy khách hàng
            }

            // Cập nhật thông tin khách hàng
            await _customerRepository.UpdateCustomerAsync(customer);
            return true;
        }

        // Lấy thông tin khách hàng theo email
        public async Task<Customer?> GetCustomerByEmailAsync(string email)
        {
            return await _customerRepository.GetCustomerByEmailAsync(email);
        }
    }
}
