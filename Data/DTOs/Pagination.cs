using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTOs
{
    public class Pagination
    {
        public int Page { get; set; } = 1;
        private int NumberRecordsByPage = 10;
        private readonly int MaximumNumberRecordsByPage = 50;

        public int NumberRecordsByPages
        {
            get => NumberRecordsByPage;
            set 
            {
                NumberRecordsByPage = (value > MaximumNumberRecordsByPage) ? MaximumNumberRecordsByPage : value;
            }
        }
    }
}
