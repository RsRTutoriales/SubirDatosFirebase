using Google.Cloud.Firestore;

namespace SubirDatosBot.Models
{
    [FirestoreData]
    public class Categoria : FirebaseDocument
    {
        [FirestoreProperty]
        public string Title { get; set; } = string.Empty;

        [FirestoreProperty]
        public string Description { get; set; } = string.Empty;

        [FirestoreProperty]
        public int Order { get; set; }

        [FirestoreProperty]
        public string ImgPath { get; set; } = string.Empty;
    }
}
