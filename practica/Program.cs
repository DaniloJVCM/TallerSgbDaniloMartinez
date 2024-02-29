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

    public bool PrestarLibro(string titulo,string nombreusuario)
    {
        int cont=0;
        
        string SegundoNombreUsuario="";
        if(cont!=0)SegundoNombreUsuario = nombreusuario;

        if (SegundoNombreUsuario == nombreusuario)
        {
            Console.WriteLine("usuario no disponible");
            Console.ReadKey();
            return false;
        }
        
        SegundoNombreUsuario = nombreusuario;
        foreach (var libro in libros)
        {
            if (libro.Titulo == titulo && libro.Disponibilidad == true)
            {
            libro.Disponibilidad = false;
            Console.Clear();
            Console.WriteLine("has prestado el libro " + libro.Titulo);
            Console.Read();
            return true;
                
            }
            
        }
        cont++;

        Console.WriteLine("el libro no esta disponible");
        Console.ReadKey();
        return false;
    }
    public bool DevolverLibro(string titulo)
    {
        foreach (var libro in libros)
        {
            if (libro.Titulo == titulo && !libro.Disponibilidad)
            {
                libro.Disponibilidad = true;
                Console.Clear();
                Console.ReadKey();
                Console.WriteLine("Libro devuelto");
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
        Console.Read();
    }
}
class Program
{
    static void Main(string[] args)
    {
        CatalogoLibros catalogo = new CatalogoLibros();

        catalogo.AgregarLibro(new Libro("el principito", "Antoine de Saint-Exupéry", "1943", true));
        catalogo.AgregarLibro(new Libro("cien años de soledad", "Gabriel García Márquez", "1967", true));
        catalogo.AgregarLibro(new Libro("harry potter y la piedra filosofal", "J.K. Rowling", "1997", true));
        catalogo.AgregarLibro(new Libro("1984", "George Orwell", "1949", true));
        catalogo.AgregarLibro(new Libro("orgullo y prejuicio", "Jane Austen", "1813", true));
        catalogo.AgregarLibro(new Libro("matar un ruiseñor", "Harper Lee", "1960", true));
        catalogo.AgregarLibro(new Libro("don Quijote de la Mancha", "Miguel de Cervantes", "1605", true));
        catalogo.AgregarLibro(new Libro("crimen y castigo", "Fiódor Dostoyevski", "1866", true));
        catalogo.AgregarLibro(new Libro("el señor de los anillos", "J.R.R. Tolkien", "1954", true));
        catalogo.AgregarLibro(new Libro("la odisea", "Homero", "Siglo VIII a.C.", true));
        catalogo.AgregarLibro(new Libro("las aventuras de Sherlock Holmes", "Arthur Conan Doyle", "1892", true));
        catalogo.AgregarLibro(new Libro("anna karenina", "León Tolstói", "1877", true));
        catalogo.AgregarLibro(new Libro("el alquimista", "Paulo Coelho", "1988", true));
        catalogo.AgregarLibro(new Libro("los juegos del hambre", "Suzanne Collins", "2008", true));
        catalogo.AgregarLibro(new Libro("el código da vinci", "Dan Brown", "2003", true));
        catalogo.AgregarLibro(new Libro("el retrato de dorian gray", "Oscar Wilde", "1890", true));
        catalogo.AgregarLibro(new Libro("crónica de una muerte anunciada", "Gabriel García Márquez", "1981", true));
        catalogo.AgregarLibro(new Libro("el nombre del viento", "Patrick Rothfuss", "2007", true));
        catalogo.AgregarLibro(new Libro("la ladrona de libros", "Markus Zusak", "2005", true));
        catalogo.AgregarLibro(new Libro("las crónicas de Narnia", "C.S. Lewis", "1950", true));
        catalogo.AgregarLibro(new Libro("el laberinto de los espíritus", "Carlos Ruiz Zafón", "2016", true));
        catalogo.AgregarLibro(new Libro("la sombra del viento", "Carlos Ruiz Zafón", "2001", true));
        catalogo.AgregarLibro(new Libro("los pilares de la Tierra", "Ken Follett", "1989", true));
        catalogo.AgregarLibro(new Libro("el guardián entre el centeno", "J.D. Salinger", "1951", true));
        catalogo.AgregarLibro(new Libro("la hoguera de las vanidades", "Tom Wolfe", "1987", true));
        catalogo.AgregarLibro(new Libro("los miserables", "Victor Hugo", "1862", true));
        catalogo.AgregarLibro(new Libro("el gran Gatsby", "F. Scott Fitzgerald", "1925", true));
        catalogo.AgregarLibro(new Libro("la metamorfosis", "Franz Kafka", "1915", true));
        catalogo.AgregarLibro(new Libro("moby Dick", "Herman Melville", "1851", true));
        catalogo.AgregarLibro(new Libro("los hombres que no amaban a las mujeres", "Stieg Larsson", "2005", true));
        catalogo.AgregarLibro(new Libro("el paciente inglés", "Michael Ondaatje", "1992", true));
        catalogo.AgregarLibro(new Libro("memorias de una geisha", "Arthur Golden", "1997", true));
        catalogo.AgregarLibro(new Libro("el cuaderno de noah", "Nicholas Sparks", "1996", true));

        bool salirMenuPrincipal = false;
        while (!salirMenuPrincipal)
        {
            Console.Clear();
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
                    Console.Write("Ingrese el título del libro que desea prestar: ".ToLower());
                    string tituloPrestamo = Console.ReadLine();
                    catalogo.PrestarLibro(tituloPrestamo,nombreUsuario);
                    break;
                case 3:
                    Console.Write("Ingrese el título del libro que desea devolver: ".ToLower());
                    string tituloDevolver = Console.ReadLine();
                    catalogo.DevolverLibro(tituloDevolver);
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
