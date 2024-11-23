using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiFarmShop.Services.Interfaces;
using System.Security.Claims;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.WebApplication.Pages
{
    public class taikhoanModel : PageModel
    {
        private readonly ICustomerServices _customerServices;

        public taikhoanModel(ICustomerServices customerServices)
        {
            _customerServices = customerServices;
        }

        [BindProperty]
        public string IdUser { get; set; } = string.Empty;

        [BindProperty]
        public string Email { get; set; } = string.Empty;

        [BindProperty]
        public string Name { get; set; } = string.Empty;

        [BindProperty]
        public string Phone { get; set; } = string.Empty;

        [BindProperty]
        public string? Birthday { get; set; }

        [BindProperty]
        public string? Address { get; set; }

        [BindProperty]
        public string? Password { get; set; } // Để nhận mật khẩu mới

        public string? ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            // Kiểm tra xem người dùng đã đăng nhập qua cookie chưa
            var user = User;  // Lấy thông tin người dùng từ cookie

            if (!user.Identity.IsAuthenticated)
            {
                TempData["ErrorMessage"] = "Bạn phải đăng nhập để truy cập trang này.";
                return RedirectToPage("dang_nhap");
            }

            // Lấy thông tin tài khoản từ cơ sở dữ liệu
            var customer = await _customerServices.GetCustomerByEmailAsync(user.FindFirst(ClaimTypes.Email)?.Value);

            if (customer == null)
            {
                TempData["ErrorMessage"] = "Tài khoản không tồn tại.";
                return RedirectToPage("dang_nhap");
            }

            // Gán thông tin vào model
            IdUser = customer.IdUser!;
            Email = customer.Email!;
            Name = customer.Name!;
            Phone = customer.Phone!;
            Birthday = customer.Birthday?.ToString("yyyy-MM-dd");
            Address = customer.Address;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = User;  // Lấy thông tin người dùng từ cookie

            if (!user.Identity.IsAuthenticated)
            {
                TempData["ErrorMessage"] = "Bạn phải đăng nhập để cập nhật thông tin.";
                return RedirectToPage("dang_nhap");
            }

            // Kiểm tra mật khẩu mới
            string newPassword = Password;

            var updatedCustomer = new Customer
            {
                IdUser = IdUser,
                Name = Name,
                Email = Email,
                Phone = Phone,
                Birthday = string.IsNullOrEmpty(Birthday) ? null : DateOnly.Parse(Birthday),
                Address = Address
            };

            // Nếu người dùng nhập mật khẩu mới, cập nhật mật khẩu
            if (!string.IsNullOrEmpty(newPassword))
            {
                updatedCustomer.Password = newPassword;
            }
            else
            {
                // Nếu không thay đổi mật khẩu, giữ mật khẩu cũ
                var customer = await _customerServices.GetCustomerByEmailAsync(Email);
                updatedCustomer.Password = customer?.Password; // Giữ mật khẩu cũ
            }

            bool isUpdated = await _customerServices.UpdateCustomerAsync(updatedCustomer);

            if (!isUpdated)
            {
                ErrorMessage = "Cập nhật thất bại. Vui lòng thử lại.";
                return Page();
            }

            TempData["SuccessMessage"] = "Cập nhật thông tin thành công!";
            return RedirectToPage("trangchu"); // Sau khi cập nhật thành công, quay lại trang tài khoản
        }
    }
}
