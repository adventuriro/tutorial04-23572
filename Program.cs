using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var animals = new List<Animal>();
var visits = new List<Visit>();

app.MapGet("/api/animals", () =>
{
    return Results.Ok(animals);
});

app.MapGet("/api/animals/{id}", (int id) =>
{
    var animal = animals.Find(a => a.Id == id);
    if (animal == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(animal);
});

app.MapPost("/api/animals", (Animal animal) =>
{
    animal.Id = animals.Count + 1;
    animals.Add(animal);
    return Results.Created($"/api/animals/{animal.Id}", animal);
});

app.MapPut("/api/animals/{id}", (int id, Animal updatedAnimal) =>
{
    var animal = animals.Find(a => a.Id == id);
    if (animal == null)
    {
        return Results.NotFound();
    }
    animal.Name = updatedAnimal.Name;
    animal.Category = updatedAnimal.Category;
    animal.Weight = updatedAnimal.Weight;
    animal.FurColor = updatedAnimal.FurColor;
    return Results.Ok(animal);
});

app.MapDelete("/api/animals/{id}", (int id) =>
{
    var animal = animals.Find(a => a.Id == id);
    if (animal == null)
    {
        return Results.NotFound();
    }
    animals.Remove(animal);
    return Results.NoContent();
});

app.MapGet("/api/animals/{id}/visits", (int id) =>
{
    var animalVisits = visits.FindAll(v => v.AnimalId == id);
    return Results.Ok(animalVisits);
});

app.MapPost("/api/animals/{id}/visits", (int id, Visit visit) =>
{
    var animal = animals.Find(a => a.Id == id);
    if (animal == null)
    {
        return Results.NotFound();
    }
    visit.Id = visits.Count + 1;
    visit.AnimalId = id;
    visits.Add(visit);
    return Results.Created($"/api/animals/{id}/visits/{visit.Id}", visit);
});

app.Run();

public class Animal
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public double Weight { get; set; }
    public string FurColor { get; set; }
    public string Color { get; set; }
}

public class Visit
{
    public int Id { get; set; }
    public int AnimalId { get; set; }
    public DateTime DateOfVisit { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
}
