using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WilliamsVacationPlanner.Models
{
    /// <summary>
    /// Holds query options for a Vacation
    /// 
    /// Author: Nolan Williams
    /// Date:   4/7/2021
    /// </summary>
    /// <seealso cref="WilliamsSalesRep.Models.QueryOptions{WilliamsSalesRep.Models.Sale}" />
    public class VacationQueryOptions : QueryOptions<Vacation>
    {

        /// <summary>
        /// Appends Where & OrderBy clauses based on the given [builder].
        /// </summary>
        /// <param name="builder">The builder.</param>
        public void Sort(VacationGridBuilder builder)
        {
            if (builder.IsSortByLocation)
            {
                OrderBy = v => v.Location.Name;
            }
            else if (builder.IsSortByStartDate)
            {
                OrderBy = v => v.StartDate;
            }
            else if (builder.IsSortByEndDate)
            {
                OrderBy = v => v.EndDate;
            }
            else if (builder.IsSortByAccommodation)
            {
                OrderBy = v => v.Accommodation.Name;
            }
        }
    }
}
