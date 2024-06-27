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
    /// <summary>
    /// Введённое пользователем число
    /// </summary>
    public int? Number {  get; private set; }

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
        if (string.IsNullOrWhiteSpace(value))
        {
            Number = null;
        }
        else if (int.TryParse(value, out int number))
        {
            Number = number;
            MessageBox.Show("Запись прошла успешно.", "Результат", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }
        else
        {
            MessageBox.Show("Произошла ошибка при записи!", "Результат",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
