using System;
using System.Collections.Generic;
class Contacto {
    public int? Numero {get; set;}
    public string? Nombre {get; set;}
    public bool Favorito {get; set;}
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
            Console.Clear();
            MostrarMenu();
            opcion = PedirOpcion();

            switch (opcion) {
                case 1:
                    Console.Clear();
                    AgregarEntrada();
                    break;
                case 2:
                    Console.Clear();
                    MostrarEntradas();
                    Console.Write("presione enter para continuar ->");
                    Console.ReadLine();
                    break;
                case 3:
                    Console.Clear();
                    MarcaFavorito();
                    break;
                case 4:
                    Console.Clear();
                    EliminarEntrada();
                    break;
                case 5:
                    Console.WriteLine("hasta luego :)");
                    break;
                default:
                    Console.WriteLine("Opción inválida. Inténtalo de nuevo.");
                    break;
            }
        } while (opcion != 5);
    }

    static void MostrarMenu() {
        Console.WriteLine("Menú de opciones:");
        Console.WriteLine("1. Agregar Entrada");
        Console.WriteLine("2. Mostrar Entradas");
        Console.WriteLine("3. Marcar Entrada Como Favorito");
        Console.WriteLine("4. Eliminar Entrada");
        Console.WriteLine("5. Salir");
    }
    static void EliminarEntrada(){
        MostrarEntradas();
        int id = PedirOpcion();
        contact.Remove(id);
    }
    static int PedirOpcion() {
        Console.Write("Elige una opción: ");
        return Convert.ToInt32(Console.ReadLine());
    }

    static void Saludar() {
        Console.WriteLine("¡Hola! ¡Bienvenido!");
    }

    static void AgregarEntrada() {
        try{
            Console.Write("Ingresa un número: ");
            int numero = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ingrese un Nombre: ");
            string nombre = Console.ReadLine();
            Contacto cont = new Contacto(numero, nombre);
            Dictionary<int, Contacto>.KeyCollection keys = contact.Keys;
            contact.Add(keys.Last() + 1, cont);
        }catch(FormatException e){
            Console.WriteLine(e.Message);
        }
        
    }
    static void MarcaFavorito(){
        MostrarEntradas();
        int opcion = PedirOpcion();
        contact[opcion].Favorito = true;
        Console.WriteLine("Se ha agregado un favorito");
    }
    static void MostrarEntradas() {
        Console.WriteLine("Id  Nombre  Telefono  Favorito");
        Console.WriteLine("------------------------------");
        foreach (KeyValuePair<int, Contacto> pareja in contact)
        {
            int clave = pareja.Key;
            Contacto valor = pareja.Value;
            if(clave > 0){
                string fav = valor.Favorito ? "SI" : "NO";
                Console.WriteLine($"{clave} | {valor.Nombre} | {valor.Numero} | {fav}");
            }
        }
    }
}