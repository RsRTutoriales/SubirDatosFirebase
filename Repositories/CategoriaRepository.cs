using SubirDatosBot.Models;

namespace SubirDatosBot.Repositories
{
    public class CategoriaRepository : IFirestoreRepository<Categoria>
    {

        private readonly string CollectionName = "Categorias";
        private readonly FirestoreRepository firestoreRepository;

        public CategoriaRepository()
        {
            firestoreRepository = new FirestoreRepository(CollectionName);
        }

        public Categoria Add(Categoria categoria) => firestoreRepository.Add(categoria);

        public Categoria AddWithCustomId(Categoria categoria) => firestoreRepository.AddWithCustomId(categoria);

        public bool Delete(Categoria categoria) => firestoreRepository.Delete(categoria);

        public List<Categoria> FilterEqual(string row, string value)
        {
            throw new NotImplementedException();
        }

        public Categoria Get(Categoria categoria) => firestoreRepository.Get(categoria);

        public List<Categoria> GetAll() => firestoreRepository.GetAll<Categoria>();

        public bool Update(Categoria categoria) => firestoreRepository.Update(categoria);

    }
}
