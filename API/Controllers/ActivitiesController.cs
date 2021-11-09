using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        private readonly IMediator _mediarot;

        public ActivitiesController(IMediator mediarot)
        {
            _mediarot = mediarot;
        }

        [HttpGet]
        public async Task<IActionResult> GetActivities(CancellationToken ct)
        {     
            return HandleResult(await _mediarot.Send(new Application.Activities.List.Query(),ct));
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetActivity(Guid id)
        {
            return HandleResult(await _mediarot.Send(new Application.Activities.Details.Query{Id=id}));
        }

        [HttpPost]
        public async Task<ActionResult> CreateActivity(Activity activity)
        {
            return Ok(await Mediarot.Send(new Application.Activities.Create.Command{Activity=activity}));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> EditActivity(Guid id,Activity activity)
        {
            activity.Id = id;
            return HandleResult(await Mediarot.Send(new Application.Activities.Edit.Command{Activity=activity}));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteActivity(Guid id)
        {
            return HandleResult(await Mediarot.Send(new Application.Activities.Delete.Command{Id=id}));
        }
    }
}