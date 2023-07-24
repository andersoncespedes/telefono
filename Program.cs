using System;
using System.Collections.Generic;
/*Crea un programa en C# que permita a los usuarios administrar una libreta telefónica. El programa debería tener un menú con las siguientes opciones:
    Agregar entrada
    Mostrar todas las entradas
    Marcar entrada como importante
    Eliminar entrada 
    Salir
    */
class Contacto {
    public int? Numero {get; set;}
    public string? Nombre {get; set;}
    public bool? Favorito {get; set;}
    public Contacto(int? numero, string? nombre){
        Numero = numero;
        Nombre = nombre;
        Favorito = false;
    }
}
class Program {
    public static Dictionary<int, Contacto> contact  = new(){
        {0, new Contacto(0, "")}
    };
    static void Main() {
        int opcion;

        do {
            MostrarMenu();
            opcion = PedirOpcion();

            switch (opcion) {
                case 1:
                    Saludar();
                    break;
                case 2:
                    AgregarEntrada();
                    break;
                case 3:
                    MostrarEntradas();
                    break;
                case 4:
                    Console.WriteLine("Hasta luego.");
                    break;
                default:
                    Console.WriteLine("Opción inválida. Inténtalo de nuevo.");
                    break;
            }

            Console.WriteLine();
        } while (opcion != 4);
    }

    static void MostrarMenu() {
        Console.WriteLine("Menú de opciones:");
        Console.WriteLine("1. Saludar");
        Console.WriteLine("2. Agregar Entrada");
        Console.WriteLine("3. Mostrar Entradas");
        Console.WriteLine("4. Salir");
    }

    static int PedirOpcion() {
        Console.Write("Elige una opción: ");
        return Convert.ToInt32(Console.ReadLine());
    }

    static void Saludar() {
        Console.WriteLine("¡Hola! ¡Bienvenido!");
    }

    static void AgregarEntrada() {
        Console.Write("Ingresa un número: ");
        int numero = Convert.ToInt32(Console.ReadLine());
        Console.Write("Ingrese un Nombre");
        string nombre = Console.ReadLine();
        Contacto cont = new Contacto(numero, nombre);
        Dictionary<int, Contacto>.KeyCollection keys = contact.Keys;
        contact.Add(keys.Last() + 1, cont);
    }

    static void MostrarEntradas() {
        foreach (KeyValuePair<int, Contacto> pareja in contact)
        {
            int clave = pareja.Key;
            Contacto valor = pareja.Value;
            if(clave > 0){
                Console.WriteLine($"Clave: {clave}, Valor: {valor.Nombre}");
            }
            
        }
    }
}