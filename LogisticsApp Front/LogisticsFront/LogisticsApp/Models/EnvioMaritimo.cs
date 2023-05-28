namespace LogisticsApp.Models
{
    public class EnvioMaritimo
    {
        public int Id { get; set; }
        public string TipoProducto { get; set; }
        public int CantidadProducto { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaEntrega { get; set; }
        public string PuertoId { get; set; }
        public Puerto Puerto { get; set; }
        public decimal PrecioEnvio { get; set; }
        public string NumeroFlota { get; set; }
        public string NumeroGuia { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
    }
}
