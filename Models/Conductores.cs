using System.Text.Json.Serialization;

public class Conductores
{
    private int id;
    private string nombre;
    private string vehiculo;
    private DateTime fechaIngreso;
    private List<Calificacion> calificaciones;

    public Conductores()
    {
    }
    public Conductores(int id, string nombre, string vehiculo, DateTime ingreso){
        this.id=id;
        this.nombre=nombre;
        this.vehiculo=vehiculo;
        fechaIngreso=ingreso;
        Calificaciones=new List<Calificacion>();
    }
    [JsonPropertyName("Id")]
    public int Id { get => id; set => id = value; }
    [JsonPropertyName("Nombre")]
    public string Nombre { get => nombre; set => nombre = value; }
    [JsonPropertyName("Vehiculo")]
    public string Vehiculo { get => vehiculo; set => vehiculo = value; }
    [JsonPropertyName("FechaIngreso")]
    public DateTime FechaIngreso { get => fechaIngreso; set => fechaIngreso = value; }
    [JsonPropertyName("Calificaciones")]
    public List<Calificacion> Calificaciones { get => calificaciones; set => calificaciones = value; }
    

    
}

 