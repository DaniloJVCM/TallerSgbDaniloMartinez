using System;
using System.Collections.Generic;
using System.Threading.Channels;

class Libro
{
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public string AñoPublicacion { get; set; }
    public bool Disponibilidad { get; set; }

    public Libro(string titulo, string autor, string añoPublicacion, bool disponibilidad)
    {
        Titulo = titulo;
        Autor = autor;
        AñoPublicacion = añoPublicacion;
        Disponibilidad = disponibilidad;
    }
}

class CatalogoLibros
{
    public List<Libro> libros;

    public CatalogoLibros()
    {
        libros = new List<Libro>();
    }

    public void AgregarLibro(Libro libro)
    {
        libros.Add(libro);
    }

    public bool PrestarLibro(string titulo)
    {
        foreach (var libro in libros)
        {
            if (libro.Titulo == titulo && libro.Disponibilidad==true)
            {
                libro.Disponibilidad = false;
                Console.WriteLine("has prestado el libro "+libro.Titulo);
                return true;
            }
            
        }
        Console.WriteLine("el libro no esta disponible");
        return false;
    }

    public bool DevolverLibro(string titulo)
    {
        foreach (var libro in libros)
        {
            if (libro.Titulo == titulo && !libro.Disponibilidad)
            {
                libro.Disponibilidad = true;
                return true; 
            }
        }
        return false; 
    }

    public void MostrarCatalogo()
    {
        Console.WriteLine("Catálogo de Libros:\n");
        foreach (var libro in libros)
        {
            Console.WriteLine($"Título: {libro.Titulo}");
            Console.WriteLine($"Autor: {libro.Autor}");
            Console.WriteLine($"Año de Publicación: {libro.AñoPublicacion}");
            Console.WriteLine($"Disponibilidad: {(libro.Disponibilidad ? "Disponible" : "No disponible")}");
            Console.WriteLine(" ");
        }
    }
}

class Usuario
{
    public string Nombre { get; private set; }

    public Usuario(string nombre)
    {
        Nombre = nombre;
    }

    public void DevolverLibro(CatalogoLibros catalogo, string titulo)
    {
        if (catalogo.DevolverLibro(titulo))
        {
            Console.WriteLine($"El libro '{titulo}' ha sido devuelto.");
        }
        else
        {
            Console.WriteLine($"Lo siento, el libro '{titulo}' no se prestó a {Nombre} o ya ha sido devuelto.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        CatalogoLibros catalogo = new CatalogoLibros();

        catalogo.AgregarLibro(new Libro("El principito", "Antoine de Saint-Exupéry", "1943", true));
        catalogo.AgregarLibro(new Libro("Cien años de soledad", "Gabriel García Márquez", "1967", true));
        catalogo.AgregarLibro(new Libro("Harry Potter y la piedra filosofal", "J.K. Rowling", "1997", true));
        catalogo.AgregarLibro(new Libro("1984", "George Orwell", "1949", true));
        catalogo.AgregarLibro(new Libro("1984", "George Orwell", "1949", true));
        catalogo.AgregarLibro(new Libro("Orgullo y prejuicio", "Jane Austen", "1813", true));
        catalogo.AgregarLibro(new Libro("Matar un ruiseñor", "Harper Lee", "1960", true));
        catalogo.AgregarLibro(new Libro("Don Quijote de la Mancha", "Miguel de Cervantes", "1605", true));
        catalogo.AgregarLibro(new Libro("Crimen y castigo", "Fiódor Dostoyevski", "1866", true));
        catalogo.AgregarLibro(new Libro("El señor de los anillos", "J.R.R. Tolkien", "1954", true));
        catalogo.AgregarLibro(new Libro("La Odisea", "Homero", "Siglo VIII a.C.", true));
        catalogo.AgregarLibro(new Libro("Las aventuras de Sherlock Holmes", "Arthur Conan Doyle", "1892", true));
        catalogo.AgregarLibro(new Libro("Anna Karenina", "León Tolstói", "1877", true));
        catalogo.AgregarLibro(new Libro("El alquimista", "Paulo Coelho", "1988", true));
        catalogo.AgregarLibro(new Libro("Los juegos del hambre", "Suzanne Collins", "2008", true));
        catalogo.AgregarLibro(new Libro("El código Da Vinci", "Dan Brown", "2003", true));
        catalogo.AgregarLibro(new Libro("El retrato de Dorian Gray", "Oscar Wilde", "1890", true));
        catalogo.AgregarLibro(new Libro("Crónica de una muerte anunciada", "Gabriel García Márquez", "1981", true));
        catalogo.AgregarLibro(new Libro("El nombre del viento", "Patrick Rothfuss", "2007", true));
        catalogo.AgregarLibro(new Libro("La ladrona de libros", "Markus Zusak", "2005", true));
        catalogo.AgregarLibro(new Libro("Las crónicas de Narnia", "C.S. Lewis", "1950", true));
        catalogo.AgregarLibro(new Libro("El laberinto de los espíritus", "Carlos Ruiz Zafón", "2016", true));
        catalogo.AgregarLibro(new Libro("La sombra del viento", "Carlos Ruiz Zafón", "2001", true));
        catalogo.AgregarLibro(new Libro("Los pilares de la Tierra", "Ken Follett", "1989", true));
        catalogo.AgregarLibro(new Libro("El guardián entre el centeno", "J.D. Salinger", "1951", true));
        catalogo.AgregarLibro(new Libro("La hoguera de las vanidades", "Tom Wolfe", "1987", true));
        catalogo.AgregarLibro(new Libro("Los miserables", "Victor Hugo", "1862", true));
        catalogo.AgregarLibro(new Libro("El gran Gatsby", "F. Scott Fitzgerald", "1925", true));
        catalogo.AgregarLibro(new Libro("La metamorfosis", "Franz Kafka", "1915", true));
        catalogo.AgregarLibro(new Libro("Moby Dick", "Herman Melville", "1851", true));
        catalogo.AgregarLibro(new Libro("Los hombres que no amaban a las mujeres", "Stieg Larsson", "2005", true));
        catalogo.AgregarLibro(new Libro("El paciente inglés", "Michael Ondaatje", "1992", true));
        catalogo.AgregarLibro(new Libro("Memorias de una geisha", "Arthur Golden", "1997", true));
        catalogo.AgregarLibro(new Libro("El cuaderno de Noah", "Nicholas Sparks", "1996", true));

        bool salirMenuPrincipal = false;
        while (!salirMenuPrincipal)
        {
            Console.WriteLine("1. Mostrar catálogo de libros\n2. Prestar un libro\n3. Devolver libro\n4. Salir");
            int dato = Convert.ToInt32(Console.ReadLine());

            switch (dato)
            {
                case 1:
                    catalogo.MostrarCatalogo();
                    break;
                case 2:
                    Console.Write("Ingrese su nombre: ");
                    string nombreUsuario = Console.ReadLine();
                    Usuario usuario = new Usuario(nombreUsuario);

                    Console.Write("Ingrese el título del libro que desea prestar: ".ToLower());
                    string tituloPrestamo = Console.ReadLine();
                    catalogo.PrestarLibro(tituloPrestamo);
                    break;
                case 3:
                    catalogo.DevolverLibro();
                    break;
                case 4:
                    salirMenuPrincipal = true;
                    break;
                default:
                    Console.WriteLine("Seleccione una opción válida.");
                    break;
            }
        }
    }
}
