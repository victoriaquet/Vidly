using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.View_Models;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
              
        //Estos métodos tienen como resultado la vista del mismo nombre que el controlador, a la cual se l pasan los 
        //Parámetros, en este caso se le pasa una lista de customers. La vista Index, recibe una lista de clientes. 
            public ViewResult Index()
            {
                var customers = GetCustomers();

                return View(customers);
            }

        //Details, es un método que recibe un id de parámentro. Llama a GetCustomers para obtener la lista de todos 
        //los clientes, luego compara con el id ingresado,, para asignar a la variable customer, el modelo del cliente
        // solicitado por la vista. La vista Details, recibe un modelo de cliente.
            public ActionResult Details(int id)
            {
                var customer = GetCustomers().SingleOrDefault(c => c.Id == id);

                if (customer == null)
                    return HttpNotFound();

                return View(customer);
            }

        //GetCustomer es un método que, por ahora, retorna una lasta estática de clientes de tipo IEnumerable
            private IEnumerable<Customer> GetCustomers()
            {
                return new List<Customer>
                {
                new Customer { Id = 1, Name = "John Smith" },
                new Customer { Id = 2, Name = "Mary Williams" },
                new Customer {Id = 3, Name = "Sofía Carlota" }
                };
            }
        }

        
}