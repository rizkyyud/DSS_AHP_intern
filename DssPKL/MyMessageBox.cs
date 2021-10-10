using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DssPKL
{
    class MyMessageBox
    {
        public static System.Windows.Forms.DialogResult ShowMessage(string message,string caption,System.Windows.Forms.MessageBoxButtons button,System.Windows.Forms.MessageBoxIcon icon)
        {
            System.Windows.Forms.DialogResult dlgResult = System.Windows.Forms.DialogResult.None;
            switch (button)
            {
                case System.Windows.Forms.MessageBoxButtons.OK:
                    using(CustomMessageBox ok = new CustomMessageBox())
                    {
                        ok.Text = caption;
                        ok.Message = message;
                        switch (icon)
                        {
                            case System.Windows.Forms.MessageBoxIcon.Information:
                                ok.MessageIcon = DssPKL.Properties.Resources.Information;
                                break;
                            case System.Windows.Forms.MessageBoxIcon.Question:
                                ok.MessageIcon = DssPKL.Properties.Resources.Question1;
                                break;
                        }
                        dlgResult = ok.ShowDialog();
                    }
                        break;
                case System.Windows.Forms.MessageBoxButtons.YesNo:
                    using (CustomMessageBoxYesNo YesNo = new CustomMessageBoxYesNo())
                    {
                        YesNo.Text = caption;
                        YesNo.Message = message;
                        switch (icon)
                        {
                            case System.Windows.Forms.MessageBoxIcon.Information:
                                YesNo.MessageIcon = DssPKL.Properties.Resources.Information;
                                break;
                            case System.Windows.Forms.MessageBoxIcon.Question:
                                YesNo.MessageIcon = DssPKL.Properties.Resources.Question1;
                                break;
                        }
                        dlgResult = YesNo.ShowDialog();
                    }
                    break;
            }
            return dlgResult;
        }
    }
}
