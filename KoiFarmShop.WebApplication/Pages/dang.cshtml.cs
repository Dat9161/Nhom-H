using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace KoiFarmShop.WebApplication.Pages
{
    public class dangModel : PageModel
    {
        private readonly ICustomerServices _customerServices;

        public dangModel(ICustomerServices customerServices)
        {
            _customerServices = customerServices;
        }

        [BindProperty]
        public string Username { get; set; } = string.Empty;

        [BindProperty]
        public string Email { get; set; } = string.Empty;

        [BindProperty]
        public string Password { get; set; } = string.Empty;

        [BindProperty]
        public string ConfirmPassword { get; set; } = string.Empty;

        public string? ErrorMessage { get; set; }

        public void OnGet()
        {
            // Reset lỗi khi truy cập lại trang
            ErrorMessage = null;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Kiểm tra mật khẩu xác nhận
            if (Password != ConfirmPassword)
            {
                ErrorMessage = "Mật khẩu xác nhận không khớp. Vui lòng thử lại.";
                return Page();
            }

            // Tạo thông tin khách hàng mới
            var newCustomer = new Customer
            {
                IdUser = Guid.NewGuid().ToString(),
                Name = Username,
                Email = Email,
                Password = Password // Lưu mật khẩu trực tiếp mà không mã hóa
            };

            // Đăng ký
            bool isRegistered = await _customerServices.RegisterAsync(newCustomer);

            if (!isRegistered)
            {
                ErrorMessage = "Email đã tồn tại. Vui lòng thử email khác.";
                return Page();
            }

            TempData["SuccessMessage"] = "Đăng ký thành công! Vui lòng đăng nhập.";
            return RedirectToPage("dang_nhap");
        }
    }
}
