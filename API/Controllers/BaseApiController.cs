using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController:ControllerBase
    {
        private IMediator _mediarot;
        protected IMediator Mediarot => _mediarot ??=HttpContext.RequestServices.GetService<IMediator>();
    }
}