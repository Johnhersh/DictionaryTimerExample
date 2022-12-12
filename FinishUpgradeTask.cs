namespace DictionaryAwait;

public class FinishUpgradeTask
{
    private readonly Dictionary<string, Func<string, Task>> _messageMap;

    public FinishUpgradeTask()
    {
        _messageMap = new Dictionary<string, Func<string, Task>>
        {
            { "Upgrade1", Upgrade1 }
        };
    }

    public async Task Execute(string upgradeId, string payLoad)
    {
        await _messageMap[upgradeId].Invoke(payLoad);
    }
    
    private async Task Upgrade1(string upgradePayload)
    {
        await Task.Run(() => Console.WriteLine($"Running Task: {upgradePayload}"));
    }
}