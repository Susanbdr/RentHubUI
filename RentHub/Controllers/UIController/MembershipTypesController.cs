using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentHub.Models;
using RentHub.Models.BusinessModels;
using RentHub.ViewModels;

namespace RentHub.Controllers.UIController
{
    public class MembershipTypesController : Controller
    {

        private readonly ApplicationDbContext _context;

        public MembershipTypesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: MembershipTypes
        public ActionResult Index()
        {
            var membershipTypes = _context.MembershipTypes.ToList();

            return View(membershipTypes);
        }

        public ActionResult New()
        {
            var viewModel = new MembershipTypeViewModel
            {
                MembershipType = new MembershipType()
            };

            return View("MembershipTypeForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(MembershipType membershipType)
        {
            if(membershipType.Id == 0)
                _context.MembershipTypes.Add(membershipType);
            else
            {
                var membershipTypeInDb = ReturnMembershipTypeId(membershipType);

                membershipTypeInDb.Name = membershipType.Name;
                membershipTypeInDb.DurationInMonths = membershipType.DurationInMonths;
                membershipTypeInDb.SignUpFee = membershipType.SignUpFee;
                membershipTypeInDb.DiscountRate = membershipType.DiscountRate;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "MembershipTypes");
        }

        public ActionResult Edit(byte id)
        {
            var membershipTypeInDb = _context.MembershipTypes.Single(m => m.Id == id);

            if (membershipTypeInDb == null)
                return HttpNotFound();

            var viewModel = new MembershipTypeViewModel
            {
                MembershipType = membershipTypeInDb
            };

            return View("MembershipTypeForm", viewModel);
        }

        private MembershipType ReturnMembershipTypeId(MembershipType membershipType)
        {
            return _context.MembershipTypes.Single(m => m.Id == membershipType.Id);
        }

        private MembershipType ReturnMembershipTypeId(byte id)
        {
            return _context.MembershipTypes.Single(m => m.Id == id);
        }

        public ActionResult Delete(byte id)
        {
            var membershipTypeToDelete = ReturnMembershipTypeId(id);

            if (membershipTypeToDelete == null)
                return HttpNotFound();

            _context.MembershipTypes.Remove(membershipTypeToDelete);
            _context.SaveChanges();

            return RedirectToAction("Index", "MembershipTypes");
        }
    }
}