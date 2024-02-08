using KidsFun.Models;

namespace KidsFun.Core;

public class AssignmentManager : IAssignmentManager
{
    private readonly IAssignmentRepository _repository;
    private readonly IKidsRepository _kidsRepository;

    private readonly ITaskRepository _taskRepository;

    public AssignmentManager(IAssignmentRepository repository, IKidsRepository kidsRepository, ITaskRepository taskRepository)
    {
        _repository = repository;
        _kidsRepository = kidsRepository;
        _taskRepository = taskRepository;
    }

    public async Task AssignAsync(int taskId, int kidId)
    {
        var kidDetail = await _kidsRepository.GetAsync(kidId);
        var task = await _taskRepository.GetAsync(taskId);
        var newAssingment = new TaskAssignment
        {
            KidId = kidId,
            Kid = kidDetail,
            TypeId = taskId,
            Type = task,
            Status = Models.TaskStatus.Assigned,
            Created = DateTime.Now
        };
        
        await _repository.AddAsync(newAssingment);
    }

    public async Task<IEnumerable<TaskAssignment>> LoadAsync(int kidId)
    {
        if (kidId <= 0)
            throw new ArgumentException(nameof(kidId));

        return await _repository.LoadAsync(kidId);
    }

    public async Task UnassignAsync(int assignmentId)
    {
       await _repository.DeleteAsync(assignmentId);
    }
}
