using TodoApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

// add Controller assistence 
builder.Services.AddControllers();

// register in memory repository
builder.Services.AddSingleton<ITodoRepository, InMemoryTodoRepository>();

// activate swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// show swagger UI
app.UseSwagger();
app.UseSwaggerUI();

// HTTPS redirection
app.UseHttpsRedirection();

// authorization Middleware
app.UseAuthorization();

// activate all controller routes
app.MapControllers();

// run application
app.Run();
