using Google.Cloud.Firestore;

namespace SubirDatosBot.Models
{
    public class FirebaseDocument
    {
        [FirestoreDocumentId]
        public string Id { get; set; } = string.Empty;
    }
}
