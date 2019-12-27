namespace Masterpiece.Code.Common
{
    public class PagingObject
    {
        public int PageIndex
        {
            set; get;
        }

        public int PageSize
        {
            set; get;
        }

        public int TotalCount
        {
            set; get;
        }

        public PagingObject()
        {
        }

        public PagingObject(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
    }
}