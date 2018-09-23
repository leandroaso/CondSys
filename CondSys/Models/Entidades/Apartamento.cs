namespace CondSys.Models.Entidades
{
    public class Apartamento
    {
        public int Id { get; set; }
        public string Bloco { get; set; }
        public int Numero { get; set; }
        public Usuario Usuario { get; set; }
    }
}