using System.Text;
using clases;
FileStream archivo = File.Open("archivo.mp3", FileMode.Open);
archivo.Seek(-128, SeekOrigin.End);
// arreglos de bytes para ir guardando la informacion //
byte[] header = new byte[3];
byte[] titulo = new byte[30];
byte[] Artista = new byte[30];
byte[] Album = new byte[30];
byte[] anio = new byte[4];
byte[] comentario = new byte[30];
byte[] genero = new byte[1];
// vamos leyendo el archivo y almacenando en cada arreglo //
archivo.Read(header, 0, 3);
archivo.Read(titulo, 0, 30);
archivo.Read(Artista, 0, 30);
archivo.Read(Album, 0, 30);
archivo.Read(anio, 0, 4);
archivo.Read(comentario, 0, 30);
archivo.Read(genero, 0, 1);
// convertimos los arreglos de bytes a cadenas de caracteres //
string headerTitulo = Encoding.ASCII.GetString(titulo);
string headerArtista = Encoding.ASCII.GetString(Artista);
string headerAlbum = Encoding.ASCII.GetString(Album);
string headerAnio = Encoding.ASCII.GetString(anio);
// creamos el objeto y lo mostramos //
Id3v1Tag tag = new Id3v1Tag(headerTitulo, headerArtista, headerAlbum, headerAnio);
tag.mostrarMetadatos();

