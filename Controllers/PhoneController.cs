using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using MobileStore.Models;
using MobileStore.Models.DTO;
using MobileStore.Phones.Queries.GetPhoneDetails;
using MobileStore.Phones.Queries.GetPhoneList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MobileStore.Interfaces;
using MobileStore.Phones.Commands.CreatePhone;
using MobileStore.Phones.Commands.UpdatePhone;
using MobileStore.Phones.Commands.DeletePhone;

namespace MobileStore.Controllers
{
    [Route ("api/[controller]")]
    public class PhoneController : BaseController
    {
        private readonly IMobilDbContext db;
        private readonly IMapper _mapper;

        public PhoneController(IMobilDbContext context, IMapper mapper)
        {
            db = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<PhoneListVm>> GetAll()
        {
            var query = new GetPhoneListQuery
            {
                UserId = UserId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PhoneDetailsVm>> Get(int id)
        {
            var query = new GetPhoneDetailsQuery
            {
                UserId = UserId,
                Id = id

            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreatePhoneDto createPhoneDto)
        {
            var command = _mapper.Map<CreatePhoneCommand>(createPhoneDto);
            command.UserId = UserId;
            var phoneId = await Mediator.Send(command);
            return Ok(command);
        }

        [HttpPut]
        public async Task<ActionResult<Guid>> Update([FromBody] UpdatePhoneDto updatePhoneDto)
        {
            var command = _mapper.Map<UpdatePhoneCommand>(updatePhoneDto);
            command.UserId = UserId;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeletePhoneCommand
            {
                Id = id,
                UserId = UserId
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
