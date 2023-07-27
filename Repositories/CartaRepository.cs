using SubirDatosBot.Models;

namespace SubirDatosBot.Repositories
{
    public class CartaRepository : IFirestoreRepository<Carta>
    {
        private readonly string CollectionName = "Carta";
        private readonly FirestoreRepository firestoreRepository;

        public CartaRepository()
        {
            firestoreRepository = new FirestoreRepository(CollectionName);
        }

        public Carta Add(Carta carta) => firestoreRepository.Add(carta);

        public Carta AddWithCustomId(Carta model)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Carta carta) => firestoreRepository.Delete(carta);

        public List<Carta> FilterEqual(string row, string value)
        {
            throw new NotImplementedException();
        }

        public Carta Get(Carta carta) => firestoreRepository.Get(carta);

        public List<Carta> GetAll() => firestoreRepository.GetAll<Carta>();

        public bool Update(Carta carta) => firestoreRepository.Update(carta);

    }
}
