using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmoleReportPortal
{
    public class GridViewGroupList : List<GridViewGroup>
    {
        public GridViewGroup this[string name]
        {
            get { return this.FindGroupByName(name); }
        }

        public GridViewGroup FindGroupByName(string name)
        {
            foreach (GridViewGroup g in this)
            {
                if (g.Name.ToLower() == name.ToLower()) return g;
            }

            return null;
        }
    }

}
