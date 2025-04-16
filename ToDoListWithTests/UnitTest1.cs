using ToDoList.Controllers;
using ToDoList.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using ToDoList.Repository;

namespace TicketTest
{
    public class UnitTest1
    {
        [Fact]
        public void ModelValidateTest()// Making sure validation works
        {
            // Arrange
            Ticket model = new Ticket();
            // Act
            model.Name = "Thing";
            model.Description = "A description";
            model.StatusId = "To-Do";
            model.SprintNum = 8;
            model.PointId = "5";
            // Assert
            ValidationContext context = new ValidationContext(model);
            Validator.ValidateObject(model, context);
        }

       // [Fact]
       // public void RepoTest()
       // {
         //   var mem = new DbContextOptionsBuilder<TicketContext>()
          //  .UseInMemoryDatabase("Filename=test.db")
         //   .Options;
          //  TicketContext ctx = new TicketContext(mem);
         //   ctx.Tickets.Add(new Ticket()
         //   {
         //       Name = "Thing",
         //       Description = "A description",
         //       StatusId = "To-Do",
        //        SprintNum = 8,
        //        PointId = "5",
        //    });
         //   Repository<Ticket> repo = new Repository<Ticket>(ctx);
         //   var ticket = repo.GetAll();

        //    Assert.Equal(1, ticket.Count());



      //  }
    }
}