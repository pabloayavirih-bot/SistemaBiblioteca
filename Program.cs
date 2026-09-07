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
    Console.WriteLine("4. Buscar libro");
    Console.WriteLine("5. Eliminar libro");
    Console.WriteLine("0. Salir");
    Console.Write("Seleccione una opción: ");

    string? opcion = Console.ReadLine();

    try
    {
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

                Console.WriteLine(
                    "Libro registrado correctamente."
                );

                break;

            case "2":
                Console.WriteLine();
                Console.WriteLine("--- REGISTRAR USUARIO ---");

                Console.Write("Identificador: ");
                string identificador =
                    Console.ReadLine() ?? "";

                Console.Write("Nombre: ");
                string nombre =
                    Console.ReadLine() ?? "";

                Console.Write("Correo: ");
                string correo =
                    Console.ReadLine() ?? "";

                Usuario nuevoUsuario = new Usuario(
                    identificador,
                    nombre,
                    correo
                );

                biblioteca.RegistrarUsuario(nuevoUsuario);

                Console.WriteLine(
                    "Usuario registrado correctamente."
                );

                break;

            case "3":
                Console.WriteLine();
                Console.WriteLine("--- LIBROS REGISTRADOS ---");

                List<Libro> librosRegistrados =
                    biblioteca.ObtenerLibros();

                if (librosRegistrados.Count == 0)
                {
                    Console.WriteLine(
                        "No hay libros registrados."
                    );
                }
                else
                {
                    foreach (Libro libro in librosRegistrados)
                    {
                        Console.WriteLine(
                            $"{libro.Codigo} | " +
                            $"{libro.Titulo} | " +
                            $"{libro.Autor}"
                        );
                    }
                }

                break;

            case "4":
                Console.WriteLine();
                Console.WriteLine("--- BUSCAR LIBRO ---");

                Console.Write("Código del libro: ");
                string codigoBuscar =
                    Console.ReadLine() ?? "";

                Libro? libroEncontrado =
                    biblioteca.BuscarLibroPorCodigo(
                        codigoBuscar
                    );

                if (libroEncontrado == null)
                {
                    Console.WriteLine(
                        "No se encontró ningún libro " +
                        "con ese código."
                    );
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine(
                        $"Código: {libroEncontrado.Codigo}"
                    );

                    Console.WriteLine(
                        $"Título: {libroEncontrado.Titulo}"
                    );

                    Console.WriteLine(
                        $"Autor: {libroEncontrado.Autor}"
                    );

                    Console.WriteLine(
                        $"Categoría: {libroEncontrado.Categoria}"
                    );

                    Console.WriteLine(
                        $"Disponible: {libroEncontrado.Disponible}"
                    );
                }

                break;

            case "5":
                Console.WriteLine();
                Console.WriteLine("--- ELIMINAR LIBRO ---");

                Console.Write("Código del libro: ");
                string codigoEliminar =
                    Console.ReadLine() ?? "";

                biblioteca.EliminarLibro(
                    codigoEliminar
                );

                Console.WriteLine(
                    "Libro eliminado correctamente."
                );

                break;

            case "0":
                continuar = false;

                Console.WriteLine(
                    "Programa finalizado."
                );

                break;

            default:
                Console.WriteLine(
                    "Opción inválida."
                );

                break;
        }
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine(
            $"Error: {ex.Message}"
        );
    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine(
            $"Error: {ex.Message}"
        );
    }
}