using SistemaBiblioteca.Models;

Console.WriteLine("=================================");
Console.WriteLine("SISTEMA DE GESTIÓN DE BIBLIOTECA");
Console.WriteLine("=================================");

Libro libroPrueba = new Libro(
    "El Principito",
    "Antoine de Saint-Exupéry",
    "Novela",
    "LIB001",
    true
);

Console.WriteLine();
Console.WriteLine($"Título: {libroPrueba.Titulo}");
Console.WriteLine($"Autor: {libroPrueba.Autor}");
Console.WriteLine($"Código: {libroPrueba.Codigo}");
Console.WriteLine($"Disponible: {libroPrueba.Disponible}");