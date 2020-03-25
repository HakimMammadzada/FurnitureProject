using AutoMapper.Configuration;
using FurnitureProject.Data;
using FurnitureProject.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace FurnitureProject.Infarstructure.Extensions
{
    public class DatabaseInitializer
    {
        public static void Seed(IServiceScope scoped)
        {
            using (var context = scoped.ServiceProvider.GetRequiredService<FurnitureDbContext>())
            {
                var manager = scoped.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

                if (!manager.Users.Any())
                {
                    var configuration = scoped.ServiceProvider.GetRequiredService<Microsoft.Extensions.Configuration.IConfiguration>();

                    AppUser appUser = new AppUser
                    {
                        Email = configuration["User:email"],
                        UserName = configuration["User:username"]
                    };
                    manager.CreateAsync(appUser, configuration["User:password"])
                                  .GetAwaiter()
                                    .GetResult();


                    var roleManager = scoped.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();
                    List<IdentityRole<int>> roleList = new List<IdentityRole<int>>();
                    if (!roleManager.Roles.Any())
                    {
                        string[] roles = configuration.GetSection("Roles").Value.Split(',');
                        foreach (var role in roles)
                        {
                            var r = new IdentityRole<int>
                            {
                                Name = role
                            };
                            roleList.Add(r);
                            roleManager.CreateAsync(r).GetAwaiter()
                                  .GetResult();
                        }
                    }

                    manager.AddToRoleAsync(appUser, roleList[0].Name).GetAwaiter().GetResult();


                }
                if (!context.Categoriys.Any())
                {
                    context.Categoriys.AddRange(
                        new Categoriy { Name = "Sets" },
                        new Categoriy { Name = "Single " },
                        new Categoriy { Name = "Accessories" }
                    );
                    context.SaveChanges();
                }
                if (!context.ProductCountries.Any())
                {
                    context.ProductCountries.AddRange(
                        new ProductCountry { Name = "Azerbaycan" },
                        new ProductCountry { Name = "Turkey" },
                        new ProductCountry { Name = "Italy" }
                        );
                    context.SaveChanges();
                }

                if (!context.productDesingers.Any())
                {
                    context.productDesingers.AddRange(
                        new ProductDesinger { Name = "Modern" },
                          new ProductDesinger { Name = "Klassic" },
                            new ProductDesinger { Name = "Avangard" }
                        );
                    context.SaveChanges();
                }
                if (!context.Properties.Any())
                {
                    context.Properties.AddRange(
                        new Property { Size = "E-2002 H-450 D-520" },
                         new Property { Size = "E-205 H-33 D-369" },
                         new Property { Size = "E-200 H-444 D-258" },
                         new Property { Size = "E-3002 H-352 D-147" },
                         new Property { Size = "E-2502 H-469 D-123" },
                         new Property { Size = "E-2202 H-400 D-456" },
                         new Property { Size = "E-282 H-456 D-168" },
                         new Property { Size = "E-2058 H-352 D-831" },
                         new Property { Size = "E-2369 H-469 D-279" },
                         new Property { Size = "E-4563 H-657 D-784" },
                         new Property { Size = "E-569 H-897 D-789" },
                         new Property { Size = "E-457 H-215 D-159" }
                        );
                    context.SaveChanges();
                }

                //if (!context.ProductCategoriys.Any())
                //{
                //    context.ProductCategoriys.AddRange(
                //        new ProductCategoriy { CategoriyId = 1,  ProductId = 12},
                //        new ProductCategoriy { CategoriyId = 2, ProductId = 2 },
                //        new ProductCategoriy { CategoriyId = 3, ProductId = 3 },
                //        new ProductCategoriy { CategoriyId = 2, ProductId = 4 },
                //        new ProductCategoriy { CategoriyId = 1, ProductId = 5 },
                //        new ProductCategoriy { CategoriyId = 3, ProductId = 6 },
                //        new ProductCategoriy { CategoriyId = 1, ProductId = 7 },
                //        new ProductCategoriy { CategoriyId = 2, ProductId = 8 },
                //        new ProductCategoriy { CategoriyId = 3, ProductId = 9 },
                //        new ProductCategoriy { CategoriyId = 2, ProductId = 10 },
                //        new ProductCategoriy { CategoriyId = 1, ProductId = 11 },
                //        new ProductCategoriy { CategoriyId = 1,  ProductId = 12},
                //        new ProductCategoriy { CategoriyId = 2, ProductId = 6 },
                //        new ProductCategoriy { CategoriyId = 3, ProductId = 10 }
                //    );
                //    context.SaveChanges();
                //}
                if (!context.Colors.Any())
                {
                    context.Colors.AddRange(
                        new Color { Name = "Ağ / Brown bodega / White bodega" },
                        new Color { Name = "Zebrano PVC / Ağ LDSP" },
                        new Color { Name = "Ney (tekstura) / Warm grey" },
                        new Color { Name = "Mavi (boya) / Tünd Ceviz (Şpon)" },
                        new Color { Name = "Mavi (boya) / Tünd Ceviz (Şpon)" },
                        new Color { Name = "Ağ / Brown bodega / White bodega" }
                        );
                    context.SaveChanges();
                }

                if (!context.Markas.Any())
                {
                    context.Markas.AddRange(
                        new Marka { Name = "Guestroom Sets", CategoriyId=1 },
                        new Marka { Name = "Bedroom Sets", CategoriyId=1 },
                        new Marka { Name = "Diningroom Sets", CategoriyId=1},
                        new Marka { Name = "Kidsroom Sets", CategoriyId=1 },

                        new Marka { Name = "Chair&Table", CategoriyId=2},
                        new Marka { Name = "soft Furniture", CategoriyId=2},
                        new Marka { Name = "Kitchen tables", CategoriyId=2 },
                        new Marka { Name = "Mattress", CategoriyId=2 },

                        new Marka { Name = "mirrors", CategoriyId=3 },
                        new Marka { Name = "Carpets", CategoriyId=3},
                        new Marka { Name = "Bed coating",CategoriyId=3 }
                    );
                    context.SaveChanges();
                }

                if (!context.Products.Any())
                {
                    context.Products.AddRange(
                        new Product { Price = 258, MarkaId=1, Count = 25, Mainimage = "yu1.jpg", PropertyId = 1, ProductCountryId = 1, Name = "Safir", ProductDesingerId = 1 },
                        new Product { Price = 222, MarkaId = 2, Count = 20, Discount = 25, Mainimage = "c8.jpg", PropertyId = 2, ProductCountryId = 1, Name = "Safir", ProductDesingerId = 1 },
                        new Product { Price = 255, MarkaId = 3, Count = 10, Mainimage = "q1.jpg", PropertyId = 2, ProductCountryId = 2, Name = "Safir", ProductDesingerId = 2 },
                        new Product { Price = 3333, MarkaId = 4, Count = 8, Mainimage = "c-1.jpg", PropertyId = 3, ProductCountryId = 3, Name = "Safir", ProductDesingerId = 3 },
                        new Product { Price = 125, MarkaId = 5, Count = 5, Mainimage = "yu1.jpg", PropertyId = 1, ProductCountryId = 2, Name = "Safir", ProductDesingerId = 1 },
                        new Product { Price = 8745, MarkaId = 6, Count = 7, Mainimage = "q1.jpg", PropertyId = 1, ProductCountryId = 3, Name = "Safir", ProductDesingerId = 3 },
                        new Product { Price = 5555, MarkaId = 7, Count = 9, Mainimage = "m2.jpg", PropertyId = 1, ProductCountryId = 2, Name = "Safir", ProductDesingerId = 2 },
                        new Product { Price = 453, MarkaId = 8, Count = 6, Mainimage = "y5.jpg", PropertyId = 1, ProductCountryId = 1, Name = "Safir", ProductDesingerId = 3 },
                        new Product { Price = 687, MarkaId = 9, Count = 12, Mainimage = "q2.jpg", PropertyId = 1, ProductCountryId = 1, Name = "Safir", ProductDesingerId = 1 },
                        new Product { Price = 789, MarkaId = 10, Count = 22, Mainimage = "m5.jpg", PropertyId = 1, ProductCountryId = 2, Name = "Safir", ProductDesingerId = 2 },
                        new Product { Price = 368, MarkaId = 11, Count = 29, Mainimage = "dosek1.jpg", PropertyId = 1, ProductCountryId = 3, Name = "Safir", ProductDesingerId = 3 }

                            );
                    context.SaveChanges();
                }
                if (!context.Images.Any())
                {
                    context.Images.AddRange(new Image { Photo = "y3.jpg", ProductId=1 },
                                   new Image { Photo = "c-1.jpg",ProductId=1 },
                                   new Image { Photo = "c-2.jpg", ProductId=2 },
                                   new Image { Photo = "c-3.jpg",ProductId=2 },
                                   new Image { Photo = "c4.jpg",ProductId=3 },
                                   new Image { Photo = "c-6.jpg" ,ProductId=3 },
                                   new Image { Photo = "c7.jpg",ProductId=4 },
                                   new Image { Photo = "d1.jpg", ProductId=4 },
                                   new Image { Photo = "d2.jpg",ProductId=5 },
                                   new Image { Photo = "d3.jpg",ProductId=5 },
                                   new Image { Photo = "d5.jpg",ProductId=6 },
                                   new Image { Photo = "m1.jpg",ProductId=6 },
                                   new Image { Photo = "m2.jpg",ProductId=7 },
                                   new Image { Photo = "m3.jpg",ProductId=7 },
                                   new Image { Photo = "m4.jpg",ProductId=8 },
                                   new Image { Photo = "m5.jpg",ProductId=8 },
                                   new Image { Photo = "q1.jpg",ProductId=9},
                                   new Image { Photo = "q2.jpg",ProductId=9 },
                                   new Image { Photo = "q3.jpg",ProductId=10 },
                                   new Image { Photo = "q4.jpg",ProductId=10},
                                   new Image { Photo = "y1.jpg",ProductId=11 },
                                   new Image { Photo = "y2.jpg",ProductId=11 }

                    );
                    context.SaveChanges();
                }


                if (!context.ProductColors.Any())
                {
                    context.ProductColors.AddRange(
                        new ProductColor { ProductId = 2, ColorId = 1 },
                         new ProductColor { ProductId = 3, ColorId = 1 },
                         new ProductColor { ProductId = 2, ColorId = 2 },
                         new ProductColor { ProductId = 3, ColorId = 3 },
                         new ProductColor { ProductId = 4, ColorId = 4 },
                         new ProductColor { ProductId = 5, ColorId = 5 },
                         new ProductColor { ProductId = 6, ColorId = 6 },
                         new ProductColor { ProductId = 7, ColorId = 1 },
                         new ProductColor { ProductId = 8, ColorId = 2 },
                         new ProductColor { ProductId = 9, ColorId = 3 },
                         new ProductColor { ProductId = 10, ColorId = 4 },
                         new ProductColor { ProductId = 11, ColorId = 5 },
                         new ProductColor { ProductId = 4, ColorId = 6 }
                        );
                    context.SaveChanges();
                }

               
            }
        }
    }
}
