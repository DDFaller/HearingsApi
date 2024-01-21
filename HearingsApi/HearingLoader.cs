using Newtonsoft.Json;

namespace HearingsApi
{
    public class HearingLoader
    {
        public static List<Hearing> LoadHearingsFromJsonFile(string? filePath)
        {
            // Read JSON data from the file
            string jsonData = System.IO.File.ReadAllText(filePath);

            // Deserialize JSON data into a list of Hearing objects
            List<Hearing> hearings = JsonConvert.DeserializeObject<List<Hearing>>(jsonData);

            return hearings;
        }
    }
}
