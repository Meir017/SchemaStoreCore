using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SchemaStoreCore.Pages
{
    public class BaseModel : PageModel
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public void OnGet() { }
    }
}
