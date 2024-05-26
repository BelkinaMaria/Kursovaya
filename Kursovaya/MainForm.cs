using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursovaya;

public partial class MainForm : Form
{
    //private TextBox dataBox;
    private OperationType operation;
    public MainForm()
    {
        InitializeComponent();
    }

    private void buttonInsert_Click(object sender, EventArgs e)
    {
        operation = OperationType.Insert;
        NewNumberForm numForm = new();
        numForm.Show();
    }
}
