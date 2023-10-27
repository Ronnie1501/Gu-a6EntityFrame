using Guía6EntityFrame;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Menú Principal:\n");
            Console.WriteLine("1 - Mostrar Estudiantes");
            Console.WriteLine("2 - Agregar Estudiante");
            Console.WriteLine("3 - Modificar Estudiante");
            Console.WriteLine("4 - Eliminar Estudiante");
            Console.WriteLine("5 - Salir");

            int opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    MostrarEstudiantes();
                    break;

                case 2:
                    AgregarEstudiante();
                    break;

                case 3:
                    ModificarEstudiante();
                    break;

                case 4:
                    EliminarEstudiante();
                    break;

                case 5:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Opción inválida. Seleccione una opción válida.");
                    break;
            }
        }
    }

    static void MostrarEstudiantes()
    {
        Console.Clear();
        using (var context = new Context())
        {
            var estudiantes = context.estudiante.ToList();

            if (estudiantes.Count == 0)
            {
                Console.WriteLine("No hay estudiantes registrados.");
            }
            else
            {
                Console.WriteLine("Lista de Estudiantes:");
                foreach (var estudiante in estudiantes)
                {
                    Console.WriteLine("ID: " + estudiante.Id + ", Nombre: " + estudiante.Nombre + ", Apellidos: " + estudiante.Apellidos + ", Edad: " + estudiante.Edad + ", Sexo: " + estudiante.Sexo);
                }
            }
        }
        Console.ReadLine();
    }

    static void ModificarEstudiante()
    {
        Console.Clear();
        Console.Write("ID del estudiante a modificar: ");
        int id = Convert.ToInt32(Console.ReadLine());

        using (var context = new Context())
        {
            var estudiante = context.estudiante.SingleOrDefault(e => e.Id == id);

            if (estudiante != null)
            {
                Console.WriteLine("Estudiante actual:\n");
                Console.WriteLine("ID: " + estudiante.Id + ", Nombre: " + estudiante.Nombre + ", Apellidos: " + estudiante.Apellidos + ", Edad: " + estudiante.Edad + ", Sexo: " + estudiante.Sexo);
                Console.WriteLine("¿Qué desea modificar?\n");
                Console.WriteLine("1 - Nombre");
                Console.WriteLine("2 - Apellidos");
                Console.WriteLine("3 - Edad");
                Console.WriteLine("4 - Sexo");

                int opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.Write("Ingrese el nuevo nombre: ");
                        estudiante.Nombre = Console.ReadLine();
                        break;
                    case 2:
                        Console.Write("Ingrese los nuevos apellidos: ");
                        estudiante.Apellidos = Console.ReadLine();
                        break;
                    case 3:
                        Console.Write("Ingrese la nueva edad: ");
                        estudiante.Edad = Convert.ToInt32(Console.ReadLine());
                        break;
                    case 4:
                        Console.Write("Ingrese el nuevo sexo: ");
                        estudiante.Sexo = Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Opción no válida");
                        break;
                }

                context.SaveChanges();
                Console.WriteLine("Estudiante modificado");
            }
            else
            {
                Console.WriteLine("Estudiante no encontrado.");
            }
        }

        Console.ReadLine();
    }

    static void AgregarEstudiante()
    {
        Console.Clear();
        Console.WriteLine("Agregar Estudiante \n");
        Console.Write("Ingrese el Nombre: ");
        string nombre = Console.ReadLine();
        Console.Write("Ingrese los Apellidos: ");
        string apellidos = Console.ReadLine();
        Console.Write("Ingrese el Sexo: ");
        string sexo = Console.ReadLine();
        Console.Write("Ingrese la Edad: ");
        int edad = Convert.ToInt32(Console.ReadLine());

        using (var context = new Context())
        {
            context.Database.EnsureCreated();

            var nuevoEstudiante = new Student()
            {
                Nombre = nombre,
                Apellidos = apellidos,
                Sexo = sexo,
                Edad = edad
            };

            context.estudiante.Add(nuevoEstudiante);
            context.SaveChanges();
        }

        Console.WriteLine("Estudiante agregado");
        Console.ReadLine();
    }


    static void EliminarEstudiante()
    {
        Console.Clear();
        Console.WriteLine("Eliminar Estudiante");
        Console.Write("ID del estudiante: ");
        int id = Convert.ToInt32(Console.ReadLine());

        using (var context = new Context())
        {
            var estudiante = context.estudiante.SingleOrDefault(e => e.Id == id);

            if (estudiante != null)
            {
                context.estudiante.Remove(estudiante);
                context.SaveChanges();
                Console.WriteLine("Estudiante eliminado");
            }
            else
            {
                Console.WriteLine("Estudiante no encontrado.");
            }
        }

        Console.ReadLine();
    }
}
