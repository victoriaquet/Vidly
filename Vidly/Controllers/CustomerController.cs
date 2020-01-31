using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.View_Models;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;


namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        //Lo siguiente se agrega para poder utilizaar la DB, se crea un DbContext
        //Parece que es para poder usar la variable _context como si el contexto fuera un objeto, y de ahi extraer todo lo que necesitemos de la DB
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

            return View();
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

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();

            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes,
                Customer = new Customer()              

            };
            return View("CustomerForm",viewModel);//Acá, antes la vista no se llamaba CustomerForm, se llamaba New, como la acción, entonces no había que mapear, solo pasar el vlaor del atributo, ahora hay que pasar el nombre de la vista
        }

        [ValidateAntiForgeryToken]
        [HttpPost] //esto es para definir que no es un Get
        public ActionResult Save(Customer customer)//Primeero usamos NewCustomeerViewModel.. pero dejamos esto gracias al model binding
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes= _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
                    
            };
            

           

                if (customer.Id == 0)//Quiere decir que se trata de un nuevo cliente

                // Agrego el cliente al DbContext
                _context.Customers.Add(customer);// solo en memoria, no en DB

                else
                {
                         var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                // TryUpdateModel(customerInDb); esta linea es lo que te recomienda microsoft para hacer update con el formulario, pero tiene huecos de seguridad, pueden medianamente resolversse con parametros que traenotros problemas
                //Mapper.Map.(customer, customerInDb)

                        customerInDb.Name = customer.Name;
                        customerInDb.Birthday = customer.Birthday;
                        customerInDb.MembershipTypeId = customer.MembershipTypeId;
                        customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;

                 }





                  _context.SaveChanges(); //Con esto se genera la persistencia de los cambios, todes los cambios juntos, o ninguno

                    return RedirectToAction("Index", "Customer");//Redirecciono a /Customer/Index

            //F9 to  breakpiont + F5 to execute debugger
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c=> c.Id == id);

            if (customer == null)
                return  HttpNotFound();

            var viewModel = new CustomerFormViewModel //Cuando uso una clase de tipo para una variable tengo que poner el new
            {
                Customer = customer ,
                MembershipTypes = _context.MembershipTypes.ToList()

            };

            return View("CustomerForm",viewModel);

          
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