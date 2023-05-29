using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Market
{
    public class Context:DbContext
    {
        public DbSet<Stor> Stors { get; set; }
        public DbSet<Categorys> Categorys { get; set; }
        public DbSet<Proudect> proudcts { get; set; }
        public DbSet<Users> users { get; set; }
        public DbSet<Recipt> recipts { get; set; }
        public DbSet<Sellinvoce> sellinvoces { get; set; }
        public DbSet<Suppliers> suppliers { get; set; }
        public DbSet<Order> orders { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@" Data Source=DESKTOP-NNJMDGE\SQL19; initial catalog = SuperMarket;Integrated Security=True; trust server certificate = true");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Users>().HasData(new[]
            {
                 new Users
                     {
                        Id=10,
                        Salary = 2000,
                        UserName = "Ahmed",
                        Password = "12345",
                        Pos = position.Casher,
                  
                     },
                 new Users
                     {
                     Id=20,
                        Salary = 1000,
                        UserName = "Mahmoud",
                        Password = "2555",
                        Pos = position.Casher,
                  
                     },
                 new Users
                 {
                     Id=30,
                     Salary = 3000,
                     UserName = "Kero",
                     Password = "11111",
                     Pos = position.Admin,
             
                 }
            });


            //Suppliers
            modelBuilder.Entity<Suppliers>().HasData(new[]
            {
                new Suppliers
                {
                Id = 1,
                Name = "johinaa",
                Phone = "01028574231",
     
                },
                new Suppliers
                {
                 Id = 2,
                Name = "almraie",
                Phone = "01055688224",
          
                },
                new Suppliers
                {
                 Id = 3,
                Name = "atyab",
                Phone = "0104567432",
       
                }
            });


            //Store
            modelBuilder.Entity<Stor>().HasData(new[]
            {
                new Stor{
                     Id = 1,
                    Name = "store1",
                    Location = "Assiut",
           
                },
               new Stor{
                 Id = 2,
                Name = "Store2",
                Location = "Alex",
           
                },
              

            });

            //Categories
            modelBuilder.Entity<Categorys>().HasData(new[]
            {
                new Categorys
                {
                    Id = 1,
                    Name = "Dairy",
                    StorId = 1,
            
                },
               
              
                new Categorys
                {
                    Id = 2,
                Name = "protien",
                StorId = 2,
            
                },
               

            });
            //Products
            modelBuilder.Entity<Proudect>().HasData(new[]
            {
                new Proudect
                {
                     Id = 1,
                    Name = "Milk",
                    SellingPrice = 15,
                    PurchasingPrice = 11,
                    Quantity = 20,
                    ProductionDate = new DateTime(2023, 2, 17),
                    ExpirationDate = new DateTime(2023, 3, 1),
                    CategorysId= 1,
                    Suppliersid=1,
              
                },
                new Proudect
                {
                     Id = 2,
                    Name = "Cheese",
                    SellingPrice = 30,
                    PurchasingPrice = 25,
                    Quantity = 17,
                    ProductionDate = new DateTime(2023, 5, 2),
                    ExpirationDate = new DateTime(2023, 3, 7),
                    CategorysId = 1,
                    Suppliersid = 1,
              
                },
                new Proudect
                {
                       Id = 3,
                    Name = "Yogut",
                    SellingPrice = 5,
                    PurchasingPrice = 3,
                    Quantity = 200,
                    ProductionDate = new DateTime(2023, 1, 1),
                    ExpirationDate = new DateTime(2023, 2, 1),
                    CategorysId = 1,
                    Suppliersid = 1,
               
                },
                new Proudect
                {
                     Id = 4,
                    Name = "Meet",
                    SellingPrice = 150,
                    PurchasingPrice = 130,
                    Quantity = 25,
                    ProductionDate = new DateTime(2023, 1, 12),
                    ExpirationDate = new DateTime(2023, 2, 2),
                    CategorysId = 2,
                    Suppliersid = 2,
                  
                },
                new Proudect
                {
                     Id = 5,
                    Name = "Chicken",
                    SellingPrice = 80,
                    PurchasingPrice = 70,
                    Quantity = 48,
                    ProductionDate = new DateTime(2023, 11, 11),
                    ExpirationDate = new DateTime(2023, 5, 1),
                    CategorysId = 2,
                    Suppliersid = 2,
                
                },
                new Proudect
                {
                      Id = 6,
                    Name = "fish",
                    SellingPrice = 90,
                    PurchasingPrice = 75,
                    Quantity = 36,
                    ProductionDate = new DateTime(2023, 11, 4),
                    ExpirationDate = new DateTime(2023, 6, 4),
                    CategorysId = 2,
                    Suppliersid = 2,
                
                },
                
            });

        }
    }
}
