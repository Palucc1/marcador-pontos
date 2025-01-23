using IoC;
using Microsoft.Extensions.Options;
using Repository.Context;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddCors(options => options.AddPolicy("AllowCors", builder =>
        {
            builder.WithOrigins("http://localhost:4200")
                   .AllowAnyMethod()
                   .AllowAnyHeader()
                   .AllowCredentials();  
        }));

        builder.Services.AddControllers();

        builder.Services.AddDbContext<DataContext>();
        builder.Services.AddInjectionContainer();

        builder.Services.AddOpenApi();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.UseCors("AllowCors");

        app.MapControllers();

        app.Run();
    }
}