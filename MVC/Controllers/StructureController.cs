using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models;
using MVC.Models.Interface;
using MVC.Models.Repository;
using MVC.ViewModels;
using Service;
using Service.Interface;

namespace MVC.Controllers
{
    public class StructureController : Controller
    {
        private readonly IStructureService structureService;

        public StructureController()
        {
            this.structureService = new StructureService();
        }

        // GET: Structure
        public ActionResult Index()
        {
            var structures = structureService.GetAll().ToList();
            var viewModel = new StructureListViewModel();
            viewModel.StructureList = structures;

            return View(viewModel);
        }

        public ActionResult Create()
        {
            var viewModel = new StructureViewModel();

            return View(viewModel);
        }

        public ActionResult Edit(Guid id)
        {
            var viewModel = new StructureViewModel();
            var model = structureService.GetById(id);
            viewModel.Id = id;
            viewModel.Name = model.Name;

            return View("Create", viewModel);
        }

        [HttpPost]
        public ActionResult Save(StructureViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (viewModel.Id == Guid.Empty)
                {
                    var model = new Structure();
                    model.Id = Guid.NewGuid();
                    model.Name = viewModel.Name;
                    structureService.Create(model);
                }
                else
                {
                    var model = structureService.GetById(viewModel.Id);
                    model.Name = viewModel.Name;
                    structureService.Update(model);
                }
                return RedirectToAction("Index");
            }
            return View("Create", viewModel);
        }

        public ActionResult Delete(Guid id)
        {
            structureService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}