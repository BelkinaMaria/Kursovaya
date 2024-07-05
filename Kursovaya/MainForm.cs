using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Kursovaya;

public partial class MainForm : Form
{
    //BinarySearchTree tree = new();
    //private Visualizer? visualizer;
    Management management = new Management();
    //private OperationType operation;
    private bool continueStepByStep;
    private bool stopStepByStep;
    private int currentStep;
    List<int[]> steps;
    Visualizer? oldVisualizer;

    /// <summary>
    /// Конструктор
    /// </summary>
    public MainForm()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Нажатие кнопки "вставить элемент".
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void buttonInsert_Click(object sender, EventArgs e)
    {
        if (management.tree.getNumNodes(management.tree.root) <= 20)
        {
            management.operation = OperationType.Insert;
            NewNumberForm numForm = new();
            numForm.ShowDialog();
            int? value = numForm.Number;
            if (value != null)
            {
                management.tree.insert(new Node((int)value));
                refresh((int)value);

            }
        }
        else
        {
            MessageBox.Show("Больше нет свободных мест для элементов!", "Результат",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Нажатие кнопки "найти элемент".
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void buttonSearch_Click(object sender, EventArgs e)
    {
        if (management.tree.getNumNodes(management.tree.root) > 0)
        {
            management.operation = OperationType.Search;
            NewNumberForm numForm = new();
            numForm.ShowDialog();
            int? value = numForm.Number;
            if (value != null)
            {
                refresh((int)value);
            }

        }
        else
        {
            MessageBox.Show("Отсутствуют элементы для поиска!", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Нажатие кнопки "удалить элемент".
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void buttonRemove_Click(object sender, EventArgs e)
    {
        if (management.tree.getNumNodes(management.tree.root) > 0)
        {
            management.operation = OperationType.Remove;
            NewNumberForm numForm = new();
            numForm.ShowDialog();
            int? value = numForm.Number;
            if (value != null)
            {
                management.tree.search((int)value);

                refresh((int)value);
            }
        }
        else
        {
            MessageBox.Show("Отсутствуют элементы для удаления!", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Изменение pictureBoxBT и пошаговое выполнение.
    /// </summary>
    /// <param name="value"></param>
    private void refresh(int value)
    {
        if (management.tree.root == null) return;

        Bitmap bmp = new(pictureBoxBT.Width, pictureBoxBT.Height);
        Graphics g = Graphics.FromImage(bmp);

        /*if (management.visualizer != null)
        {
            oldVisualizer = management.visualizer;
        }
        else
        {
            oldVisualizer = null;
        }

        management.visualizer = new Visualizer(pictureBoxBT.Width,
            pictureBoxBT.Height, management.tree);*/

        if (checkBoxStepByStep.Checked)
        {
            buttonContinue.Enabled = true;
            buttonStop.Enabled = true;
            //buttonBack.Enabled = true;

            buttonInsert.Enabled = false;
            buttonSearch.Enabled = false;
            buttonRemove.Enabled = false;

            currentStep = 0;
            switch (management.operation)
            {
                case OperationType.Insert:
                    if (management.visualizer != null)
                    {
                        oldVisualizer = management.visualizer;
                    }
                    else
                    {
                        oldVisualizer = null;
                    }

                    management.visualizer = new Visualizer(pictureBoxBT.Width, pictureBoxBT.Height, management.tree);
                    steps = management.GetStepByStepList(value, management.visualizer);
                    management.ShowStepByStepInsert(steps[currentStep], oldVisualizer, pictureBoxBT, pictureBoxCompare);
                    //currentStep++;
                    break;

                case OperationType.Search:
                    management.visualizer = new Visualizer(pictureBoxBT.Width, pictureBoxBT.Height, management.tree);
                    steps = management.GetStepByStepList(value, management.visualizer);
                    management.ShowStepByStepSearch(steps[currentStep], pictureBoxBT, pictureBoxCompare);
                    //currentStep++;
                    break;

                case OperationType.Remove:
                    steps = management.GetStepByStepList(value, management.visualizer);
                    management.ShowStepByStepRemove(steps[currentStep], pictureBoxBT, pictureBoxCompare);
                    //currentStep++;
                    break;
                    
            }
        }
        else
        {
            management.visualizer = new Visualizer(pictureBoxBT.Width, pictureBoxBT.Height, management.tree);
            management.visualizer.drawTree(g);
            pictureBoxBT.Image = bmp;
        }
    }

    /// <summary>
    /// Нажатие кнопки "далее".
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void buttonContinue_Click(object sender, EventArgs e)
    {
        if (steps.Count > currentStep + 1)
        {
            currentStep++;
            switch (management.operation)
            {
                case OperationType.Insert:
                    management.ShowStepByStepInsert(steps[currentStep], oldVisualizer, pictureBoxBT, pictureBoxCompare);
                    break;

                case OperationType.Search:
                    management.ShowStepByStepSearch(steps[currentStep], pictureBoxBT, pictureBoxCompare);
                    
                    break;

                case OperationType.Remove:
                    management.ShowStepByStepRemove(steps[currentStep], pictureBoxBT, pictureBoxCompare);
                    break;
            }

            if (currentStep > 0)
            {
                buttonBack.Enabled = true;
            }
        }
        else
        {
            endOfTheOperation(steps[steps.Count - 1][2]);
            buttonContinue.Enabled = false;
            buttonBack.Enabled = false;
            buttonStop.Enabled = false;

            buttonInsert.Enabled = true;
            buttonSearch.Enabled = true;
            buttonRemove.Enabled = true;

            using (Graphics gr = pictureBoxCompare.CreateGraphics())
            {
                gr.Clear(pictureBoxCompare.BackColor);
            }
            Bitmap bmp = new(pictureBoxBT.Width, pictureBoxBT.Height);
            Graphics g = Graphics.FromImage(bmp);
            if (management.operation == OperationType.Remove) 
            { 
                management.visualizer = new Visualizer(pictureBoxBT.Width, pictureBoxBT.Height, management.tree);
            }
            management.visualizer.drawTree(g);
            pictureBoxBT.Image = bmp;
        }
    }

    private void buttonBack_Click(object sender, EventArgs e)
    {
        if (currentStep > 0)
        {
            currentStep--;
            switch (management.operation)
            {
                case OperationType.Insert:
                    management.ShowStepByStepInsert(steps[currentStep], oldVisualizer, pictureBoxBT, pictureBoxCompare);
                    break;

                case OperationType.Search:
                    management.ShowStepByStepSearch(steps[currentStep], pictureBoxBT, pictureBoxCompare);

                    break;

                case OperationType.Remove:
                    management.ShowStepByStepRemove(steps[currentStep], pictureBoxBT, pictureBoxCompare);
                    break;
            }

            if (currentStep > 0)
            {
                buttonBack.Enabled = true;
            } 
            else
            {
                buttonBack.Enabled = false;
            }
        }
    }

    private void endOfTheOperation(int value)
    {
        switch (management.operation)
        {
            case OperationType.Search:
                if (management.tree.search(value))
                {
                    MessageBox.Show("Элемент \"" + value + "\" найден.", "Результат",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Элемент \"" + value + "\" отсутствует в дереве.", "Результат",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                break;

            case OperationType.Remove:
                management.visualizer = new Visualizer(pictureBoxBT.Width, pictureBoxBT.Height, management.tree);
                if (management.tree.remove(value))
                {
                    MessageBox.Show("Элемент \"" + value + "\" удалён.", "Результат",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Элемент \"" + value + "\" отсутствует в дереве.", "Результат",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                break;
        }
    }

    /// <summary>
    /// Нажатие кнопки "продолжить без остановок".
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void buttonStop_Click(object sender, EventArgs e)
    {
        /*stopStepByStep = true;*/
        endOfTheOperation(steps[steps.Count - 1][2]);
        currentStep = steps.Count;

        buttonContinue.Enabled = false;
        buttonBack.Enabled = false;
        buttonStop.Enabled = false;

        buttonInsert.Enabled = true;
        buttonSearch.Enabled = true;
        buttonRemove.Enabled = true;

        using (Graphics gr = pictureBoxCompare.CreateGraphics())
        {
            gr.Clear(pictureBoxCompare.BackColor);
        }
        Bitmap bmp = new(pictureBoxBT.Width, pictureBoxBT.Height);
        Graphics g = Graphics.FromImage(bmp);
        if (management.operation == OperationType.Remove)
        {
            management.visualizer = new Visualizer(pictureBoxBT.Width, pictureBoxBT.Height, management.tree);
        }
        management.visualizer.drawTree(g);
        pictureBoxBT.Image = bmp;
    }
}
