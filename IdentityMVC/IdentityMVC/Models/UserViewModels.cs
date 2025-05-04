namespace IdentityMVC.Models;

public class CreateModel
{
    public required string Name {  get; set; }
    public required string Email {  get; set; }
    public string Password {  get; set; } = string.Empty;
}
