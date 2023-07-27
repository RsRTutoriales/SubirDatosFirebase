using Google.Cloud.Firestore;
using SubirDatosBot.Models;

namespace SubirDatosBot.Repositories
{
    public class FirestoreRepository
    {

        private readonly string CollectionName;
        public FirestoreDb firestoreDb;

        public FirestoreRepository(string CollectionName)
        {

            string path = AppDomain.CurrentDomain.BaseDirectory + @"subidadatosbot.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

            firestoreDb = FirestoreDb.Create("subidadatosbot");

            this.CollectionName = CollectionName;

        }

        public T Get<T>(T model) where T : FirebaseDocument
        {
            try
            {
                DocumentReference getDocument = firestoreDb.Collection(CollectionName).Document(model.Id);
                DocumentSnapshot snapshot = getDocument.GetSnapshotAsync().GetAwaiter().GetResult();
                if (snapshot.Exists)
                {
                    T usr = snapshot.ConvertTo<T>();
                    usr.Id = snapshot.Id;
                    return usr;
                }
                else
                {
                    return model;
                }
            }
            catch
            {
                return model;
            }
        }

        public List<T> GetAll<T>() where T : FirebaseDocument
        {
            List<T> list = new();
            try
            {
                Query query = firestoreDb.Collection(CollectionName);
                QuerySnapshot querySnapshot = query.GetSnapshotAsync().GetAwaiter().GetResult();
                foreach (DocumentSnapshot documentSnapshot in querySnapshot.Documents)
                {
                    if (documentSnapshot.Exists)
                    {
                        T newItem = documentSnapshot.ConvertTo<T>();
                        newItem.Id = documentSnapshot.Id;

                        //Dictionary<string, object> city = documentSnapshot.ToDictionary();
                        //string json = JsonConvert.SerializeObject(city);
                        //T newItem = JsonConvert.DeserializeObject<T>(json);
                        //newItem.Id = documentSnapshot.Id;
                        list.Add(newItem);
                    }
                }

                return list;
            }
            catch
            {
                return list;
            }
        }

        public T Add<T>(T model) where T : FirebaseDocument
        {
            try
            {
                CollectionReference collectionReference = firestoreDb.Collection(CollectionName);
                DocumentReference newDocument = collectionReference.AddAsync(model).GetAwaiter().GetResult();
                model.Id = newDocument.Id;
                return model;
            }
            catch
            {
                return model;
            }
        }

        public T AddWithCustomId<T>(T model) where T : FirebaseDocument
        {
            try
            {
                CollectionReference collectionReference = firestoreDb.Collection(CollectionName);
                WriteResult newDocument = collectionReference.Document(model.Id).SetAsync(model).GetAwaiter().GetResult();
                
                return model;
            }
            catch
            {
                return model;
            }
        }

        public bool Update<T>(T model) where T : FirebaseDocument
        {
            try
            {
                DocumentReference getDocument = firestoreDb.Collection(CollectionName).Document(model.Id);
                getDocument.SetAsync(model, SetOptions.MergeAll).GetAwaiter().GetResult();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete<T>(T model) where T : FirebaseDocument
        {
            try
            {
                DocumentReference getDocument = firestoreDb.Collection(CollectionName).Document(model.Id);
                getDocument.DeleteAsync().GetAwaiter().GetResult();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<T> FilterEqual<T>(string row, string value) where T : FirebaseDocument
        {
            List<T> list = new();

            try
            {
                CollectionReference modelRef = firestoreDb.Collection(CollectionName);
                Query query = modelRef.WhereEqualTo(row, value);
                QuerySnapshot querySnapshot = query.GetSnapshotAsync().GetAwaiter().GetResult();
                foreach (DocumentSnapshot documentSnapshot in querySnapshot.Documents)
                {
                    if (documentSnapshot.Exists)
                    {
                        T newItem = documentSnapshot.ConvertTo<T>();
                        newItem.Id = documentSnapshot.Id;
                        list.Add(newItem);
                    }
                }
                return list;
            }
            catch
            {
                return list;
            }
        }

        public List<T> FilterEqual<T>(string row, double value) where T : FirebaseDocument
        {
            List<T> list = new();

            try
            {
                CollectionReference modelRef = firestoreDb.Collection(CollectionName);
                Query query = modelRef.WhereEqualTo(row, value);
                QuerySnapshot querySnapshot = query.GetSnapshotAsync().GetAwaiter().GetResult();
                foreach (DocumentSnapshot documentSnapshot in querySnapshot.Documents)
                {
                    if (documentSnapshot.Exists)
                    {
                        T newItem = documentSnapshot.ConvertTo<T>();
                        newItem.Id = documentSnapshot.Id;
                        list.Add(newItem);
                    }
                }
                return list;
            }
            catch
            {
                return list;
            }
        }

    }
}
