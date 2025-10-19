using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Education_Manager
{
    class PermissionHelper
    {
        public static bool HasPermission(string idChucNang)
        {
            return frmDangNhap.Global.Permissions.Contains(idChucNang);
        }

        public static void Apply(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c.Tag != null && c.Tag.ToString() != "")
                    c.Enabled = HasPermission(c.Tag.ToString());

                if (c.HasChildren)
                    Apply(c);
            }
        }
    }
}
