using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Promore.Core.Requests.Clients;

public class UpdateClientRequest : Request
{
    [Required(ErrorMessage = "O campo 'Id' é obrigatório.")]
    [DefaultValue("")]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "O campo 'Name' é obrigatório.")]
    [MaxLength(100)]
    [DefaultValue("")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "O campo 'Cpf' é obrigatório.")]
    [Length(11,11,ErrorMessage = "'Cpf' deve conter 11 números.")]
    [DefaultValue("")]
    public string Cpf { get; set; }
    
    [Required(ErrorMessage = "O campo 'Phone' é obrigatório.")]
    [Length(11,11,ErrorMessage = "'Phone' deve conter 11 números.")]
    [DefaultValue("")]
    public string Phone { get; set; }

    [MaxLength(100)] 
    public string MothersName { get; set; } = string.Empty;
    
    public DateTime BirthdayDate { get; set; }
    
    [Required(ErrorMessage = "O campo 'LotId' é obrigatório.")]
    public int LotId { get; set; }
}