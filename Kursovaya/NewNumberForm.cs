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

public partial class NewNumberForm : Form
{
    public NewNumberForm()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Обработка нажатия кнопки ОК.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void buttonOk_Click(object sender, EventArgs e)
    {
        string value = maskedTextBoxNmber.Text;
        if (int.TryParse(value, out int number) )
        {
            MessageBox.Show("Запись прошла успешно.", "Результат", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }
        else // Если ввели какую-то ересь - отправить переделывать.
        {
            MessageBox.Show("Произошла ошибка при записи!", "Результат",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
