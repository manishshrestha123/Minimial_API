using Microsoft.EntityFrameworkCore;
using RazorPageMinimialAPI.Model;
using System;

namespace RazorPageMinimialAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddRazorPages();
            builder.Services.AddDbContext<MyDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            // Map Minimal API endpoints here
            app.MapGet("/api/students", async (MyDbContext db) =>
                await db.StudentRecords.ToListAsync());

            app.MapGet("/api/students/{id}", async (int id, MyDbContext db) =>
                await db.StudentRecords.FindAsync(id) is Student student
                    ? Results.Ok(student)
                    : Results.NotFound());


            app.MapPost("/api/students", async (Student student, MyDbContext db) =>
            {
                db.StudentRecords.Add(student);
                await db.SaveChangesAsync();
                return Results.Created($"/api/students/{student.Id}", student);
            });

            app.MapPut("/api/students/{id}", async (int id, Student inputStudent, MyDbContext db) =>
            {
                var student = await db.StudentRecords.FindAsync(id);
                if (student is null)
                {
                    return Results.NotFound();
                }
                student.Name = inputStudent.Name;
                student.Age = inputStudent.Age;
                student.Grade = inputStudent.Grade;

                await db.SaveChangesAsync();
                return Results.NoContent();
            });

            app.MapDelete("/api/students/{id}", async (int id, MyDbContext db) =>
            {
                if (await db.StudentRecords.FindAsync(id) is Student student)
                {
                    db.StudentRecords.Remove(student);
                    await db.SaveChangesAsync();
                    return Results.Ok(student);
                }

                return Results.NotFound();
            });


            app.Run();
        }
    }
}
