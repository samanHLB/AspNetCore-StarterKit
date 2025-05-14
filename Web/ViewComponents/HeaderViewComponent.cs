namespace Web.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        public HeaderViewComponent()
        {

        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            return await Task.FromResult((IViewComponentResult)View("Header"));
        }
    }
}
