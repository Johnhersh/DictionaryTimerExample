using WebApplication1;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var taskingManager = new TaskingManager();

var cancellationToken = new CancellationToken();
await taskingManager.StartAsync(cancellationToken);

app.Run();

var stopCancellationToken = new CancellationToken();
await taskingManager.StopAsync(stopCancellationToken);