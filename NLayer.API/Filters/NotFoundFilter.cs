using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Services;

namespace NLayer.API.Filters
{
    public class NotFoundFilter<T> : IAsyncActionFilter where T : BaseEntity
    {

        private readonly IService<T> _service;

        public NotFoundFilter(IService<T> service)
        {
            _service = service;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var idValue = context.ActionArguments.Values.FirstOrDefault(); // id
            if(idValue == null)
            {
                await next.Invoke(); //devam et
                return;
            }

            var id = Convert.ToInt32(idValue);              
            var anyEntity = await _service.AnyAsync(x => x.Id == id);       // id'ye göre bir kayıt var mı?

            if (anyEntity)      
            {
                await next.Invoke();
                return;
            }
            else    // kayıt yoksa
            {
                context.Result = new NotFoundObjectResult(CustomResponseDto<NoContentDto>.Fail(404, $"{typeof(T).Name}({id}) not found."));
            }
        }
    }
}
