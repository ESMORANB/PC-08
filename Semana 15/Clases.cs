using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

class Estudiante
{
    static void Main(string[] args)
    {
        Console.WriteLine("Ingrese su nombre: ");
        string nombre = Console.ReadLine();
        Console.WriteLine("Ingrese su edad: ");
        int edad = Console.ReadLine().Length; 
        Console.WriteLine("Ingrese su carrera: ");
        string carrera = Console.ReadLine();
        Console.WriteLine("Ingrese su carnet: ");
        string carnet = Console.ReadLine();
        Console.WriteLine("Ingrese su nota de admision: ");
        int Nota_admision = int.Parse(Console.ReadLine());
        Estudiante objetoProgram = new Estudiante();
        MostrarResumen(nombre, edad, carrera, carnet, Nota_admision);
        PuedeMatricularse(carnet, Nota_admision);
    }
    public static  void MostrarResumen(string nombre, int edad, string carrera, string carnet, int NotaAdmision)
    {
        Console.Clear();
        Console.WriteLine("Resumen de datos del estudiante: ");
        Console.WriteLine($"Nombre: {nombre} ");
        Console.WriteLine($"Edad: {edad} ");
        Console.WriteLine($"Carrera:{carrera} ");
        Console.WriteLine($"Carnet: {carnet} ");
        Console.WriteLine($"Nota de Admision: {NotaAdmision} ");
    }
    public static void PuedeMatricularse(string carnet, int Nota_admision)
    {
        if  (Nota_admision >= 75 && carnet.EndsWith("2025"))
        {
            Console.WriteLine("El estudiante puede matricularse");
        }
        else
        {
            Console.WriteLine("El estudiante no puede matricularse");
        }
    }
}