namespace LogisticsApp.Models
{
    public class EnvioTerresteViewModel
    {
        public IEnumerable<Bodega> Bodegas { get; set; }
        public IEnumerable<Cliente> Clientes { get; set; }
        public IEnumerable<Producto> Productos { get; set; }
        public EnvioTerrestre EnvioTerrestre { get; set; }
    }
}
