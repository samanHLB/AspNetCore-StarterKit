namespace Application.Utilities.Datatable
{
    public static class FormDataExtension
    {
        public static FormDataViewModel GetFormData(this IFormCollection form)
        {
            var draw = form["draw"].FirstOrDefault();
            var start = form["start"].FirstOrDefault();
            var length = form["length"].FirstOrDefault();
            var sortColumn = form["columns[" + form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
            var sortColumnDirection = form["order[0][dir]"].FirstOrDefault();
            var searchValue = form["search[value]"].FirstOrDefault();
            int pageSize = 0;

            if (length != "-1")
            {
                pageSize = length != null ? Convert.ToInt32(length) : 0;
            }

            int skip = start != null ? Convert.ToInt32(start) : 0;

            return new FormDataViewModel
            {
                Draw = draw,
                Length = length,
                SortColumn = sortColumn,
                SortColumnDirection = sortColumnDirection,
                SearchValue = searchValue,
                PageSize = pageSize,
                Skip = skip,
                Start = start
            };
        }


    }
}
