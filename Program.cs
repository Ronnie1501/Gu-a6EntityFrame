using Guía6EntityFrame;

using (var contextdb = new Context())
{
    foreach (var item in contextdb.estudiante)
    {
        Console.WriteLine("Datos:  Id: " + item.Id + " Nombre: " + item.Nombre + " Apellidos: " + item.Apellidos + " Edad: " + item.Edad + " Sexo: " + item.Sexo);

    }
}

bool AgregarRegistros = true;

while (AgregarRegistros)
{
    Console.WriteLine("Ingrese los datos del estudiante:");

    Console.Write("Nombre: ");
    string nombre = Console.ReadLine();

    Console.Write("Apellidos: ");
    string apellidos = Console.ReadLine();

    Console.Write("Sexo: ");
    string sexo = Console.ReadLine();

    Console.Write("Edad: ");
    int edad = Convert.ToInt32(Console.ReadLine());

    using (var contextdb = new Context())
    {
        contextdb.Database.EnsureCreated();

        var NuevoEs = new Student()
        {
            Nombre = nombre,
            Apellidos = apellidos,
            Sexo = sexo,
            Edad = edad
        };

        contextdb.Add(NuevoEs);
        contextdb.SaveChanges();
    }

    Console.WriteLine("¿Agregar más registros? (S/N)");
    string respuesta = Console.ReadLine();
    AgregarRegistros = respuesta.StartsWith("S", StringComparison.OrdinalIgnoreCase);
}

using (var contextdb = new Context())
{
    foreach (var estudiante in contextdb.estudiante)
    {
        Console.WriteLine("Estudiante: " + estudiante.Nombre + estudiante.Apellidos + " Sexo: " + estudiante.Sexo + " Edad: " + estudiante.Edad);
    }
}