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
        existePath = true;
        Console.WriteLine($"=================== {pathIngresado} =================");
        // mostramos las carpetas //
        Console.WriteLine("CARPETAS DENTRO:");
        string[] directoriosDentro = Directory.GetDirectories(pathIngresado);
        foreach (string directorio in directoriosDentro)
        {
            Console.WriteLine(directorio);
        }
        // mostramos los archivos //
        Console.WriteLine("ARCHIVOS DENTRO:");
        string[] archivosDentro = Directory.GetFiles(pathIngresado);
        foreach (string archivoEncontrado in archivosDentro)
        {
            // creamos un objeto file info para obtener informacion del archivos //
            FileInfo archivo = new FileInfo(archivoEncontrado);
            decimal tamanoKb = (decimal)archivo.Length / 1000;
            tamanoKb = Math.Round(tamanoKb);
            Console.WriteLine($"ARCHIVO: {archivo.Name} -- {tamanoKb} KB");
        }
    }
    else
    {
        Console.WriteLine("no se encontro el directorio, porfavor ingrese un path existente");
    }
}
