using Model;
using System.Text.Json;

namespace Server.Services
{
    public class DataService
    {
        private string JsonUrl = @"Database\Data.json";

        internal async Task RewriteJson(List<InfoCard> data)
        {
            try
            {
                FileStream fileStream = new FileStream(JsonUrl, FileMode.Create, FileAccess.Write);
                JsonSerializerOptions options = new JsonSerializerOptions();
                options.WriteIndented = true;
                await JsonSerializer.SerializeAsync(fileStream, data, options);
                fileStream.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка сериализации!");
                Console.WriteLine(ex.Message);
            }
        }

        internal List<InfoCard>? GetDataFromJson()
        {
            try
            {
                FileStream fileStream = new FileStream(JsonUrl, FileMode.Open, FileAccess.Read);
                List<InfoCard>? data = JsonSerializer.Deserialize<List<InfoCard>>(fileStream);
                fileStream.Close();
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка получения данных из JSON-файла!");
                Console.WriteLine(ex.Message);
                return null;
            }
            
        }

    }
}
