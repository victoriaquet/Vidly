using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.View_Models;
using System.Data.Entity;


namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        //Lo siguiente se agrega para poder utilizaar la DB, se crea un DbContext

        // ésta es una propiedad es una DbSet pero definida en nuestro DbContext.
        // con _context.Customer podemos obtener todos los clientes en la DB
        private ApplicationDbContext _context;
        
        //Necesito inicilizar el atributo (variable) anterior, lo hago en el ctor
        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        //
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        //Estos métodos tienen como resultado la vista del mismo nombre que el controlador, a la cual se l pasan los 
        //parámetros, en este caso se le pasa una lista de customers. La vista Index, recibe una lista de clientes. 
        public ViewResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

                return View(customers);
            }

        //Details, es un método que recibe un id de parámentro. Llama a GetCustomers (ahora consulta el contexto) para obtener la lista de todos 
        //los clientes, luego compara con el id ingresado,, para asignar a la variable customer, el modelo del cliente
        // solicitado por la vista. La vista Details, recibe un modelo de cliente.
            public ActionResult Details(int id)
            {
                var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

                if (customer == null)
                    return HttpNotFound();

                return View(customer);
            }

        //GetCustomer es un método que, por ahora, retorna una lasta estática de clientes de tipo IEnumerable
            //private IEnumerable<Customer> GetCustomers()
            //{
            //    return new List<Customer>
            //    {
            //    new Customer { MembershipTypeId = 1, Name = "John Smith" },
            //    new Customer { MembershipTypeId = 2, Name = "Mary Williams" },
            //    new Customer {MembershipTypeId = 3, Name = "Sofía Carlota" }
            //    };
            //}
        }

        
}