// See https://aka.ms/new-console-template for more information
using SystemTask = System.Threading.Tasks.Task;

var taskCompiler = new TaskCompiler();
taskCompiler.Add(() => CreateTask(1000));
taskCompiler.Add(() => CreateTask(2000));
taskCompiler.Add(() => CreateTask(3000));
taskCompiler.Add(() => CreateTask(4000));
await taskCompiler.Compile(true);
Console.ReadLine();

void CreateTask(int delay)
{
    Thread.Sleep(delay);
    Console.WriteLine(delay);
}

public class TaskCompiler
{
    private readonly List<Task> _tasks;

    public TaskCompiler()
    {
        _tasks = new List<Task>();
    }

    public delegate void Task();

    public void Add(Task task)
    {
        _tasks.Add(task);
    }

    public SystemTask Compile(bool waitAll)
    {
        if (!waitAll)
        {
            _tasks.ForEach(task => SystemTask.Run(() => InternalCompile(task)));
            return SystemTask.CompletedTask;
        }
        
        var tasks = _tasks.Select(task => SystemTask.Run(() => InternalCompile(task)));
        Console.WriteLine("Wait for all tasks");
        return SystemTask.WhenAll(tasks);
    
        void InternalCompile(Task task)
        {
            task.Invoke();
        }
    }
}
