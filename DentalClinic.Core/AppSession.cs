using DentalClinic.Core.Entities;

namespace DentalClinic.WinForms;

public class AppSession
{
    public User? CurrentUser { get; private set; }
    public bool IsAuthenticated => CurrentUser != null;

    public void SignIn(User user) => CurrentUser = user;
    public void SignOut() => CurrentUser = null;

}
