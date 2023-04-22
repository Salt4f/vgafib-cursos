using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace VGAFIBCursos.Models
{
    public class Curso
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("longDescription")]
        public string? LongDescription { get; set; }

        [JsonPropertyName("classroom")]
        public string? Aula { get; set; }

        [JsonPropertyName("time")]
        public string? Horario { get; set; }

        public string? Image { get; set; }

        [JsonPropertyName("plazas")]
        public int? Plazas { get; set; }

        [JsonPropertyName("pathToImage")]
        public string? PathToImage { get; set; }
    }
}
