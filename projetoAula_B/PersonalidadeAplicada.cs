using Newtonsoft.Json;

namespace projetoAula_B
{
    public class PersonalidadeAplicada
    {
        [JsonProperty("razao_social")]
        public string RazaoSocial { get; set; }
        [JsonProperty("cnpj")]
        public string CNPJ { get; set; }
        [JsonProperty("nome_motorista")]
        public string NomeMotorista { get; set; }
        [JsonProperty("cpf")]
        public string CPF { get; set; }
        [JsonProperty("vigencia_do_cadastro")]
        public DateTime VigenciaCadastro { get; set; }
    }
}
