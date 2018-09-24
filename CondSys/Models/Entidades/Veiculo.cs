namespace CondSys.Models.Entidades
{
    public class Veiculo
    {
        public int Id { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string Placa { get; set; }
        public Usuario Usuario { get; set; }
    }
}