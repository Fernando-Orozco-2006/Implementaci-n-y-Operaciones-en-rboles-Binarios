using System;
class Nodo
{
    public int Valor;
    public Nodo Izquierdo, Derecho;

    public Nodo(int valor)
    {
        Valor = valor;
        Izquierdo = Derecho = null;
    }
}
class ArbolBinarioBusqueda
{
    private Nodo raiz;

    public void Insertar(int valor)
    {
        raiz = InsertarRec(raiz, valor);
    }
    private Nodo InsertarRec(Nodo nodo, int valor)
    {
        if (nodo == null)
            return new Nodo(valor);

        if (valor < nodo.Valor)
            nodo.Izquierdo = InsertarRec(nodo.Izquierdo, valor);
        else if (valor > nodo.Valor)
            nodo.Derecho = InsertarRec(nodo.Derecho, valor);

        return nodo;
    }
    public bool Buscar(int valor)
    {
        return BuscarRec(raiz, valor);
    }
    private bool BuscarRec(Nodo nodo, int valor)
    {
        if (nodo == null) return false;
        if (valor == nodo.Valor) return true;
        return valor < nodo.Valor ? BuscarRec(nodo.Izquierdo, valor) : BuscarRec(nodo.Derecho, valor);
    }
    public void Eliminar(int valor)
    {
        raiz = EliminarRec(raiz, valor);
    }
    private Nodo EliminarRec(Nodo nodo, int valor)
    {
        if (nodo == null) return nodo;

        if (valor < nodo.Valor)
            nodo.Izquierdo = EliminarRec(nodo.Izquierdo, valor);
        else if (valor > nodo.Valor)
            nodo.Derecho = EliminarRec(nodo.Derecho, valor);
        else
        {
            if (nodo.Izquierdo == null) return nodo.Derecho;
            if (nodo.Derecho == null) return nodo.Izquierdo;

            Nodo sucesor = EncontrarMinimo(nodo.Derecho);
            nodo.Valor = sucesor.Valor;
            nodo.Derecho = EliminarRec(nodo.Derecho, sucesor.Valor);
        }
        return nodo;
    }
    private Nodo EncontrarMinimo(Nodo nodo)
    {
        while (nodo.Izquierdo != null)
            nodo = nodo.Izquierdo;
        return nodo;
    }
    public void RecorrerPreorden() => RecorrerPreordenRec(raiz);
    private void RecorrerPreordenRec(Nodo nodo)
    {
        if (nodo == null) return;
        Console.Write(nodo.Valor + " ");
        RecorrerPreordenRec(nodo.Izquierdo);
        RecorrerPreordenRec(nodo.Derecho);
    }
    public void RecorrerInorden() => RecorrerInordenRec(raiz);
    private void RecorrerInordenRec(Nodo nodo)
    {
        if (nodo == null) return;
        RecorrerInordenRec(nodo.Izquierdo);
        Console.Write(nodo.Valor + " ");
        RecorrerInordenRec(nodo.Derecho);
    }
    public void RecorrerPostorden() => RecorrerPostordenRec(raiz);
    private void RecorrerPostordenRec(Nodo nodo)
    {
        if (nodo == null) return;
        RecorrerPostordenRec(nodo.Izquierdo);
        RecorrerPostordenRec(nodo.Derecho);
        Console.Write(nodo.Valor + " ");
    }
}
class Program
{
    static void Main()
    {
        ArbolBinarioBusqueda abb = new ArbolBinarioBusqueda();
        while (true)
        {
            Console.WriteLine("\n1. Quiero Insertar");
            Console.WriteLine("2. Quiero Buscar");
            Console.WriteLine("3. Quiero Eliminar");
            Console.WriteLine("4. Favor de Recorrer Preorden");
            Console.WriteLine("5. Favor de Recorrer Inorden");
            Console.WriteLine("6. Favor de Recorrer Postorden");
            Console.WriteLine("7. Quiero Salir");
            Console.Write("Seleccione una opción: ");

            int opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    Console.Write("Qué valor te gustaria insertar?: ");
                    int valor = int.Parse(Console.ReadLine());
                    abb.Insertar(valor);
                    break;
                case 2:
                    Console.Write("Qué valor te gustaria buscar?: ");
                    valor = int.Parse(Console.ReadLine());
                    Console.WriteLine(abb.Buscar(valor) ? "Encontrado" : "No encontrado");
                    break;
                case 3:
                    Console.Write("Qué valor te gustaria eliminar?: ");
                    valor = int.Parse(Console.ReadLine());
                    abb.Eliminar(valor);
                    break;
                case 4:
                    abb.RecorrerPreorden();
                    Console.WriteLine();
                    break;
                case 5:
                    abb.RecorrerInorden();
                    Console.WriteLine();
                    break;
                case 6:
                    abb.RecorrerPostorden();
                    Console.WriteLine();
                    break;
                case 7:
                    return;
                default:
                    Console.WriteLine("La opción escogida no fue valida");
                    break;
            }
        }
    }
}