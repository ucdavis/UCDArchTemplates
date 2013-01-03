using System.Linq;
using System.Web.Mvc;
using UCDArch.Core.PersistanceSupport;
using UCDArch.Core.Utils;
using UCDArch.Web.Attributes;
using UcdArchTemplates.Web.Models;

namespace UcdArchTemplates.Web.Controllers
{
    /// <summary>
    /// Controller for the Customer class
    /// </summary>
    [HandleTransactionsManually]
    public class CustomerController : ApplicationController
    {
        private readonly IRepository<Customer> _customerRepository;

        public CustomerController()
        {
            _customerRepository = new CustomerHashRepository();
        }

        //public CustomerController(IRepository<Customer> customerRepository)
        //{
        //    _customerRepository = customerRepository;
        //}

        //
        // GET: /Customer/
        public ActionResult Index()
        {
            var customerList = _customerRepository.Queryable;

            return View(customerList.ToList());
        }

        //
        // GET: /Customer/Details/5
        public ActionResult Details(int id)
        {
            var customer = _customerRepository.GetNullableById(id);

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
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            var customerToCreate = new Customer();

            TransferValues(customer, customerToCreate);

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
            var customer = _customerRepository.GetNullableById(id);

            if (customer == null) return RedirectToAction("Index");

            var viewModel = CustomerViewModel.Create(Repository);
            viewModel.Customer = customer;

            return View(viewModel.Customer);
        }

        //
        // POST: /Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Customer customer)
        {
            var customerToEdit = _customerRepository.GetNullableById(id);

            if (customerToEdit == null) return RedirectToAction("Index");

            TransferValues(customer, customerToEdit);

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
            var customer = _customerRepository.GetNullableById(id);

            if (customer == null) return RedirectToAction("Index");

            return View(customer);
        }

        //
        // POST: /Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Customer customer)
        {
            var customerToDelete = _customerRepository.GetNullableById(id);

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
            destination.CompanyName = source.CompanyName;
            destination.ContactName = source.ContactName;
            destination.Country = source.Country;
            destination.Fax = source.Fax;

            //Recommendation: Use AutoMapper
            //Mapper.Map(source, destination)
            //throw new NotImplementedException();
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
            //Have to remove since we don't need it in this sample proj & no reason to fake
            //Check.Require(repository != null, "Repository must be supplied");

            var viewModel = new CustomerViewModel { Customer = new Customer() };

            return viewModel;
        }
    }
}
