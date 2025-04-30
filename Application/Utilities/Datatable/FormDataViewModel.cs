namespace Application.ViewModels.Datatable
{
    public class FormDataViewModel
    {
        //public List<T> QueryList { get; set; }
        public string Draw { get; set; }
        public String Start { get; set; }
        public string Length { get; set; }
        public string SortColumn { get; set; }
        public string SortColumnDirection { get; set; }
        public string SearchValue { get; set; }
        public int PageSize { get; set; }
        public int Skip { get; set; }
    }
}
