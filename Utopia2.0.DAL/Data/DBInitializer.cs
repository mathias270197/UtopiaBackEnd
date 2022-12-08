using System;
using System.Drawing;
using System.Linq;
using Utopia2._0.Data;
using Utopia2._0.Models;

namespace Shop.DAL.Models
{
    public class DBInitializer
    {
        
        public static void Initialize(UtopiaContext context)
        {
            Random rd = new Random();
            KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));

            context.Database.EnsureCreated();
            //Add Stations
            
            if (!context.Stations.Any())
            {
                for (int i = 1; i <= 10; i++)
                {
                    double XDouble = rd.NextDouble();
                    double YDouble = rd.NextDouble();
                    Station station = new Station { X = XDouble, Y = YDouble };
                    context.Add(station);
                }
                context.SaveChanges();
            }
            if (!context.Lines.Any())
            {
                for (int i = 1; i <= 10;i++)
                {
                    KnownColor randomColorName = names[rd.Next(i)];
                    string randomColor = randomColorName.ToString();
                    //Color randomColor = Color.FromKnownColor(randomColorName);

                    Line line = new Line { Color = randomColor, Faculty = "dit is een faculty" + i };

                    context.Add(line);
                }
                context.SaveChanges();
            }
            if (!context.Buildings.Any())
            {
                for (int i = 1; i <= 10; i++)
                {
                    Building building = new Building { GraduateProgram = "dit is een gebouw" + i, LineId = i, StationId = i };

                    context.Add(building);
                }
                context.SaveChanges();
            }
            if (!context.Persons.Any())
            {
                for (int i = 1; i <= 10; i++)
                {
                    int randomNumber = rd.Next(1000000, 9999999);

                    Person person = new Person { Username = "Persoon" + i, RandomKey = randomNumber };

                    context.Add(person);

                }
                context.SaveChanges();
            }
            if (!context.Questions.Any())
            {
                for (int i = 1; i <= 10; i++)
                {
                    Question question = new Question { TextualQuestion = "dit is een vraag" + i, BuildingId = i };

                    context.Add(question);
                }
                context.SaveChanges();
            }
            if (!context.MultipleChoiceAnswers.Any())
            {
                for (int i = 1; i <= 10; i++)
                {
                    for (int j = 1; j <= 4; j++)
                    {
                        var randomBool = rd.Next(2) == 1;
                        MultipleChoiceAnswer multipleChoiceAnswer = new MultipleChoiceAnswer { TextualAnswer = "dit is een antwoord" + j, Correct = randomBool, QuestionId = i };
                        context.Add(multipleChoiceAnswer);
                    }
                }
                context.SaveChanges();
            }
            if (!context.Answers.Any())
            {
                for (int i = 1; i <= 10; i++)
                {
                    Answer answer = new Answer { MultipleChoiceAnswerId = i, PersonId = i };
                    context.Add(answer);
                }
                context.SaveChanges();
            }



            
            // Look for any products.
            /*if (context.Products.Any())
            {
                return;   // DB has been seeded
            }

            //Add products
            context.AddRange(
                new Product { Name = "Red Woody pajama", Price = 15.99M },
                new Product { Name = "Blue cap", Price = 5.99M },
                new Product { Name = "Green t-shirt", Price = 20.99M }
                );

            //Add customers
            Customer customerMichael = new Customer()
            {
                FirstName = "Michaël",
                LastName = "Cloots",
                Email = "michael.cloots@thomasmore.be"
            };

            Customer customerJos = new Customer()
            {
                FirstName = "Jos",
                LastName = "Jossen",
                Email = "jos.jossen@thomasmore.be"
            };
            context.Add(customerMichael);
            context.Add(customerJos);

            //Orders
            Order order = new Order()
            {
                OrderPlaced = DateTime.Now,
                CustomerId = 1
            };

            Order order2 = new Order()
            {
                OrderPlaced = DateTime.Now.AddDays(-7),
                CustomerId = 1
            };

            context.Add(order);
            context.Add(order2);

            //ProductOrders
            ProductOrder po = new ProductOrder()
            {
                OrderId = 1,
                ProductId = 1,
                Quantity = 5
            };

            ProductOrder po2 = new ProductOrder()
            {
                OrderId = 2,
                ProductId = 2,
                Quantity = 2
            };

            ProductOrder po3 = new ProductOrder()
            {
                OrderId = 1,
                ProductId = 2,
                Quantity = 10
            };

            context.Add(po);
            context.Add(po2);
            context.Add(po3);


            context.SaveChanges();*/
        }
    }
}
