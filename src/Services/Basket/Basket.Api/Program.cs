var builder = WebApplication.CreateBuilder(args);
//Add Services to container
var app = builder.Build();

//Configure HTTP request Pipeline

app.Run();
