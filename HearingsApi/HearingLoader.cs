using Newtonsoft.Json;

namespace HearingsApi
{
    public class HearingLoader
    {
        public static List<Hearings> LoadHearingsFromJsonFile(string? filePath)
        {
            // Read JSON data from the file
            string jsonData = System.IO.File.ReadAllText(filePath);

            // Deserialize JSON data into a list of Hearing objects
            List<Hearings> hearings = JsonConvert.DeserializeObject<List<Hearings>>(jsonData);

            return hearings;
        }
    }
}
