using System.ComponentModel.DataAnnotations;

namespace KidsFun.Models
{
    public record TaskType
    {
        [Required(ErrorMessage = "Id is required.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Id is required.")]
        public string Name { get; set; }

        public TaskCategory Category { get; set; }

        [Required(ErrorMessage = "WorkingHours is required.")]
        public int WorkingHours { get; set; }

        //RewardPoints per WorkingHours
        [Required(ErrorMessage = "RewardPointsPerHour is required.")]
        public int RewardPoints { get; set; }

        public int TotalRewardPoints => WorkingHours * RewardPoints;

        [Required(ErrorMessage = "MinimumAge is required.")]
        public int MinimumAge { get; set; }
    }

    public enum TaskCategory
    {
        Homework,
        SkillPractice,
        CleanUp,
        //Other Tasktype here
    }
}