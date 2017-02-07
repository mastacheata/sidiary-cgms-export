using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace sinCsSample
{
    public partial class frmAddIn : Form
    {
        cMain fobjAddIn;

        public frmAddIn()
        {
            InitializeComponent();
        }

        public void InitObjects(cMain pobjAddIn)
        {
            fobjAddIn = pobjAddIn;
        }

        private void cmdSendData_Click(System.Object sender, System.EventArgs e)
        {
            float tmp;
            

            if (txtBG.Text.Length > 0 && !float.TryParse(txtBG.Text, out tmp))
            {
                MessageBox.Show("Please enter a numeric blood glucose level in mg/dl.");
                return;
            }

            if (txtBG.Text.Length == 0 && txtCarb.Text.Length == 0)
            {
                MessageBox.Show("Please enter at least one value to be sent to the current patient's log-book.");
                return;
            }

            //Now send the data to the log...
            if (txtBG.Text.Length > 0)
            {
                //Add the blood glucose (must be sent in mg/dl!!)
                SiDiaryNET.mAddInObject.SaveData(Convert.ToInt16(DateTime.Now.Year), Convert.ToByte(DateTime.Now.Month), Convert.ToByte(DateTime.Now.Day), Convert.ToByte(DateTime.Now.Hour), Convert.ToByte(DateTime.Now.Minute), "1", txtBG.Text);
            }

            if (txtCarb.Text.Length  > 0)
            {
                //Add some carbs
                SiDiaryNET.mAddInObject.SaveData(Convert.ToInt16(DateTime.Now.Year), Convert.ToByte(DateTime.Now.Month), Convert.ToByte(DateTime.Now.Day), Convert.ToByte(DateTime.Now.Hour), Convert.ToByte(DateTime.Now.Minute), "3", txtCarb.Text);
            }

            if (chkHypo.Checked)
            {
                //Send a event-record to the log-book
                SiDiaryNET.mAddInObject.SaveData(Convert.ToInt16(DateTime.Now.Year), Convert.ToByte(DateTime.Now.Month), Convert.ToByte(DateTime.Now.Day), Convert.ToByte(DateTime.Now.Hour), Convert.ToByte(DateTime.Now.Minute), "2", "-");
            }

            //Send a remark
            SiDiaryNET.mAddInObject.SaveData(Convert.ToInt16(DateTime.Now.Year), Convert.ToByte(DateTime.Now.Month), Convert.ToByte(DateTime.Now.Day), Convert.ToByte(DateTime.Now.Hour), Convert.ToByte(DateTime.Now.Minute), "7", "Data was sent by demo AddIn-Project.");

            //Commit the data
            SiDiaryNET.mAddInObject.SaveDataCommit(cMain.ADDIN_NAME);

            //Cancel would be possible with 
            //Call fobjMainApp.SaveDataRollback()

        }
    }
}
