using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Supabase;
using Granary.Models;
// using Newtonsoft.Json;

namespace Granary.Pages;


public class IndexModel : PageModel
{
    private readonly Client _client;
    [TempData]
    public string WarningMessages { get; set;}
    public const string SessionKeyId = "_Id";
    public const string SessionKeyAge = "_Age";
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger, Client client)
    {
        _client = client;
        _logger = logger;
    }

    public void OnGet()
    {
    }
    [BindProperty]
    public User? User { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
       HttpContext.Session.Clear();
       try{
         var session = await _client.Auth.SignIn(User.Email, User.Password);
         HttpContext.Session.SetString(SessionKeyId, session.User.Id);
         HttpContext.Session.SetInt32(SessionKeyAge, session.ExpiresIn);
       } catch (Exception err){
        
        if(err.Message.Contains("Email not confirmed")) {
               WarningMessages = "You need to confirm your email!";
        }
        }
       
       
       return RedirectToPage("./Index");
    }
    public async Task<IActionResult> OnPostLogOutAsync()
    {
        
       await _client.Auth.SignOut();
       HttpContext.Session.Clear();
       return RedirectToPage("./Index");
    }
    
}
