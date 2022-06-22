using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyAssignment.Models.Queries
{
    /// <summary>
    /// Helper class for Queries proposies.(Keeps employee's Index method cleaner)
    /// </summary>
    public class EmployeeFilterSettings
    {
        public string searchLastName { get; set; }

        public string searchCountry { get; set; }
    }
}