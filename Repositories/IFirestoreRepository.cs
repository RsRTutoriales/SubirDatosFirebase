namespace SubirDatosBot.Repositories
{
    public interface IFirestoreRepository<T>
    {
        T Get(T model);
        List<T> GetAll();
        T Add(T model);
        T AddWithCustomId(T model);
        bool Update(T model);
        bool Delete(T model);
        List<T> FilterEqual(string row, string value);
    }
}
