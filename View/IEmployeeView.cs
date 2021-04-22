using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Garden.View
{
    interface IEmployeeView
    {
        DataGridView table { get; set; }

        ComboBox selection { get; }

        TextBox name { get; }
        TextBox type { get; }

        TextBox species { get; }

        TextBox carnivorous { get; }

        TextBox zone { get; }

    }
}
