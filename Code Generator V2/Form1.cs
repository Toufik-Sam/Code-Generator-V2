using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Code_Generator_V2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGenerator_Click(object sender, EventArgs e)
        {
            ShowFormInTheMainPanel(new frmGenerator());
        }
        private void btnBank_Click(object sender, EventArgs e)
        {
            ShowFormInTheMainPanel(new frmBankOfCodes());
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void ShowFormInTheMainPanel(object FormToShow)
        {
            //here we check if the mainPanel already has a form on it in this case we Remove it 
            if (this.pnlContainer.Controls.Count > 0)
                this.pnlContainer.Controls.RemoveAt(0);
            //here we create a new form that contains the Form that we want to display 
            Form frm = FormToShow as Form;
            //we set the TopLevel Propertiy to false because we dont want the FormToShow to be on top
            frm.TopLevel = false;
            //we set the dock propertiy to Dockstyle to fill
            frm.Dock = DockStyle.Fill;
            //here we Add the form to the mainPanel
            this.pnlContainer.Controls.Add(frm);
            //sets the object that contains data about the control/ store data that is closely associated with the control.
            this.pnlContainer.Tag = frm;
            frm.Show();
        }

        private void btnNewConnection_Click(object sender, EventArgs e)
        {
            frmNewConnection NewConnection = new frmNewConnection();
        }
    }
}
