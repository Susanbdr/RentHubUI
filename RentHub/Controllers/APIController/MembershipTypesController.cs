using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Ajax.Utilities;
using RentHub.Models;

namespace RentHub.Controllers.APIController
{
    public class MembershipTypesController : ApiController
    {
        private readonly DataHouseContext _context;

        public MembershipTypesController()
        {
            _context = new DataHouseContext();
        }

        // GET /api/membershiptypes
        [HttpGet]
        public IEnumerable<MembershipType> GetMembershipTypes()
        {
            return _context.MembershipTypes.ToList();
        }

        // GET /api/membershiptypes/1
        [HttpGet]
        public MembershipType GetMembershipType(byte id)
        {
            var membershipType = _context.MembershipTypes.SingleOrDefault(m => m.Id == id);

            if(membershipType == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return membershipType;
        }

        // POST /api/membershiptypes
        [HttpPost]
        public MembershipType CreateMembershipType(MembershipType membershipType)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.MembershipTypes.Add(membershipType);
            _context.SaveChanges();

            return membershipType;
        }

        // PUT /api/membershiptypes/1
        [HttpPut]
        public MembershipType UpdateMembershipType(byte id, MembershipType membershipType)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var membershipTypeInDb = _context.MembershipTypes.SingleOrDefault(m => m.Id == id);

            if(membershipTypeInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            membershipTypeInDb.SignUpFee = membershipType.SignUpFee;
            membershipTypeInDb.DurationInMonths = membershipType.DurationInMonths;
            membershipTypeInDb.DiscountRate = membershipType.DiscountRate;
            membershipTypeInDb.Name = membershipType.Name;

            _context.SaveChanges();

            return membershipType;
        }

        // DELETE /api/membershiptypes/1
        [HttpDelete]
        public MembershipType DeleteMembershipType(byte id)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var membershipTypeInDb = _context.MembershipTypes.SingleOrDefault(m => m.Id == id);

            if (membershipTypeInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.MembershipTypes.Remove(membershipTypeInDb);
            _context.SaveChanges();

            return membershipTypeInDb;
        }



    }
}
