using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA_tcc
{
    public partial class formCadDispo : Form
    {
        public formCadDispo()
        {
            InitializeComponent();

            AddRowToPanel(panel, new string[] {"Segunda","Terça","Quarta","Quinta","Sexta","Sábado" });
            AddItem("1", "2", "3");
            
            
        }

        private void AddRowToPanel(TableLayoutPanel panel, string[] rowElements)
        {
            if (panel.ColumnCount != rowElements.Length)
                throw new Exception("Elements number doesn't match!");
            //get a reference to the previous existent row
            RowStyle temp = panel.RowStyles[panel.RowCount - 1];
            //increase panel rows count by one
            panel.RowCount++;
            //add a new RowStyle as a copy of the previous one
            panel.RowStyles.Add(new RowStyle(temp.SizeType, temp.Height));
            //add the control
            for (int i = 0; i < rowElements.Length; i++)
            {
                panel.Controls.Add(new Label() { Text = rowElements[i] }, i, panel.RowCount - 1);
            }
        }

        private void AddItem(string address, string contactNum, string email)
        {
            //get a reference to the previous existent 
            RowStyle temp = panel.RowStyles[panel.RowCount - 1];
            //increase panel rows count by one
            panel.RowCount++;
            //add a new RowStyle as a copy of the previous one
            panel.RowStyles.Add(new RowStyle(temp.SizeType, temp.Height));
            //add your three controls
            panel.Controls.Add(new Label() { Text = address }, 0, panel.RowCount - 1);
            panel.Controls.Add(new Label() { Text = contactNum }, 1, panel.RowCount - 1);
            panel.Controls.Add(new Label() { Text = email }, 2, panel.RowCount - 1);
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
