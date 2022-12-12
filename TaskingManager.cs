using DictionaryAwait;

namespace WebApplication1;

public class TaskingManager
{
    private Task? _timerTask;
    private readonly PeriodicTimer _refreshEventsTimer;
    private readonly Dictionary<string, Func<FinishUpgradeTask>> _messageMap;

    public TaskingManager()
    {
        _messageMap = new Dictionary<string, Func<FinishUpgradeTask>>
        {
            { "UpgradeMessage", () => new FinishUpgradeTask() },
        };
        _refreshEventsTimer = new PeriodicTimer(TimeSpan.FromMilliseconds(1000));
    }
    
    public async Task StartAsync()
    {
        _timerTask = StartTimer();
    }

    public async Task StopAsync()
    {
        _refreshEventsTimer.Dispose();
        if (_timerTask is not null) await _timerTask;
    }
    
    private async Task StartTimer()
    {
        while (await _refreshEventsTimer.WaitForNextTickAsync())
        {
            Console.WriteLine($"{DateTime.UtcNow}: Processing events");
            var upgradeId = "Upgrade2";
            var payLoad = "Some message";
            await _messageMap["UpgradeMessage"].Invoke().Execute(upgradeId, payLoad);
        }
    }
}