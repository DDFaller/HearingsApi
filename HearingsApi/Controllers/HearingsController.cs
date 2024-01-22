using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace HearingsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HearingsController : ControllerBase
    {
        // Load hearings from the JSON file
        List<Hearing> hearings = HearingLoader.LoadHearingsFromJsonFile("data.json");

        private readonly ILogger<HearingsController> _logger;

        public HearingsController(ILogger<HearingsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("Get")]
        public IEnumerable<Hearing> Get()
        {
            return hearings.ToArray();
        }
        [HttpGet]
        [Route("GetFromDB")]
        public IEnumerable<Hearing> GetFromDB()
        {
            string connectionString = "Server=tcp:hearings.database.windows.net,1433;Initial Catalog=hearings;Persist Security Info=False;User ID=hearings-admin;Password=lumacaD@0812;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Use the connection to interact with the database
                // Defina sua consulta SQL
                string sqlQuery = "SELECT * FROM [dbo].[hearingsVillemor]";

                // Inicialize a lista para armazenar os resultados
                List<Hearing> hearingsList = new List<Hearing>();

                connection.Open();

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    // Execute a consulta
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Verifique se há linhas retornadas
                        while (reader.Read())
                        {
                            // Mapeie os resultados para o objeto Hearing (ajuste conforme necessário)
                            Hearing hearing = new Hearing
                            {
                                // Mapeie cada coluna para a propriedade correspondente do objeto Hearing
                                ProcessNumber = reader.GetString(reader.GetOrdinal("processNumber")),
                                Date = reader.GetString(reader.GetOrdinal("date")),
                                Court = reader.GetString(reader.GetOrdinal("court")),
                                Correspondent = reader.GetString(reader.GetOrdinal("correspondent")),

                                // Adicione outras propriedades conforme necessário
                            };

                            // Adicione o objeto Hearing à lista
                            hearingsList.Add(hearing);
                        }
                    }
                }
                connection.Close();
                return hearingsList;
            } 
        }

    }
}
