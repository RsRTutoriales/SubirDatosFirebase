using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubirDatosBot.Models
{
    [FirestoreData]
    public class Carta : FirebaseDocument
    {
        [FirestoreProperty]
        public string Title { get; set; } = string.Empty;

        [FirestoreProperty]
        public string Description { get; set; } = string.Empty;

        [FirestoreProperty]
        public int Order { get; set; }

        [FirestoreProperty]
        public double Price { get; set; }

        [FirestoreProperty]
        public string ImgPath { get; set; } = string.Empty;

        [FirestoreProperty]
        public string IdCategory { get; set; } = string.Empty;

        [FirestoreProperty]
        public string Type { get; set; } = string.Empty;

    }
}
