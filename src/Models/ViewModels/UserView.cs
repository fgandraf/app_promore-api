
namespace PromoreApi.Models.ViewModels;

public class UserView
{
    public int Id { get; set; }
    public bool Active { get; set; }
    public string Email{ get; set; }
    public string Name { get; set; }
    public string Cpf { get; set; }
    public string Profession { get; set; }
    public List<int> Roles { get; set; }
    public List<int> Regions { get; set; }
}