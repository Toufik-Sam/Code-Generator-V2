using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsToolsDesginerCode
    {
        public static string DataGridViewDesignerCode(string DataGridViewName)
        {
            StringBuilder s = new StringBuilder();
            s.Append("//\n");
            s.Append("//" + "dgv" + DataGridViewName + "\n");
            s.Append("//\n");
            s.Append("this.dgv"+ DataGridViewName+".AllowUserToAddRows = false;\n");
            s.Append("this.dgv"+ DataGridViewName + ".AllowUserToDeleteRows = false;\n");
            s.Append("this.dgv"+ DataGridViewName + ".AllowUserToResizeRows = false;\n");
            s.Append("this.dgv"+ DataGridViewName + ".BackgroundColor = System.Drawing.Color.White;\n");
            s.Append("this.dgv"+ DataGridViewName + ".ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;\n");
            s.Append("this.dgv"+ DataGridViewName + ".EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;\n");
            s.Append("this.dgv"+ DataGridViewName + ".Location = new System.Drawing.Point(12, 291);\n");
            s.Append("this.dgv"+ DataGridViewName + ".Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);\n");
            s.Append("this.dgv"+ DataGridViewName + ".MultiSelect = false;\n");
            s.Append("this.dgv"+ DataGridViewName + ".Name=dgv" + DataGridViewName + ";\n");
            s.Append("this.dgv" + DataGridViewName + ".ReadOnly = true;");
            s.Append("this.dgv" + DataGridViewName + ".SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;\n");
            s.Append("this.dgv" + DataGridViewName + ".Size = new System.Drawing.Size(1484, 371);\n");
            s.Append("this.dgv" + DataGridViewName + ".TabStop = false;\n");
            return s.ToString();
        }
        public static string ComboBoxDesignerCode(string ComboBoxName)
        {
            StringBuilder s = new StringBuilder();
            s.Append("//\n");
            s.Append("// " + ComboBoxName + "\n");
            s.Append("//\n");
            s.Append("this"+ComboBoxName+".Font = new System.Drawing.Font(\"Microsoft Sans Serif\", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));\n");
            s.Append("this."+ComboBoxName+".FormattingEnabled = true;\n");
            s.Append("this."+ComboBoxName+".Location = new System.Drawing.Point(17, 202);\n");
            s.Append(" this."+ComboBoxName+".Name =" + ComboBoxName + "\";\n");
            s.Append("this."+ ComboBoxName + ".Size = new System.Drawing.Size(240, 24);\n");
            return s.ToString();
        }
        public static string TextBoxDesignerCode(string TextBoxName)
        {
            StringBuilder s = new StringBuilder();
            s.Append("//\n");
            s.Append("// " + TextBoxName + "\n");
            s.Append("//\n");
            s.Append("this."+ TextBoxName+".Location = new System.Drawing.Point(166, 166);\n");
            s.Append("this."+ TextBoxName+".Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);\n");
            s.Append("this."+TextBoxName+".MaxLength = 50;\n");
            s.Append("this."+TextBoxName+".Name = \"" + TextBoxName + "\";\n");
            s.Append("this."+ TextBoxName+".Size = new System.Drawing.Size(230, 26);");
            return s.ToString();
        }
        public static string DateTimePickerDesignerCode(string DateTimePickerName)
        {
            StringBuilder s = new StringBuilder();
            s.Append("//\n");
            s.Append("// " + DateTimePickerName + "\n");
            s.Append("//\n");
            s.Append("this."+DateTimePickerName+".CustomFormat = \"dd/M/yyyy\";\n");
            s.Append("this." + DateTimePickerName + ".Format = System.Windows.Forms.DateTimePickerFormat.Custom;\n");
            s.Append("this." + DateTimePickerName + ".Location = new System.Drawing.Point(537, 95);\n");
            s.Append("this." + DateTimePickerName + "Name = \"" + DateTimePickerName + "\""+";\n");
            s.Append("this." + DateTimePickerName + ".Value = new System.DateTime(2000, 12, 31, 0, 0, 0, 0);\n");
            return s.ToString();
        }
        public static string LabelDesignerCode(string LabelName,string Name)
        {
            StringBuilder s = new StringBuilder();
            s.Append("//\n");
            s.Append("// " + LabelName + "\n");
            s.Append("//\n");
            s.Append("this." + LabelName + ".AutoSize = true;\n");
            s.Append("this." + LabelName + "Font = new System.Drawing.Font(\"Microsoft Sans Serif\", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));\n");
            s.Append("this." + LabelName + ".Location = new System.Drawing.Point(14, 255);\n");
            s.Append(" this."+LabelName+".Name = \""+LabelName+"\";");
            s.Append("this." + LabelName + "new System.Drawing.Size(80, 20);\n");
            s.Append("this." + LabelName + ".Text = \"" + Name + "\";");
            return s.ToString();
        }
        public static string CheckBoxDesignerCode(string CheckBoxName,string Name)
        {
            StringBuilder s = new StringBuilder();
            s.Append("//\n");
            s.Append("// " + CheckBoxName + "\n");
            s.Append("//\n");
            s.Append("this." + CheckBoxName + ".AutoSize = true;\n");
            s.Append("this." + CheckBoxName + ".Checked=false;\n");
            s.Append("this." + CheckBoxName + ".System.Windows.Forms.CheckState.Checked;\n");
            s.Append("this." + CheckBoxName + ".Location = new System.Drawing.Point(166, 236);\n");
            s.Append("this." + CheckBoxName + ".Name = \"" + CheckBoxName + "\";\n");
            s.Append("this." + CheckBoxName + ".Size =new System.Drawing.Size(137, 24);\n");
            s.Append("this."+CheckBoxName+".Text = \"" + Name + "\";\n");
            s.Append("this." + CheckBoxName + ".UseVisualStyleBackColor = true;");
            return s.ToString();
        }
        public static string PictureBoxDesignerCode(string PictureBoxName)
        {
            StringBuilder s = new StringBuilder();
            s.Append("//\n");
            s.Append("// " + PictureBoxName + "\n");
            s.Append("//\n");
            s.Append("this."+PictureBoxName+".Image = ImagePath;\n");
            s.Append("this."+ PictureBoxName + ".Location = new System.Drawing.Point(282, 45);\n");
            s.Append("this."+PictureBoxName+".Name= \"PictureBoxName\"\n");
            s.Append("this."+PictureBoxName+".Size = new System.Drawing.Size(52, 55);\n");
            s.Append("this."+PictureBoxName+".SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;\n");
            s.Append("this."+PictureBoxName+".TabStop = false");
            return s.ToString();
        }
        public static string FormAddControls(string Item)
        {
            return "this.Controls.Add(this." + Item + ");\n";
        }
        public static string InitializeComponents(string Item,string SelectedControl)
        {
            return "this." + Item + "=new System.Windows.Forms." + SelectedControl + "();\n";
        }
        public static string EndRegion(string Item,string SelectedControl)
        {
            return "private System.Windows.Forms." + SelectedControl + " " + Item + ";\n";
        }
    }
}
