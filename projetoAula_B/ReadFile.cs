using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace projetoAula_B
{
    public class ReadFile
    {
        public static List<PenalidadeAplicada> GetData(string path)
        {
            StreamReader reader = new StreamReader(path);
            string jsonString = reader.ReadToEnd();
            
            var objGeral = JsonConvert.DeserializeObject<MotoristaHabilitado>(jsonString, new IsoDateTimeConverter {DateTimeFormat = "dd/MM/yyyy"});

            if (objGeral != null) return objGeral.PenalidadesAplicadas;
            return null;
        }
    }
}
