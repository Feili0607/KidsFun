using System.ComponentModel.DataAnnotations;

namespace KidsFun.Models
{
    // Enum to represent different categories of tasks
    public enum TaskCategory
    {
        Homework,
        SkillPractice,
        CleanUp,
        // Add more categories as needed
    }
    public record TaskType
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public int RewardPoints { get; set; }

        public TaskCategory Category { get; set; }

        [Required]
        public int MinimumAge { get; set; }

        // The duration (in minutes, hours, etc.) required to complete this task type
        public int Duration { get; set; }

        [Required]
        public string DifficultyLevel { get; set; }

        // Indicates whether the task type is active or inactive
        public bool IsActive { get; set; }
    }

}