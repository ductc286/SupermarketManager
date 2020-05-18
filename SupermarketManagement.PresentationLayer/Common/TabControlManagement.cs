using Supermarketmanagement.PresentationLayer.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Supermarketmanagement.PresentationLayer.Common
{
    public  class TabControlManagement
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tabControl"></param>
        /// <param name="title"></param>
        /// <returns>first index if found</returns>
        /// <returns>-1 if not found</returns>
        public static int GetIndexByTitle(TabControl tabControl, string title)
        {
            int i = 0;
            foreach (CustomTabItem item in tabControl.Items)
            {
                if (item.Title == title)
                {
                    return i;
                }
                i++;
            }
            return -1;
        }

        //public static void AddAndGotoCustomTabItem(TabControl tabControl, Cus)
    }
}
