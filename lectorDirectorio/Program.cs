// bucle hasta que se ingrese un path valido //
using System.Text;

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
        // para salir del bucle //
        existePath = true;

        DirectoryInfo directorio = new DirectoryInfo(pathIngresado);

        // obtenemos y mostramos todos los subdirectorios //
        DirectoryInfo[] subdirectorios = directorio.GetDirectories();
        // verificamos que si haya subdirectorios //
        Console.WriteLine("================= SUBDIRECTORIOS ==================");
        if (subdirectorios.Length != 0)
        {
            foreach (DirectoryInfo subdirectorio in subdirectorios)
            {
                Console.WriteLine($"NOMBRE: {subdirectorio.Name}");
            }
        }
        else
        {
            Console.WriteLine("no hay subdirectorios dentro del directorio");
        }

        // obtenemos y mostramos los archivos dentro del directorio //
        FileInfo[] archivos = directorio.GetFiles();
        // verificamos que si haya archivos //
        Console.WriteLine("================= ARCHIVOS ==================");
        if (archivos.Length != 0)
        {
            foreach (FileInfo archivo in archivos)
            {
                // obtenemos el tamaño en bytes del archivo //
                long tamanoBytes = archivo.Length;
                // lo convertimos a kilobytes //
                decimal tamanoKilobytes = (decimal)tamanoBytes / 1024;
                Console.WriteLine($"NOMBRE: {archivo.Name} / TAMAÑO: {tamanoKilobytes:F2} KB");
            }
        }
        else
        {
            Console.WriteLine("no hay archivos dentro del directorio");
        }

        // creamos el archivo //
        string ruta = Path.Combine(pathIngresado, "reporte_archivos.csv");
        FileStream archivoCsv = File.Open(ruta, FileMode.Create);
        // para mostrar a que hace referencia cada columna //
        string header = $"NOMBRE, TAMAÑO, ULTIMA FECHA DE MODIFICACION{Environment.NewLine}";
        byte[] cadenaHeaderByte = Encoding.UTF8.GetBytes(header);
        archivoCsv.Write(cadenaHeaderByte);

        // usamos foreach para obtener las cadenas que vamos a guardar //
        foreach (FileInfo archivo in archivos)
        {
            string nombreArchivo = archivo.Name;
            long tamanoBytes = archivo.Length;
            decimal tamanoKilobytes = (decimal)tamanoBytes / 1024;
            string ultimaFechaModificacion = archivo.LastWriteTime.ToString("dd/MM/yyyy HH:mm:ss");
            string cadenaArchivo = $"{nombreArchivo}, {tamanoKilobytes:F2} KB, {ultimaFechaModificacion}{Environment.NewLine}";
            byte[] cadenaArchivoByte = Encoding.UTF8.GetBytes(cadenaArchivo);
            archivoCsv.Write(cadenaArchivoByte);
            archivoCsv.Flush();
        }
        
    }
    else
    {
        Console.WriteLine("no se encontro el directorio, porfavor ingrese un path existente");
    }
}
