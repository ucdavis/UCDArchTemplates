using System;
using System.Web.Mvc;
using UCDArch.Core.PersistanceSupport;
using UCDArch.Web.Controller;
using UCDArch.Web.Helpers;
using UCDArch.Core.Utils;
using UCDArchTemplates.Helpers;
using UCDArchTemplates.Models;

namespace UCDArchTemplates.Controllers
{
    /// <summary>
    /// Controller for the Customer class
    /// </summary>
    public class CustomerController : SuperController
    {
	    private readonly IRepository<Customer> _customerRepository;

        public CustomerController()
        {
            _customerRepository = new CustomerHashRepository();
        }

        public CustomerController(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }
    
        //
        // GET: /Customer/
        public ActionResult Index()
        {
            var customerList = _customerRepository.Queryable;

            return View(customerList);
        }

        //
        // GET: /Customer/Details/5
        public ActionResult Details(int id)
        {
            var customer = _customerRepository.GetNullableByID(id);

            if (customer == null) return RedirectToAction("Index");

            return View(customer);
        }

        //
        // GET: /Customer/Create
        public ActionResult Create()
        {
			var viewModel = CustomerViewModel.Create(Repository);
            
            return View(viewModel);
        } 

        //
        // POST: /Customer/Create
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(Customer customer)
        {
            var customerToCreate = new Customer();

            TransferValues(customer, customerToCreate);

            customerToCreate.TransferValidationMessagesTo(ModelState);

            if (ModelState.IsValid)
            {
                _customerRepository.EnsurePersistent(customerToCreate);

                Message = "Customer Created Successfully";

                return RedirectToAction("Index");
            }
            else
            {
				var viewModel = CustomerViewModel.Create(Repository);
                viewModel.Customer = customer;

                return View(viewModel);
            }
        }

        //
        // GET: /Customer/Edit/5
        public ActionResult Edit(int id)
        {
            var customer = _customerRepository.GetNullableByID(id);

            if (customer == null) return RedirectToAction("Index");

			var viewModel = CustomerViewModel.Create(Repository);
			viewModel.Customer = customer;

			return View(viewModel);
        }
        
        //
        // POST: /Customer/Edit/5
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, Customer customer)
        {
            var customerToEdit = _customerRepository.GetNullableByID(id);

            if (customerToEdit == null) return RedirectToAction("Index");

            TransferValues(customer, customerToEdit);

            customerToEdit.TransferValidationMessagesTo(ModelState);

            if (ModelState.IsValid)
            {
                _customerRepository.EnsurePersistent(customerToEdit);

                Message = "Customer Edited Successfully";

                return RedirectToAction("Index");
            }
            else
            {
				var viewModel = CustomerViewModel.Create(Repository);
                viewModel.Customer = customer;

                return View(viewModel);
            }
        }
        
        //
        // GET: /Customer/Delete/5 
        public ActionResult Delete(int id)
        {
			var customer = _customerRepository.GetNullableByID(id);

            if (customer == null) return RedirectToAction("Index");

            return View(customer);
        }

        //
        // POST: /Customer/Delete/5
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(int id, Order customer)
        {
			var customerToDelete = _customerRepository.GetNullableByID(id);

            if (customerToDelete == null) return RedirectToAction("Index");

            _customerRepository.Remove(customerToDelete);

            Message = "Customer Removed Successfully";

            return RedirectToAction("Index");
        }
        
        /// <summary>
        /// Transfer editable values from source to destination
        /// </summary>
        private static void TransferValues(Customer source, Customer destination)
        {
            throw new NotImplementedException();
        }

    }

	/// <summary>
    /// ViewModel for the Customer class
    /// </summary>
    public class CustomerViewModel
	{
		public Customer Customer { get; set; }
 
		public static CustomerViewModel Create(IRepository repository)
		{
			Check.Require(repository != null, "Repository must be supplied");
			
			var viewModel = new CustomerViewModel {Customer = new Customer()};
 
			return viewModel;
		}
	}
}
