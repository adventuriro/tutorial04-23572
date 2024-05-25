// This call to WebApplication.CreateBuilder() creates an object that represents our application.
// This variable allows our application to be configured before it will be executed.
// This follows the Builder pattern, a classic design pattern in object-oriented programming.
var builder = WebApplication.CreateBuilder(args);

// We define the elements in the IoC (Inversion of Control) container.
// Add services to the container.
builder.Services.AddControllers(); // Registers controllers for handling HTTP requests.
builder.Services.AddEndpointsApiExplorer(); // Adds support for API exploration.
builder.Services.AddSwaggerGen(); // Adds support for Swagger/OpenAPI documentation generation.

// This .Build() method returns an application that is being configured according to what we have previously defined.
var app = builder.Build();

// 2. Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // This element sets up Swagger for API documentation generation.
    app.UseSwagger();
    // This element sets up Swagger UI for visually exploring and interacting with the API documentation.
    app.UseSwaggerUI();
}

app.UseHttpsRedirection(); // Redirects HTTP requests to HTTPS for secure communication.

// Minimal API
// Define API endpoints using a more concise syntax known as Minimal API.
// Here, app.MapControllers() sets up routing based on controller actions and attributes.
app.MapControllers();

// The app.Run() method is used to configure the application's request processing pipeline.
// In this context, it indicates the end of configuring the pipeline.
app.Run();