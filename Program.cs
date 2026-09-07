using SistemaBiblioteca.Models;
using SistemaBiblioteca.Services;

BibliotecaService biblioteca = new BibliotecaService();

bool continuar = true;

while (continuar)
{
    Console.WriteLine();
    Console.WriteLine("================================");
    Console.WriteLine(" SISTEMA DE GESTIÓN DE BIBLIOTECA");
    Console.WriteLine("================================");
    Console.WriteLine("1. Registrar libro");
    Console.WriteLine("2. Registrar usuario");
    Console.WriteLine("3. Listar libros");
    Console.WriteLine("0. Salir");
    Console.Write("Seleccione una opción: ");

    string? opcion = Console.ReadLine();

    switch (opcion)
    {
        case "1":
            Console.WriteLine();
            Console.WriteLine("--- REGISTRAR LIBRO ---");

            Console.Write("Título: ");
            string titulo = Console.ReadLine() ?? "";

            Console.Write("Autor: ");
            string autor = Console.ReadLine() ?? "";

            Console.Write("Categoría: ");
            string categoria = Console.ReadLine() ?? "";

            Console.Write("Código: ");
            string codigo = Console.ReadLine() ?? "";

            Libro nuevoLibro = new Libro(
                titulo,
                autor,
                categoria,
                codigo,
                true
            );

            biblioteca.RegistrarLibro(nuevoLibro);

            Console.WriteLine("Libro registrado correctamente.");
            break;

        case "2":
            Console.WriteLine();
            Console.WriteLine("--- REGISTRAR USUARIO ---");

            Console.Write("Identificador: ");
            string identificador = Console.ReadLine() ?? "";

            Console.Write("Nombre: ");
            string nombre = Console.ReadLine() ?? "";

            Console.Write("Correo: ");
            string correo = Console.ReadLine() ?? "";

            Usuario nuevoUsuario = new Usuario(
                identificador,
                nombre,
                correo
            );

            biblioteca.RegistrarUsuario(nuevoUsuario);

            Console.WriteLine("Usuario registrado correctamente.");
            break;

        case "3":
            Console.WriteLine();
            Console.WriteLine("--- LIBROS REGISTRADOS ---");

            foreach (Libro libro in biblioteca.ObtenerLibros())
            {
                Console.WriteLine(
                    $"{libro.Codigo} | {libro.Titulo} | {libro.Autor}"
                );
            }

            break;

        case "0":
            continuar = false;
            Console.WriteLine("Programa finalizado.");
            break;

        default:
            Console.WriteLine("Opción inválida.");
            break;
    }
}