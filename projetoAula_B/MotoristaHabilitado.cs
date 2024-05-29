using Newtonsoft.Json;

namespace projetoAula_B
{
    public class MotoristaHabilitado
    {
        [JsonProperty("penalidades_aplicadas")]
        public List<PersonalidadeAplicada> PenalidadesAplicadas { get; set; }
    }
}
