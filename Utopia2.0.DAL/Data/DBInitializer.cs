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
            // For the creation of random data for the db, the index starts from 1 to make sure
            // the generated id corresponds with the ID of the row.

            Random rd = new Random();
            string[] colors = new string[] {"blue", "green", "red", "yellow" };
            int nrOfStations = 10;
            int nrOfLines = colors.Length;
            int nrOfBuildings = 10;
            int nrOfQuestions = 10;
            int nrOfAnswers = 4;
            int nrOfParticipants = 500;

            context.Database.EnsureCreated();
            //Add Stations

            if (!context.Stations.Any())
            {
                for (int i = 1; i < nrOfStations + 1; i++)
                {
                    int X = rd.Next(10, 120);
                    int Y = rd.Next(10, 120);
                    Station station = new Station { X = X, Y = Y };
                    context.Add(station);
                }
                context.SaveChanges();
            }
            if (!context.Lines.Any())
            {
                for (int i = 1; i < nrOfLines + 1; i++)
                {
                   
                    Line line = new Line { Color = colors[i-1], Faculty = "Dit is een faculty " + i };

                    context.Add(line);
                }
                context.SaveChanges();
            }
            if (!context.Buildings.Any())
            {
                for (int i = 1; i < nrOfBuildings + 1; i++)
                {
                    Building building = new Building { GraduateProgram = "Dit is een gebouw " + i, LineId = rd.Next(1, nrOfLines+1), StationId = rd.Next(1, 10) };

                    context.Add(building);
                }
                for (int i = 1; i < nrOfStations + 1; i++)
                {
                    Building building = new Building { GraduateProgram = "Dit is een gebouw " + i, LineId = rd.Next(1, nrOfLines+1), StationId = i };

                    context.Add(building);
                }
                context.SaveChanges();
            }
            if (!context.Persons.Any())
            {
                for (int i = 1; i < nrOfParticipants + 1; i++)
                {
                    int randomNumber = rd.Next(1000000, 9999999);
                    String random = randomNumber.ToString();

                    Person person = new Person { Username = "Persoon " + i, RandomKey = random };

                    context.Add(person);

                }
                context.SaveChanges();
            }
            if (!context.Questions.Any())
            {
                for (int i = 1; i < nrOfBuildings + 1; i++)
                {
                    // Define the start ID for the questions of this building
                    var questionStartId = (i - 1) * nrOfBuildings + 1;
                    // Create nrOfQuestions questions for this building starting from the questionStartId until questionStartId + nrOfQuestions
                    // In the for loop < is used instead of <=, as the index i starts with 1 (and not with 0).
                    for (int j = questionStartId; j < questionStartId + nrOfQuestions; j++)
                    {
                        Question question = new Question { TextualQuestion = "Dit is een vraag " + j, BuildingId = i };
                        context.Add(question);
                    }
                    
                }
                context.SaveChanges();
            }
            if (!context.MultipleChoiceAnswers.Any())
            {
                for (int i = 1; i < nrOfBuildings * nrOfQuestions + 1; i++)
                {
                    // Define the start ID of the answer for this question
                    var answerStartId = (i-1) * nrOfAnswers + 1;
                    // Create a random integer to define the correct answer
                    // The rd.Nxt() function generates a number from 0 until (excluding) nrOfAnswers (therefore no -1).
                    var correctAnswerId = rd.Next(nrOfAnswers) + answerStartId;
                    // Create nrOfAnswers answers for this question starting from the answerStartId untill answerStartId + nrOfAnswers
                    // In the for loop < is used instead of <=, as the index i starts with 1 (and not with 0).
                    for (int j = answerStartId; j < answerStartId + nrOfAnswers; j++)
                    {
                        // Check here if this answer is the correct one.
                        bool correct;
                        if (correctAnswerId == j) {
                            correct = true;
                        } else {
                            correct = false;
                        }
                        MultipleChoiceAnswer multipleChoiceAnswer = new MultipleChoiceAnswer { TextualAnswer = "Dit is een antwoord " + j, Correct = correct, QuestionId = i };
                        context.Add(multipleChoiceAnswer);
                    }
                }
                context.SaveChanges();
            }
            if (!context.Answers.Any())
            {
                for (int i = 1; i <= 1500; i++)
                {
                    Answer answer = new Answer { MultipleChoiceAnswerId = rd.Next(1,nrOfBuildings*nrOfQuestions*nrOfAnswers), PersonId = rd.Next(1,nrOfParticipants) };
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
