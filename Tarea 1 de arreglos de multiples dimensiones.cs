using System;

class Program
{
    static void Main()
    {
        // Arreglo unidimensional para los 4 equipos
        string[] equipos = new string[4];

        // Matriz bidimensional de 4 filas (equipos) y 5 columnas (jornadas)
        int[,] puntos = new int[4, 5];

        // Arreglo para almacenar el total de puntos de cada equipo
        int[] totales = new int[4];

        Console.WriteLine("=== REGISTRO DE EQUIPOS ===");
        for (int i = 0; i < 4; i++)
        {
            Console.Write("Digite el nombre del equipo " + (i + 1) + ": ");
            equipos[i] = Console.ReadLine();
        }

        Console.WriteLine("\n=== REGISTRO DE PUNTOS POR JORNADA ===");
        for (int i = 0; i < 4; i++)
        {
            Console.WriteLine("\nPuntos de " + equipos[i] + ":");
            int sumaEquipo = 0;

            for (int j = 0; j < 5; j++)
            {
                int punto = -1;

                // Validar que no se ingresen puntos negativos
                while (punto < 0)
                {
                    Console.Write("  Jornada " + (j + 1) + ": ");
                    punto = Convert.ToInt32(Console.ReadLine());

                    if (punto < 0)
                    {
                        Console.WriteLine("  Error: Los puntos no pueden ser negativos.");
                    }
                }

                puntos[i, j] = punto;
                sumaEquipo = sumaEquipo + punto;
            }

            totales[i] = sumaEquipo;
        }

        // Mostrar tabla completa con todos los resultados
        Console.WriteLine("\n=== TABLA DE RESULTADOS DEL TORNEO ===");
        Console.WriteLine("Equipo\t\tJ1\tJ2\tJ3\tJ4\tJ5\tTotal");
        Console.WriteLine("----------------------------------------------------------------");

        for (int i = 0; i < 4; i++)
        {
            Console.Write(equipos[i] + "\t\t");
            for (int j = 0; j < 5; j++)
            {
                Console.Write(puntos[i, j] + "\t");
            }
            Console.WriteLine(totales[i]);
        }

        // Determinar equipos con 15 puntos o más
        Console.WriteLine("\n=== EQUIPOS CON 15 PUNTOS O MÁS ===");
        bool hayEquipos = false;

        for (int i = 0; i < 4; i++)
        {
            if (totales[i] >= 15)
            {
                Console.WriteLine("- " + equipos[i] + " (" + totales[i] + " puntos)");
                hayEquipos = true;
            }
        }

        if (hayEquipos == false)
        {
            Console.WriteLine("Ningún equipo acumuló 15 puntos o más.");
        }

        // Identificar el equipo con mayor puntuación
        int mayorPuntuacion = totales[0];
        int indiceGanador = 0;

        for (int i = 1; i < 4; i++)
        {
            if (totales[i] > mayorPuntuacion)
            {
                mayorPuntuacion = totales[i];
                indiceGanador = i;
            }
        }

        Console.WriteLine("\n=== EQUIPO CON MAYOR PUNTUACIÓN ===");
        Console.WriteLine("El equipo con mayor puntuación es " + equipos[indiceGanador] + " con " + mayorPuntuacion + " puntos.");

        // Calcular el promedio de puntos obtenidos por todos los equipos en cada jornada
        Console.WriteLine("\n=== PROMEDIO DE PUNTOS POR JORNADA ===");
        for (int j = 0; j < 5; j++)
        {
            double sumaJornada = 0;

            for (int i = 0; i < 4; i++)
            {
                sumaJornada = sumaJornada + puntos[i, j];
            }

            double promedio = sumaJornada / 4;
            Console.WriteLine("Jornada " + (j + 1) + ": " + promedio);
        }
    }
}