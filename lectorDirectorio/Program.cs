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
        // creamos un objeto directoryInfo para tener informacion del directorio //
        DirectoryInfo directorio = new DirectoryInfo(pathIngresado);
        Console.WriteLine($"=================== {pathIngresado} =================");
        // mostramos las carpetas //
        Console.WriteLine("CARPETAS DENTRO:");
        DirectoryInfo[] subdirectorios = directorio.GetDirectories();
        foreach (DirectoryInfo subdirectorio in subdirectorios)
        {
            Console.WriteLine(subdirectorio.Name);
        }
        // mostramos los archivos //
        Console.WriteLine("ARCHIVOS DENTRO:");
        FileInfo[] archivosEnDirectorio = directorio.GetFiles();
        foreach (FileInfo archivo in archivosEnDirectorio)
        {
            decimal tamanoKb = (decimal)archivo.Length / 1000;
            tamanoKb = Math.Round(tamanoKb);
            Console.WriteLine($"ARCHIVO: {archivo.Name} -- {tamanoKb} KB");
        }

        // creamos el archivo csv en el directorio //
        string pathArchivoReporte = @$"{pathIngresado}\reporte_archivos.csv";
        string contenidoArchivoReporte = string.Empty;
        foreach (FileInfo archivo in archivosEnDirectorio)
        {
            decimal tamanoKb = (decimal)archivo.Length / 1000;
            tamanoKb = Math.Round(tamanoKb);
            contenidoArchivoReporte += $"{archivo.Name}, {tamanoKb} KB, {archivo.LastWriteTime.Day}/{archivo.LastWriteTime.Month}/{archivo.LastWriteTime.Year} - {archivo.LastWriteTime.Hour}:{archivo.LastWriteTime.Minute} \n";
        }
        File.WriteAllText(pathArchivoReporte, contenidoArchivoReporte);
    }
    else
    {
        Console.WriteLine("no se encontro el directorio, porfavor ingrese un path existente");
    }
}
