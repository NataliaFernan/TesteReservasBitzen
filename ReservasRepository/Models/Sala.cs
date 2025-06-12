namespace ReservasRepository.Models
{
    public class Sala
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Capacidade { get; set; }
        public DateTimeOffset DataCriacao { get; set; } 
        public bool Ativo { get; set; }    
    }
}
