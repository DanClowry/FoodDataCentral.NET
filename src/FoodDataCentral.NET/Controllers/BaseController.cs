namespace FoodDataCentral.Controllers
{
    internal abstract class BaseController
    {
        protected readonly IRequester requester;
        protected readonly string apiKey;

        public BaseController(IRequester requester, string apiKey)
        {
            this.requester = requester;
            this.apiKey = apiKey;
        }
    }
}
