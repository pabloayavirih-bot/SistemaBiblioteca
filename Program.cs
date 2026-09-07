using SistemaBiblioteca.Models;

List<Libro> libros = new List<Libro>();
//List<Libro> libros = new();

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

Usuario usuarioPrueba = new Usuario(
    "USR001",
    "Pablo Ayaviri",
    "pablo@email.com"
);

Console.WriteLine();
Console.WriteLine($"Usuario: {usuarioPrueba.Nombre}");
Console.WriteLine($"ID: {usuarioPrueba.Identificador}");
Console.WriteLine($"Correo: {usuarioPrueba.Correo}");

libros.Add(libroPrueba);

Libro segundoLibro = new Libro(
    "1984",
    "George Orwell",
    "Distopía",
    "LIB002",
    true
);

libros.Add(segundoLibro);

foreach (Libro libro in libros)
{
    Console.WriteLine($"{libro.Codigo} - {libro.Titulo}");
}