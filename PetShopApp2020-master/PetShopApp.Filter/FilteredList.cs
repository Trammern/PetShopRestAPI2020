using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Core.Entities
{
    public class FilteredList<T>
    {
        public Filter FilterUsed { get; set; }
        public int TotalCount { get; set; }
        public List<T> List { get; set; }
    }
}
