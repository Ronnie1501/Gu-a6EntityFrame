using Guía6EntityFrame;

while (true)
{
    Console.Clear();
    Console.WriteLine("Menú Principal:");
    Console.WriteLine("Presione 1 para mostrar Estudiantes");
    Console.WriteLine("Presione 2 para agregar Estudiante");
    Console.WriteLine("Presione 3 para modificar Estudiante");
    Console.WriteLine("Presione 4 para eliminar Estudiante");
    Console.WriteLine("Presione 5 para Salir");

    int opcion = Convert.ToInt32(Console.ReadLine());

    switch (opcion)
    {
        case 1:
            MostrarEst();
            break;

        case 2:
            AgregarEst();
            break;

        case 3:
            ModificarEst();
            break;

        case 4:
            EliminarEst();
            break;

        case 5:
            Environment.Exit(0);
            break;

        default:
            Console.WriteLine("Opción invalida, Seleccione una opción valida");
            break;
    }
}


static void MostrarEst()
{
    Console.Clear();
    using (var context = new Context())
    {
        foreach (var estudiante in context.estudiante)
        {
            Console.WriteLine("Datos: Id: " + estudiante.Id + ", Nombre: " + estudiante.Nombre + ", Apellidos: " + estudiante.Apellidos + ", Edad: " + estudiante.Edad + ", Sexo: " + estudiante.Sexo);

        }
    }
    Console.ReadLine();
}

static void AgregarEst()
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

        var NuevoEst = new Student()
        {
            Nombre = nombre,
            Apellidos = apellidos,
            Sexo = sexo,
            Edad = edad
        };

        context.estudiante.Add(NuevoEst);
        context.SaveChanges();
    }

    Console.WriteLine("Estudiante agregado exitosamente.");
    Console.ReadLine();
}

static void ModificarEst()
{
    Console.Clear();
    Console.Write("ID del estudiante a modificar: ");
    int id = Convert.ToInt32(Console.ReadLine());

    using (var context = new Context())
    {
        var estudiante = context.estudiante.SingleOrDefault(e => e.Id == id);

        if (estudiante != null)
        {
            Console.WriteLine("Estudiante actual:");
            Console.WriteLine($"ID: {estudiante.Id}, Nombre: {estudiante.Nombre}, Apellidos: {estudiante.Apellidos}, Edad: {estudiante.Edad}, Sexo: {estudiante.Sexo}");
            Console.WriteLine("¿Qué atributo desea modificar?");
            Console.WriteLine("1. Nombre");
            Console.WriteLine("2. Apellidos");
            Console.WriteLine("3. Edad");
            Console.WriteLine("4. Sexo");

            int opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Write("Nuevo nombre: ");
                    estudiante.Nombre = Console.ReadLine();
                    break;
                case 2:
                    Console.Write("Nuevos apellidos: ");
                    estudiante.Apellidos = Console.ReadLine();
                    break;
                case 3:
                    Console.Write("Nueva edad: ");
                    estudiante.Edad = Convert.ToInt32(Console.ReadLine());
                    break;
                case 4:
                    Console.Write("Nuevo sexo: ");
                    estudiante.Sexo = Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

            context.SaveChanges();
            Console.WriteLine("Estudiante modificado exitosamente.");
        }
        else
        {
            Console.WriteLine("Estudiante no encontrado.");
        }
    }

    Console.ReadLine();
}

static void EliminarEst()
{
    Console.Clear();
    Console.WriteLine("Eliminar Estudiante");
    Console.Write("ID del estudiante a eliminar: ");
    int id = Convert.ToInt32(Console.ReadLine());

    using (var context = new Context())
    {
        var estudiante = context.estudiante.SingleOrDefault(e => e.Id == id);

        if (estudiante != null)
        {
            context.estudiante.Remove(estudiante);
            context.SaveChanges();
            Console.WriteLine("Estudiante eliminado exitosamente.");
        }
        else
        {
            Console.WriteLine("Estudiante no encontrado.");
        }
    }

    Console.ReadLine();
}