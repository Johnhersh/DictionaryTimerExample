using WebApplication1;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var taskingManager = new TaskingManager();

await taskingManager.StartAsync();

app.Run();

await taskingManager.StopAsync();