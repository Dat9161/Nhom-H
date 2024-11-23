using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiFarmShop.WebApplication.Pages
{
    public class dang_xuatModel : PageModel
    {
        // Xử lý đăng xuất
        public async Task<IActionResult> OnGetAsync()
        {
            // Đăng xuất và xóa cookie
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // Xóa session khi đăng xuất
            HttpContext.Session.Clear();

            // Sau khi đăng xuất, chuyển hướng về trang chủ
            return RedirectToPage("/trangchu");
        }
    }
}
