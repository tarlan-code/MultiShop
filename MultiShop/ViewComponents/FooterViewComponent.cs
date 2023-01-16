using Microsoft.AspNetCore.Mvc;

namespace MultiShop.ViewComponents
{
    public class FooterViewComponent:ViewComponent
    {


        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
