// See https://aka.ms/new-console-template for more information
using Google.Cloud.Storage.V1;
using SubirDatosBot.Helpers;
using SubirDatosBot.Models;
using SubirDatosBot.Repositories;

string path = AppDomain.CurrentDomain.BaseDirectory + @"subidadatosbot.json";
Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

var client = StorageClient.Create();

// Create a bucket with a globally unique name
var bucketName = "subidadatosbot.appspot.com";

//UrlSigner urlSigner = UrlSigner.FromCredentialFile(path);
//string url = await urlSigner.SignAsync(bucketName, "file1.txt", TimeSpan.FromDays(7));

//Subir categorias
List<Categoria> categoriaPlatosList = JsonFileUtils.ReadJson<List<Categoria>>("Categorias");

foreach (var categoria in categoriaPlatosList)
{
    CategoriaRepository categoriaPlatosRepository = new();

    categoriaPlatosRepository.AddWithCustomId(categoria);

    string filetoUpload = AppDomain.CurrentDomain.BaseDirectory + categoria.ImgPath;

    using var fileStream = new FileStream(filetoUpload, FileMode.Open, FileAccess.Read, FileShare.Read);
    Google.Apis.Storage.v1.Data.Object uploadResp = client.UploadObject(bucketName, categoria.ImgPath, "image/jpeg", fileStream);

}
//Fin subir categorias.


//Subir Platos
List<Carta> cartaList = JsonFileUtils.ReadJson<List<Carta>>("Carta");

foreach (var carta in cartaList)
{
    CartaRepository cartaRepository = new();

    cartaRepository.Add(carta);

    string filetoUpload = AppDomain.CurrentDomain.BaseDirectory + carta.ImgPath;

    using var fileStream = new FileStream(filetoUpload, FileMode.Open, FileAccess.Read, FileShare.Read);
    Google.Apis.Storage.v1.Data.Object uploadResp = client.UploadObject(bucketName, carta.ImgPath, "image/jpeg", fileStream);

}
//Fin subir platos


//Subir Logo
string logoFile = AppDomain.CurrentDomain.BaseDirectory + "imgs/logo.jpg";

using var logoFileStream = new FileStream(logoFile, FileMode.Open, FileAccess.Read, FileShare.Read);
Google.Apis.Storage.v1.Data.Object logoUploadResp = client.UploadObject(bucketName, "imgs/logo", "image/jpeg", logoFileStream);
//Fin subir logo