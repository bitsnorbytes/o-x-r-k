using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Supabase;
using Granary.Models;
using Newtonsoft.Json;

namespace Granary.Pages;


public class SignupModel : PageModel
{
    private readonly Client _client;
    public const string SessionKeyId = "_Id";
    public const string SessionKeyAge = "_Age";
    public const string SessionAccessToken = "_AccessToken";
    public const string UserEmailConfirmationSent = "_UserEmailConfirmationSent";
    public const string UserEmailConfirmationReceived = "_UserEmailConfirmationReceived";
    private readonly ILogger<SignupModel> _logger;

    public SignupModel(ILogger<SignupModel> logger, Client client)
    {
        _client = client;
        _logger = logger;
    }

    public void OnGet()
    {
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
       var session = await _client.Auth.SignUp(User.Email, User.Password);
       HttpContext.Session.SetString(SessionKeyId, StringNullChecker(session.User.Id));
       HttpContext.Session.SetString(SessionAccessToken, StringNullChecker(session.AccessToken));
       HttpContext.Session.SetString(UserEmailConfirmationSent, DateNullChecker(session.User.ConfirmationSentAt));
       HttpContext.Session.SetString(UserEmailConfirmationReceived, DateNullChecker(session.User.ConfirmedAt));
       HttpContext.Session.SetInt32(SessionKeyAge, session.ExpiresIn);
       return RedirectToPage("./Index");
    }
}
