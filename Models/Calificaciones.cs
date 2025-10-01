using System.Text.Json.Serialization;

public class Calificacion
{
    private int puntuacion;
    private string comentario;

    public Calificacion()
    {
    }
    public Calificacion(int puntuacion, string comentario)
    {
        this.puntuacion=puntuacion;
        this.comentario=comentario;
    }
    [JsonPropertyName("Puntuacion")]
    public int Puntuacion { get => puntuacion; set => puntuacion = value; }
    [JsonPropertyName("Comentario")]
    public string Comentario { get => comentario; set => comentario = value; }
}