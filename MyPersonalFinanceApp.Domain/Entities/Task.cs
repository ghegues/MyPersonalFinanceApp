namespace MyPersonalFinanceApp.Domain.Entities
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public StatusTarefa Status { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
    public enum StatusTarefa
    {
        Pendente,
        EmAndamento,
        Concluida
    }
}
