using BackendApi.Entities;
using BackendApi.Models;
using Microsoft.EntityFrameworkCore;
using BackendApi.Helpers;

namespace BackendApi.DbContexts
{
    public class GridInfoContext : DbContext
    {
        public DbSet<Grid> Grids { get; set; }

        public DbSet<Cordinates> Cells { get; set; }

        public GridInfoContext(DbContextOptions<GridInfoContext> options) : base(options) 
        { 

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Grid>().HasData( 
                new Grid("Grid1")
                {
                    Id = 1,
                    Description = "Sample grid"
                },
                  new Grid("Grid2")
                {
                      Id=2,
                    Description = "bra"
                },
                    new Grid("Grid3")
                {
                        Id=3,
                    Description = "udda"
                });
            modelBuilder.Entity<Cordinates>().HasData( 
                new Cordinates("OK")
                {
                   Id = 1,
                   Col = 0,
                   Row = 0,
                   GridId = 1,

                },
                  new Cordinates("OK")
                {
                      Id=2,
                       Col = 0,
                   Row = 0,
                   GridId = 1,
                },
                   new Cordinates("Orörd")
                {
                    Id=3,
                     Col = 0,
                   Row = 0,
                   GridId = 1,
                },
                  new Cordinates("Error")
                {
                    Id=4,
                     Col = 0,
                   Row = 0,
                   GridId = 1,
                },
                   new Cordinates("OK")
                {
                    Id=5,
                     Col = 0,
                   Row = 0,
                   GridId = 1,
           
                },
                  new Cordinates("Orörd")
                {
                    Id=6,
                     Col = 0,
                   Row = 0,
                   GridId = 1,
                },
                  new Cordinates("OK")
                {
                    Id=7,
                     Col = 0,
                   Row = 0,
                   GridId = 1,
                }
                );
            
            base.OnModelCreating(modelBuilder);
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("connectionstring");
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
