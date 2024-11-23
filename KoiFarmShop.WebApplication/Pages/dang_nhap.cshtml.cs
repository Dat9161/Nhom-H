using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiFarmShop.Services.Interfaces;
using System.Security.Claims;

namespace KoiFarmShop.WebApplication.Pages
{
    public class dang_nhapModel : PageModel
    {
        private readonly ICustomerServices _customerServices;

        public dang_nhapModel(ICustomerServices customerServices)
        {
            _customerServices = customerServices;
        }

        [BindProperty]
        public string Email { get; set; } = string.Empty;

        [BindProperty]
        public string Password { get; set; } = string.Empty;

        public string? ErrorMessage { get; set; }

        public void OnGet()
        {
            ErrorMessage = null; // Reset lỗi khi truy cập lại
        }

        // Xử lý đăng nhập
        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
            {
                ErrorMessage = "Vui lòng điền đầy đủ thông tin.";
                return Page();
            }

            var customer = await _customerServices.LoginAsync(Email, Password);

            if (customer == null)
            {
                ErrorMessage = "Email hoặc mật khẩu không chính xác.";
                return Page();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, customer.IdUser),
                new Claim(ClaimTypes.Name, customer.Name),
                new Claim(ClaimTypes.Email, customer.Email)
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            // Đăng nhập và lưu cookie cho người dùng
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

            // Cập nhật session (tùy chọn)
            HttpContext.Session.SetString("IdUser", customer.IdUser);

            // Chuyển hướng đến trang quản lý tài khoản
            return RedirectToPage("/taikhoan");
        }

        // Xử lý đăng xuất
        

    }
}
