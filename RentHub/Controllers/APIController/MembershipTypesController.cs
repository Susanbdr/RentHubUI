using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Microsoft.Ajax.Utilities;
using RentHub.Dtos;
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
        public IEnumerable<MembershipTypeDto> GetMembershipTypes()
        {
            return _context.MembershipTypes.ToList().Select(Mapper.Map<MembershipType, MembershipTypeDto>);
        }

        // GET /api/membershiptypes/1
        [HttpGet]
        public MembershipTypeDto GetMembershipType(byte id)
        {
            var membershipType = _context.MembershipTypes.SingleOrDefault(m => m.Id == id);

            if(membershipType == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<MembershipType, MembershipTypeDto>(membershipType);
        }

        // POST /api/membershiptypes
        [HttpPost]
        public MembershipTypeDto CreateMembershipType(MembershipTypeDto membershipTypeDto)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var membershipType = Mapper.Map<MembershipTypeDto, MembershipType>(membershipTypeDto);
            _context.MembershipTypes.Add(membershipType);
            _context.SaveChanges();

            return membershipTypeDto;
        }

        // PUT /api/membershiptypes/1
        [HttpPut]
        public MembershipTypeDto UpdateMembershipType(byte id, MembershipTypeDto membershipTypeDto)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var membershipTypeInDb = _context.MembershipTypes.SingleOrDefault(m => m.Id == id);

            if(membershipTypeInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(membershipTypeDto, membershipTypeInDb);

            _context.SaveChanges();

            return membershipTypeDto;
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
