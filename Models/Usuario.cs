namespace SistemaBiblioteca.Models;

public class Usuario
{
    public string Identificador { get; set; }
    public string Nombre { get; set; }
    public string Correo { get; set; }

    public Usuario(
        string identificador,
        string nombre,
        string correo)
    {
        Identificador = identificador;
        Nombre = nombre;
        Correo = correo;
    }
}