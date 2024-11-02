using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Code_Generator_V2.Controls
{
    public partial class ctrlBankOfCodeElement : UserControl
    {
        private int _CurrentCodeID = -1;
        private string _CurrentCodeTitle = "";
        private string _CurrentCode = "";  
        public ctrlBankOfCodeElement()
        {
            InitializeComponent();
        }
        public class CodeClickedEventArgs : EventArgs
        {
            public int CodeID { get; }
            public string CodeTitle { get; }
            public string Code { get; }
            public CodeClickedEventArgs(int CodeID,string CodeTitle,string Code)
            {
                this.CodeID = CodeID;
                this.CodeTitle = CodeTitle;
                this.Code = Code;
            }
        }
        public delegate void CodeClickedEventHandler(object sender, CodeClickedEventArgs e);
        public event EventHandler<CodeClickedEventArgs> OnCodeTiteClicked;
        public void RaiseOnCodeTitleClicked(int CodeID,string CodeTitle,string Code)
        {
            RaiseOnCodeTitleClicked(new CodeClickedEventArgs(CodeID, CodeTitle, Code));
        }
        protected virtual void RaiseOnCodeTitleClicked(CodeClickedEventArgs e)
        {
            OnCodeTiteClicked?.Invoke(this, e);
        }
        public void LoadData(int CodeID,string CodeTitle,string Code)
        {
            _CurrentCodeTitle = CodeTitle;
            lblCodeTitle.Text = _CurrentCodeTitle;
            _CurrentCode = Code;
            _CurrentCodeID = CodeID;
        }
        private void lblCodeTitle_Click(object sender, EventArgs e)
        {
            RaiseOnCodeTitleClicked(_CurrentCodeID, _CurrentCodeTitle, _CurrentCode);
        }
        private void ctrlBankOfCodeElement_Click(object sender, EventArgs e)
        {
            RaiseOnCodeTitleClicked(_CurrentCodeID, _CurrentCodeTitle, _CurrentCode);
        }
    }
}
