namespace clases
{
    public class Id3v1Tag
    {
        public Id3v1Tag(string titulo, string artista, string album, string anioPublicacion)
        {
            Titulo = titulo;
            Artista = artista;
            Album = album;
            AnioPublicacion = anioPublicacion;
        }

        public string Titulo { get; set; }
        public string Artista { get; set; }
        public string Album { get; set; }
        public string AnioPublicacion { get; set; }

        // metodo para mostrar el tag //
        public void mostrarMetadatos()
        {
            Console.WriteLine($"TITULO: {Titulo}");
            Console.WriteLine($"ARTISTA: {Artista}");
            Console.WriteLine($"ALBUM: {Album}");
            Console.WriteLine($"AÑO DE LA CANCION: {AnioPublicacion}");
        }
    }
}