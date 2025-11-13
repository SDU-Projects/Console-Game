using System;

class Program
{
    // La caja, puedes cambiar el formato y los símbolos
    static void Cajita(string year, string ans)
    {
        Console.WriteLine("┌─────────────┐");
        Console.WriteLine("│ " + year.PadRight(11) + " │");
        if (ans != "")
            Console.WriteLine("│ " + ans.PadRight(11) + " │");
        else
            Console.WriteLine("│             │");
        Console.WriteLine("└─────────────┘");
        Console.WriteLine();
    }

    static void Main()
    {
        // Variables para las respuestas del usuario
        string a1 = "";
        string a2 = "";
        string a3 = "";


        // Pregunta 1 -> Copia y pega para hacer más, 
        // fíjate abajo para ver que es el mismo código que esta pregunta
        Console.WriteLine("PON AQUÍ CUALQUIER COSA");
        Console.WriteLine();
        Cajita("1700", ""); // Presentar la caja con siglo y sin respuesta

        while (a1 != "3") // Cambiar con la opción correcta
        {
            Console.WriteLine("Question 1:");
            Console.WriteLine("1. primera oración");
            Console.WriteLine("2. segunda oración");
            Console.WriteLine("3. tercera oración");
            Console.Write("Ans: ");
            a1 = Console.ReadLine() ?? "";
            if (a1 != "3")
            {
                Console.WriteLine("Nope!!!"); // Puedes dar una pista o cualquier cosa
                Console.WriteLine();
            }
        }

        Console.Clear(); // Limpia la consola de la pregunta anterior
        Console.WriteLine("PON AQUÍ CUALQUIER COSA");
        Console.WriteLine();
        Cajita("1700", "Blaa"); // Mostrar la caja con la respuesta
        Cajita("1800", ""); // Siguiente caja

        while (a2 != "3")
        {
            Console.WriteLine("Question 2:");
            Console.WriteLine("1. primera oración");
            Console.WriteLine("2. segunda oración");
            Console.WriteLine("3. tercera oración");
            Console.Write("Ans: ");
            a2 = Console.ReadLine() ?? "";
            if (a2 != "3")
            {
                Console.WriteLine("No");
                Console.WriteLine();
            }
        }

        Console.Clear();
        Console.WriteLine("PON AQUÍ CUALQUIER COSA");
        Console.WriteLine();
        Cajita("1700", "Blaa");
        Cajita("1800", "Blee");
        Cajita("1900", "");

        while (a3 != "3")
        {
            Console.WriteLine("Question 3:");
            Console.WriteLine("1. primera oración");
            Console.WriteLine("2. segunda oración");
            Console.WriteLine("3. tercera oración");
            Console.Write("Ans: ");
            a3 = Console.ReadLine() ?? "";
            if (a3 != "3")
            {
                Console.WriteLine("NO");
                Console.WriteLine();
            }
        }

        Console.Clear(); // Limpiar todo
        Console.WriteLine("PON AQUÍ CUALQUIER COSA");
        Console.WriteLine();

        // Las cajas con el texto en la segunda línea, puedes cambiar
        // de color y mejorar el formato
        Cajita("1700", "Blaa");
        Cajita("1800", "Blee");
        Cajita("1900", "Blii");

        Console.WriteLine("Listo!");
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
