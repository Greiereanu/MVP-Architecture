using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Garden.View
{
    interface IAdminView
    {
        DataGridView table { get; set; }

        ComboBox selection { get; }

        TextBox account { get; }
        TextBox password { get; }
        TextBox role { get; }
    }
}
