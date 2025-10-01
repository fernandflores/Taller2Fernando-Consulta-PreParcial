namespace APIRest.Services
{
    public interface IAccesoADatos
    {
        List<Conductores> LeerArchivo();
        void GuardarArchivo(List<Conductores> ListaConductores);
    }
}
