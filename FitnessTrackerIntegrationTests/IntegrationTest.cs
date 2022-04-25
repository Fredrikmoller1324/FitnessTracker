using FitnessTracker.Data;
using FitnessTracker.Entities;
using FitnessTracker.Entities.DTOs;
using FitnessTrackerIntegrationTests.Data;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;


namespace FitnessTrackerIntegrationTests
{
    public class IntegrationTest
    {
        protected readonly HttpClient _client;
      
        protected IntegrationTest()
        {
            var appFactory = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        // Removes all contexts that uses Sql-server database from program.cs
                        services.RemoveAll(typeof(DbContextOptions<DataContext>));

                        // Creates an InMemoryDatabase for integration test purpuses,
                        // could also configure a new connectionstring to diffrent testdatabase
                        services.AddDbContext<DataContext>(options =>
                        {
                            options.UseInMemoryDatabase("TestDb");
                        });

                        var serviceProvider = services.BuildServiceProvider();
                        
                        using (var scope = serviceProvider.CreateScope())
                        {
                            var scopedServices = scope.ServiceProvider;
                            var context = scopedServices.GetRequiredService<DataContext>();

                            // Reinitilizes InMemoryDatabase for every controller
                            context.Database.EnsureDeleted();
                            context.Database.EnsureCreated();
                            SeedDatabase(context);
                        }
                    });
                });
            _client = appFactory.CreateClient();
            
         
        }

        protected async Task<Exercise> CreateExercicseAsync(ExerciseDTO exercise)
        {
            var response = await _client.PostAsJsonAsync("https://localhost:7146/api/Exercise/CreateExercise", exercise);
            return await response.Content.ReadFromJsonAsync<Exercise>();
        }

        private void SeedDatabase(DataContext context)
        {
            // Clear tables
            context.RemoveRange(context.Exercises);
            context.RemoveRange(context.ExerciseCategories);

            // Adds to tables
            var exercices = InMemoryDbData.GetExercisesData();
            context.Exercises.AddRange(exercices);

            var exercisecategories = InMemoryDbData.GetExerciseCategories();
            context.ExerciseCategories.AddRange(exercisecategories);

            context.SaveChanges();
            
        }
    }
}
