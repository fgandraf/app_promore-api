namespace PromoreApi.ViewModels;

public class UserUpdateVO
{
    public int Id { get; set; }
    public bool Active { get; set; }
    public string Email{ get; set; }
    public string PasswordHash { get; set; }
    public List<int> Roles { get; set; }
    public List<int> Regions { get; set; }
}