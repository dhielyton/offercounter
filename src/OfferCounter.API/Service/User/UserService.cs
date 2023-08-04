namespace OfferCounter.API.Service.User
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _accessor;

        public UserService(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public string GetUserId()
        {
            return _accessor.HttpContext.Request.Headers["User"];
        }
    }
}
