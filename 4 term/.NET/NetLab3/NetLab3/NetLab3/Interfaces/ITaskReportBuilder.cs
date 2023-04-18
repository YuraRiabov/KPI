namespace NetLab3.Interfaces;

public interface ITaskReportBuilder : IReportBuilder
{
    public IMainPartReportBuilder ForTask(string task);
}