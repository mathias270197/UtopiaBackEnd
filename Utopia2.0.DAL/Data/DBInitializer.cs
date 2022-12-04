using Utopia2._0.Data;
using Utopia2._0.Models;

namespace Shop.DAL.Models
{
    public class DBInitializer
    {
        public static void Initialize(UtopiaContext context)
        {
            context.Database.EnsureCreated();
            //Add Stations
            Station station1 = new Station { X = 5.5, Y = 7.8 };
            Line line1 = new Line { Color = "blue", Faculty = "Informatiewetenschappen" };
            context.Add(station1);
            context.Add(line1);
            context.SaveChanges();

            Building building1 = new Building { GraduateProgram = "Toegapse informatica", LineId = 1, StationId = 1 };
            context.Add(building1);
            context.SaveChanges();
            Person person1 = new Person { Username = "Mathias", RandomKey = "2578528" };
            context.Add(person1);
            context.SaveChanges();
            Question question1 = new Question { TextualQuestion = "wat is blabla?", BuildingId = 1};
            context.Add(question1);
            context.SaveChanges();
            MultipleChoiceAnswer multipleChoiceAnswer1 = new MultipleChoiceAnswer { TextualAnswer = "dit is het antwoord", Correct = true, QuestionId = 1 };
            context.Add(multipleChoiceAnswer1);
            context.SaveChanges();
            Answer answer1 = new Answer { MultipleChoiceAnswerId = 1, PersonId = 1};
            context.Add(answer1);
            context.SaveChanges();
            
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
