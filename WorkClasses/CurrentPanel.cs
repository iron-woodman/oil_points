using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oil_points.WorkClasses
{

    public static class LastPanel
    {
        public static Stack<Panel> Stack = new Stack<Panel>();
    }

    /// <summary>
    /// последняя панель (необходимо для корректной работы кнопки Назад)
    /// </summary>
    public enum Panel { NODE_LIST = 1, NODE1_STAT, NODE2_STAT, NODE3_STAT};
}
