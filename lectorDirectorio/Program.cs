// bucle hasta que se ingrese un path valido //
bool existePath = false;
while (!existePath) {
    // pedimos que se ingrese el path no vacio //
    bool pathCargado = false;
    string pathIngresado = string.Empty;
    do
    {
        Console.WriteLine("=========================");
        Console.WriteLine("Ingrese el path:");
        pathIngresado = Console.ReadLine();
        if (string.IsNullOrEmpty(pathIngresado))
        {
            Console.WriteLine("ingrese una cadena no vacia");
        }
        else
        {
            pathCargado = true;
        }
        Console.WriteLine("=========================");
    } while (pathCargado == false);

    // determinamos si el directorio existe o si no existe //
    if (Directory.Exists(pathIngresado))
    {
        Console.WriteLine("se encontro el directorio");
        existePath = true;
    }
    else
    {
        Console.WriteLine("no se encontro el directorio, porfavor ingrese un path existente");
    }
}
