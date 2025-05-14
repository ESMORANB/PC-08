using System;

namespace GestionNotasEstudiantes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declaración de arreglos para almacenar nombres y notas
            string[] nombres = new string[10];
            int[][] notas = new int[10][];

            // Inicialización del arreglo de notas (10 estudiantes, 10 notas cada uno)
            for (int i = 0; i < 10; i++)
            {
                notas[i] = new int[10];
            }

            // Ingreso de datos
            IngresarDatos(nombres, notas);

            // Menú principal
            bool salir = false;
            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("\n===== Gestioneishon Notas URL =====");
                Console.WriteLine("1) Mostrar nombre y notas aprobadas para cada alumno");
                Console.WriteLine("2) Mostrar nombre y notas no aprobadas para cada alumno");
                Console.WriteLine("3) Mostrar el promedio de notas del grupo");
                Console.WriteLine("4) Salir del programa");
                Console.Write("\nSeleccione una opción: ");

                if (int.TryParse(Console.ReadLine(), out int opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            MostrarNotasAprobadas(nombres, notas);
                            break;
                        case 2:
                            MostrarNotasNoAprobadas(nombres, notas);
                            break;
                        case 3:
                            MostrarPromedioGrupo(nombres, notas);
                            break;
                        case 4:
                            salir = true;
                            Console.WriteLine("\nGracias por utilizar el programa descanse bien papaito. ¡Hasta pronto!");
                            break;
                        default:
                            Console.WriteLine("\nOpción no válida. Presione cualquier tecla para continuar...");
                            Console.ReadKey();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\nPor favor, ingrese un número válido. Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                }

                if (!salir && opcion != 4)
                {
                    Console.WriteLine("\nPresione cualquier tecla para volver al menú principal...");
                    Console.ReadKey();
                }
            }
        }

        static void IngresarDatos(string[] nombres, int[][] notas)
        {
            Console.WriteLine("===== INGRESO DE DATOS DE ESTUDIANTES =====\n");

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"--- Estudiante {i + 1} ---");
                
                // Ingreso del nombre del estudiante
                Console.Write("Ingrese el nombre del estudiante: ");
                nombres[i] = Console.ReadLine();
                
                // Validación de nombre no vacío
                while (string.IsNullOrWhiteSpace(nombres[i]))
                {
                    Console.Write("El nombre no puede estar vacío. Ingrese el nombre del estudiante: ");
                    nombres[i] = Console.ReadLine();
                }

                Console.WriteLine($"\nIngreso de 10 notas para {nombres[i]} (valores entre 0 y 100):");

                // Ingreso de las 10 notas del estudiante
                for (int j = 0; j < 10; j++)
                {
                    bool notaValida = false;
                    
                    while (!notaValida)
                    {
                        Console.Write($"Nota {j + 1}: ");
                        
                        if (int.TryParse(Console.ReadLine(), out int nota))
                        {
                            // Validar que la nota esté entre 0 y 100
                            if (nota >= 0 && nota <= 100)
                            {
                                notas[i][j] = nota;
                                notaValida = true;
                            }
                            else
                            {
                                Console.WriteLine("La nota debe estar entre 0 y 100. Intente nuevamente.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Por favor, ingrese un valor numérico válido.");
                        }
                    }
                }
                
                Console.WriteLine(); // Salto de línea para separar los estudiantes
            }
            
            Console.WriteLine("¡Datos ingresados correctamente!\n");
        }

        static void MostrarNotasAprobadas(string[] nombres, int[][] notas)
        {
            Console.WriteLine("\n===== NOTAS APROBADAS POR ESTUDIANTE =====");
            
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"\nEstudiante: {nombres[i]}");
                Console.Write("Notas aprobadas (>=65): ");
                
                bool tieneNotasAprobadas = false;
                
                for (int j = 0; j < 10; j++)
                {
                    if (notas[i][j] >= 65)
                    {
                        Console.Write($"{notas[i][j]} ");
                        tieneNotasAprobadas = true;
                    }
                }
                
                if (!tieneNotasAprobadas)
                {
                    Console.Write("No tiene notas aprobadas.");
                }
                
                Console.WriteLine();
            }
        }

        static void MostrarNotasNoAprobadas(string[] nombres, int[][] notas)
        {
            Console.WriteLine("\n===== NOTAS NO APROBADAS POR ESTUDIANTE :C (ponte pilas ome) =====");
            
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"\nEstudiante: {nombres[i]}");
                Console.Write("Notas no aprobadas (<65): ");
                
                bool tieneNotasNoAprobadas = false;
                
                for (int j = 0; j < 10; j++)
                {
                    if (notas[i][j] < 65)
                    {
                        Console.Write($"{notas[i][j]} ");
                        tieneNotasNoAprobadas = true;
                    }
                }
                
                if (!tieneNotasNoAprobadas)
                {
                    Console.Write("No tiene notas reprobadas.");
                }
                
                Console.WriteLine();
            }
        }

        static void MostrarPromedioGrupo(string[] nombres, int[][] notas)
        {
            Console.WriteLine("\n===== PROMEDIO DE NOTAS DEL GRUPO =====");
            
            // Calcular el promedio de todas las notas
            int totalNotas = 0;
            int cantidadNotas = 10 * 10; // 10 estudiantes x 10 notas
            
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    totalNotas += notas[i][j];
                }
            }
            
            double promedio = (double)totalNotas / cantidadNotas;
            
            Console.WriteLine($"\nEl promedio de notas del grupo es: {promedio:F2}");
            
            // Mostrar también los promedios individuales para mayor detalle
            Console.WriteLine("\n--- Promedios individuales ---");
            
            for (int i = 0; i < 10; i++)
            {
                int sumaNotasEstudiante = 0;
                
                for (int j = 0; j < 10; j++)
                {
                    sumaNotasEstudiante += notas[i][j];
                }
                
                double promedioEstudiante = (double)sumaNotasEstudiante / 10;
                string estado = promedioEstudiante >= 65 ? "APROBADO" : "REPROBADO";
                
                Console.WriteLine($"{nombres[i]}: {promedioEstudiante:F2} - {estado}");
            }
        }
    }
}