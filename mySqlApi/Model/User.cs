using System.ComponentModel.DataAnnotations;

namespace mysqlAPI.Model;

public class User
{
    [Required]
    public int i_cliente_cliente{ get; set;}

    [Required]
    public string? s_nome_cliente{ get; set;}
    
    [Required]
    public string? s_cpf_cliente{ get; set;}

    [Required]
    public string? d_nasc_cliente{ get; set;}

    [Required]
    public int i_tipo_cliente{ get; set;}
}