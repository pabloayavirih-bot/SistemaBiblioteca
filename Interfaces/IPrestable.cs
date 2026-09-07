namespace SistemaBiblioteca.Interfaces;

public interface IPrestable
{
    bool Disponible { get; }

    void Prestar();

    void Devolver();
}