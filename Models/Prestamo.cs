namespace SistemaBiblioteca.Models;

public record Prestamo(
    string CodigoLibro,
    string IdentificadorUsuario,
    DateTime FechaPrestamo,
    DateTime? FechaDevolucion
)
{
    public bool Activo => FechaDevolucion == null;
}