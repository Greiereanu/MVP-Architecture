using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Garden.View
{
    interface IVisitorView
    {
        DataGridView table { get; set; }

        ComboBox selection { get;}

        ComboBox charts { get; }

        TextBox search { get; }
        TextBox filter { get; }

        Chart stats { get; set; }
    }
}
