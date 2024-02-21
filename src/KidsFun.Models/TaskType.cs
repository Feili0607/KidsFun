namespace KidsFun.Models
{
    public record TaskType
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool? skillPractice { get; set; }

        public bool? homework { get; set; }

        public bool? cleanUp { get; set; }

        public int workingHours { get; set; }

        public int rewardPoints { get; set; }

        public int suggestAge { get; set; }
    }
}