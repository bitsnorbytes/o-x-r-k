using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Supabase;
using Granary.Models;
using Newtonsoft.Json;

namespace Granary.Pages;


public class IndexModel : PageModel
{
    private readonly Client _client;
    [TempData]
    public string WarningMessages { get; set;}
    public const string SessionKeyId = "_Id";
    public const string SessionKeyAge = "_Age";
    public const string SessionAccessToken = "_AccessToken";
    public const string UserEmailConfirmationSent = "_UserEmailConfirmationSent";
    public const string UserEmailConfirmationReceived = "_UserEmailConfirmationReceived";
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger, Client client)
    {
        _client = client;
        _logger = logger;
    }

    public void OnGet()
    {
      if(HttpContext.Session.GetString(SessionKeyId) != string.Empty) {
        if (HttpContext.Session.GetString(UserEmailConfirmationReceived) == string.Empty) {
          WarningMessages = "You need to confirm your email!";
        }
      }
    }
    [BindProperty]
    public User? User { get; set; }
    string StringNullChecker(string? input) {
        var output = string.Empty;
        if (input != null) {
        output = input.ToString();
        }
        return output;
    }
    string DateNullChecker(DateTime? input) {
        var output = string.Empty;
        if (input != null) {
        output = input.ToString();
        }
        return output;
    }
    public async Task<IActionResult> OnPostAsync()
    {
       HttpContext.Session.Clear();
       try{
         var session = await _client.Auth.SignIn(User.Email, User.Password);
         HttpContext.Session.SetString(SessionKeyId, StringNullChecker(session.User.Id));
         HttpContext.Session.SetString(SessionAccessToken, StringNullChecker(session.AccessToken));
         HttpContext.Session.SetString(UserEmailConfirmationSent, DateNullChecker(session.User.ConfirmationSentAt));
         HttpContext.Session.SetString(UserEmailConfirmationReceived, DateNullChecker(session.User.ConfirmedAt));
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
