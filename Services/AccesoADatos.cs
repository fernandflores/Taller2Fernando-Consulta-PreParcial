using System.Text.Json;
using APIRest.Services;

public class AccesoADatos : IAccesoADatos
{
    private readonly string _ruta;
    public AccesoADatos()
    {
        _ruta = "Conductores.json";
    }
    public List<Conductores> LeerArchivo()
    {
        string CadenaConductores;
        using (var archivoOpnen = new FileStream(_ruta, FileMode.Open))
        {
            using (var aux = new StreamReader(archivoOpnen))
            {
                CadenaConductores=aux.ReadToEnd();
                archivoOpnen.Close();
            }
        }
        var ListaConductores= JsonSerializer.Deserialize<List<Conductores>>(CadenaConductores);
        return ListaConductores;
    }
    public void GuardarArchivo(List<Conductores> ListaConductores)
    {
        string ListaConductoresString= JsonSerializer.Serialize(ListaConductores);
        File.Delete(_ruta);
        FileStream archivo= new FileStream (_ruta, FileMode.OpenOrCreate);
        using (StreamWriter streamWriter= new StreamWriter(archivo))
        {
            streamWriter.WriteLine("{0}", ListaConductoresString);
            streamWriter.Close();
        }
    }
}