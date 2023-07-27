using System.Text.Json;

namespace SubirDatosBot.Helpers
{
    public static class JsonFileUtils
    {
        public static T ReadJson<T>(string fileName)
        {
            using StreamReader r = new(fileName + ".json");
            string json = r.ReadToEnd();

            return JsonSerializer.Deserialize<T>(json);

        }

    }
}
