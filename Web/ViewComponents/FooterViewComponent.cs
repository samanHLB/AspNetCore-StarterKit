namespace Web.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        public FooterViewComponent()
        {
            
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            return await Task.FromResult((IViewComponentResult)View("Footer"));
        }
    }
}
