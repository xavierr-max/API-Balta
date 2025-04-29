using System.ComponentModel.DataAnnotations;

namespace Blog.ViewModels;

public class LoginViewModel
{
    [Required(ErrorMessage = "Imforme o E-mail")]
    [EmailAddress(ErrorMessage = "E-mail Invalido")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "Informe o Senha")]
    public string Password { get; set; }
}