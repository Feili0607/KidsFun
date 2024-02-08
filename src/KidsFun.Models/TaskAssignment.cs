namespace KidsFun.Models
{
    public record TaskAssignment
    {

        public Guid Id { get;set; }
        public DateTime Created { get; set; }
        public int KidId { get; set; }
        public KidDetail Kid { get; set; }

        public int TypeId { get; set; }
        public TaskType Type { get; set; }

        public DateTime Due { get; set; }

        public TaskStatus Status { get; set; }

        public int Points { get; set; }

    }
}