namespace KidsFun.WebApi.Dtos
{
    public class TaskAssignmentDto
    {
        public DateTime Due { get; set; }
        public DateTime Created { get; set; }

        public int AssigneeId { get; set; }

        public int TaskTypeId { get; set; }
    }
}