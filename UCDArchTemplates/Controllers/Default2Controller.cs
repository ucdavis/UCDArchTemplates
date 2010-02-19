using System;
using System.Web.Mvc;
using UCDArch.Core.PersistanceSupport;
using UCDArch.Web.Controller;
using UCDArchTemplates.Models;
using UCDArch.Web.Helpers;

namespace UCDArchTemplates.Controllers
{
    /// <summary>
    /// Controller for the Order class
    /// </summary>
    public class Default2Controller : SuperController
    {
        private readonly IRepository<Order> _orderRepository;

        public Default2Controller(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        //
        // GET: /Default2/
        public ActionResult Index()
        {
            var orderList = _orderRepository.Queryable;

            return View(orderList);
        }

        //
        // GET: /Default2/Details/5
        public ActionResult Details(int id)
        {
            var order = _orderRepository.GetNullableByID(id);

            if (order == null) return RedirectToAction("Index");

            return View(order);
        }

        //
        // GET: /Default2/Create
        public ActionResult Create()
        {
            var viewModel = OrderViewModel.Create(Repository);
            
            return View(viewModel);
        } 

        //
        // POST: /Default2/Create
        [HttpPost]
        public ActionResult Create(Order order)
        {
            var orderToCreate = new Order();

            TransferValues(order, orderToCreate);

            orderToCreate.TransferValidationMessagesTo(ModelState);

            if (ModelState.IsValid)
            {
                _orderRepository.EnsurePersistent(orderToCreate);

                Message = "Order Created Successfully";

                return RedirectToAction("Index");
            }
            else
            {
                var viewModel = OrderViewModel.Create(Repository);
                viewModel.Order = order;

                return View(viewModel);
            }
        }

        //
        // GET: /Default2/Edit/5
        public ActionResult Edit(int id)
        {
            var order = _orderRepository.GetNullableByID(id);

            if (order == null) return RedirectToAction("Index");

            var viewModel = OrderViewModel.Create(Repository);
            viewModel.Order = order;
            
            return View(viewModel);
        }

        //
        // POST: /Default2/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Order order)
        {
            var orderToEdit = _orderRepository.GetNullableByID(id);

            if (orderToEdit == null) return RedirectToAction("Index");

            TransferValues(order, orderToEdit);

            orderToEdit.TransferValidationMessagesTo(ModelState);

            if (ModelState.IsValid)
            {
                _orderRepository.EnsurePersistent(orderToEdit);

                Message = "Order Edited Successfully";

                return RedirectToAction("Index");
            }
            else
            {
                var viewModel = OrderViewModel.Create(Repository);
                viewModel.Order = order;

                return View(viewModel);
            }
        }

        //
        // GET: /Default2/Delete/5
        public ActionResult Delete(int id)
        {
            var order = _orderRepository.GetNullableByID(id);

            if (order == null) return RedirectToAction("Index");

            return View(order);
        }

        //
        // POST: /Default2/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Order order)
        {
            var orderToDelete = _orderRepository.GetNullableByID(id);

            if (orderToDelete == null) return RedirectToAction("Index");

            _orderRepository.Remove(orderToDelete);

            Message = "Order Removed Successfully";

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Transfer editable values from source to destination
        /// </summary>
        private static void TransferValues(Order source, Order destination)
        {
            throw new NotImplementedException();
        }

    }

    /// <summary>
    /// ViewModel for the Order class
    /// </summary>
    public class OrderViewModel
    {
        public Order Order { get; set; }

        public static OrderViewModel Create(IRepository repository)
        {
            var viewModel = new OrderViewModel {Order = new Order()};

            return viewModel;
        }
    }
}
