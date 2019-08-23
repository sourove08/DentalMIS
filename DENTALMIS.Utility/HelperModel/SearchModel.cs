namespace DENTALMIS.Utility.HelperModel
{
    public class SearchModel<T> where T:class 
    {
        public int TotalRecords { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Sort { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SortDir { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ReportType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? Page { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PageIndex
        {
            get
            {
                int index = 0;
                int pageSize = AppConfig.PageSize;
                if (Page.HasValue && Page.Value > 0)
                {
                    index = Page.Value - 1;
                }
                return index;
            }
        }


        public virtual bool IsSearch { get; set; }
        /// <summary>
        /// 
        /// </summary>

        public virtual bool IsSelected { get; set; }


    }
}
