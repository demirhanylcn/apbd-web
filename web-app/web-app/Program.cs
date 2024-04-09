using web_app.data;

var builder = WebApplication.CreateBuilder(args);
var animals = Records._animals;
var visits = Records._visits;

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Retrieve list of animals
app.MapGet("/api/animals", () => Results.Ok(animals))
    .WithName("GetAnimals")
    .WithOpenApi();
// Retrieve specific animal by id
app.MapGet("/api/animals/{id:int}", (int id) =>
    {
        var animal = animals.FirstOrDefault(animal => animal._id == id);
        return animal == null ? Results.NotFound("Animal not found") : Results.Ok(animal);
    })
    .WithName("GetAnimal")
    .WithOpenApi();
// Add Animal
app.MapPost("/api/animals", (Animal animal) => { animals.Add(animal); })
    .WithName("AddAnimal")
    .WithOpenApi();

// Edit Animal
app.MapPut("/api/animals/{id:int}", (int id,Animal editedAnimal) =>
    {
        var animalToEdit = animals.FirstOrDefault(animal => animal._id == id);
        if (animalToEdit == null)
        {
            return Results.NotFound("Animal not found.");
        }
        animals.Remove(animalToEdit);
        animals.Add(editedAnimal);
        return Results.NoContent();
    })
.WithName("EditAnimal")
.WithOpenApi();

// Delete Animal

app.MapDelete("/api/animals/{id:int}", (int id) =>
    {
        var animalToDelete = animals.FirstOrDefault(animal => animal._id == id);
        if (animalToDelete == null) return Results.NoContent();
        animals.Remove(animalToDelete);
        return Results.NoContent();
    })
    .WithName("DeleteAnimal")
    .WithOpenApi();


// List of visits with given animal
app.MapGet("/api/visits/{id:int}", (int id) =>
    {
        var animalsVisits = new List<Visit>();
        foreach (var visit in visits)
        {
            if (visit._animalVisited == id) animalsVisits.Add(visit);
        }

        if (animalsVisits.Count == 0) return Results.NotFound("No visit is found.");
        return Results.Ok(animalsVisits);
    })
    .WithName("RetrieveListOfVisits")
    .WithOpenApi();
// Add new visit
app.MapPost("/api/visits", (Visit visit) =>
    {
        visits.Add(visit);
        return Results.Ok();
    })
    .WithName("AddVisit")
    .WithOpenApi();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();