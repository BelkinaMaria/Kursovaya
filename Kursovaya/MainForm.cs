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
                    currentStep++;
                    break;

                case OperationType.Search:
                    management.visualizer = new Visualizer(pictureBoxBT.Width, pictureBoxBT.Height, management.tree);
                    steps = management.GetStepByStepList(value, management.visualizer);
                    management.ShowStepByStepSearch(steps[currentStep], pictureBoxBT, pictureBoxCompare);
                    currentStep++;
                    break;

                case OperationType.Remove:
                    steps = management.GetStepByStepList(value, management.visualizer);
                    management.ShowStepByStepRemove(steps[currentStep], pictureBoxBT, pictureBoxCompare);
                    currentStep++;
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



    /*/// <summary>
    /// Выполнение пошаговой вставки.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="oldTreeArray"></param>
    private void goStepByStepInsert(int value, int?[,] oldTreeArray)
    {
        int[] xy = visualizer.newElemXY(oldTreeArray);
        int x = xy[0];
        int y = xy[1];

        using (Graphics g = pictureBoxBT.CreateGraphics())
        {
            Pen redPen = new Pen(Color.Red, 2);
            int j = visualizer.nextNumRight(0, 0);

            g.Clear(pictureBoxBT.BackColor);
            visualizer.drawTreeWithoutElem(g, x, y);

            if (visualizer.treeArray[0, j] != null)
            {
                g.DrawEllipse(redPen, visualizer.x[0, j] - 5, visualizer.y[0, j], 65, 35);
                continueStepByStep = false;
                using (Graphics gr = pictureBoxCompare.CreateGraphics())
                {
                    if (visualizer.treeArray[0, j] > value)
                    {
                        gr.Clear(pictureBoxCompare.BackColor);
                        gr.DrawString($"{value} < {visualizer.treeArrayNode[0, j].data}", new Font("Arial", 12), Brushes.Black, new PointF(10, 10));
                    }
                    else
                    {
                        gr.Clear(pictureBoxCompare.BackColor);
                        gr.DrawString($"{value} >= {visualizer.treeArrayNode[0, j].data}", new Font("Arial", 12), Brushes.Black, new PointF(10, 10));
                    }
                }
                while (!continueStepByStep && !stopStepByStep)
                {
                    Application.DoEvents();
                }
            }

            for (int i = 0; i < visualizer.treeArray.GetLength(0) && !stopStepByStep; i++)
            {
                if (visualizer.treeArray[i, j] != null)
                {
                    if (visualizer.treeArrayNode[i, j].data > value)
                    {
                        if (visualizer.treeArrayNode[i, j].left != null)
                        {
                            j = visualizer.nextNumLeft(i + 1, j);
                            using (Graphics gr = pictureBoxCompare.CreateGraphics())
                            {
                                if (visualizer.treeArray[i + 1, j] > value)
                                {
                                    gr.Clear(pictureBoxCompare.BackColor);
                                    gr.DrawString($"{value} < {visualizer.treeArrayNode[i + 1, j].data}", new Font("Arial", 12), Brushes.Black, new PointF(10, 10));
                                }
                                else
                                {
                                    gr.Clear(pictureBoxCompare.BackColor);
                                    gr.DrawString($"{value} >= {visualizer.treeArrayNode[i + 1, j].data}", new Font("Arial", 12), Brushes.Black, new PointF(10, 10));
                                }
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        if (visualizer.treeArrayNode[i, j].right != null)
                        {
                            j = visualizer.nextNumRight(i + 1, j);
                            using (Graphics gr = pictureBoxCompare.CreateGraphics())
                            {
                                if (visualizer.treeArray[i + 1, j] > value)
                                {
                                    gr.Clear(pictureBoxCompare.BackColor);
                                    gr.DrawString($"{value} < {visualizer.treeArrayNode[i + 1, j].data}", new Font("Arial", 12), Brushes.Black, new PointF(10, 10));
                                }
                                else
                                {
                                    gr.Clear(pictureBoxCompare.BackColor);
                                    gr.DrawString($"{value} >= {visualizer.treeArrayNode[i + 1, j].data}", new Font("Arial", 12), Brushes.Black, new PointF(10, 10));
                                }
                            }
                        }
                        else
                        {
                            break;
                        }
                    }

                    g.Clear(pictureBoxBT.BackColor);
                    continueStepByStep = false;
                    visualizer.drawTreeWithoutElem(g, x, y);
                    g.DrawEllipse(redPen, visualizer.x[i + 1, j] - 5, visualizer.y[i + 1, j], 65, 35);
                    while (!continueStepByStep && !stopStepByStep)
                    {
                        Application.DoEvents();
                    }
                }
            }
        }
    }*/

    /*/// <summary>
    /// Выполение пошагового поиска.
    /// </summary>
    /// <param name="value"></param>
    private void goStepByStepSearch(int value)
    {
        using (Graphics g = pictureBoxBT.CreateGraphics())
        {
            Pen redPen = new Pen(Color.Red, 2);
            int j = visualizer.nextNumRight(0, 0);

            g.Clear(pictureBoxBT.BackColor);
            visualizer.drawTree(g);

            if (visualizer.treeArray[0, j] != null)
            {
                g.DrawEllipse(redPen, visualizer.x[0, j] - 5, visualizer.y[0, j], 65, 35);
                continueStepByStep = false;
                using (Graphics gr = pictureBoxCompare.CreateGraphics())
                {
                    if (visualizer.treeArray[0, j] > value)
                    {
                        gr.Clear(pictureBoxCompare.BackColor);
                        gr.DrawString($"{value} < {visualizer.treeArrayNode[0, j].data}", new Font("Arial", 12), Brushes.Black, new PointF(10, 10));
                    }
                    else
                    {
                        gr.Clear(pictureBoxCompare.BackColor);
                        gr.DrawString($"{value} >= {visualizer.treeArrayNode[0, j].data}", new Font("Arial", 12), Brushes.Black, new PointF(10, 10));
                    }
                }

                while (!continueStepByStep && !stopStepByStep)
                {
                    Application.DoEvents();
                }
            }

            for (int i = 0; i < visualizer.treeArray.GetLength(0) && !stopStepByStep; i++)
            {
                if (visualizer.treeArray[i, j] != null)
                {
                    if (visualizer.treeArrayNode[i, j].data > value)
                    {
                        if (visualizer.treeArrayNode[i, j].left != null)
                        {
                            j = visualizer.nextNumLeft(i + 1, j);
                            using (Graphics gr = pictureBoxCompare.CreateGraphics())
                            {
                                if (visualizer.treeArray[i + 1, j] > value)
                                {
                                    gr.Clear(pictureBoxCompare.BackColor);
                                    gr.DrawString($"{value} < {visualizer.treeArrayNode[i + 1, j].data}", new Font("Arial", 12), Brushes.Black, new PointF(10, 10));
                                }
                                else
                                {
                                    gr.Clear(pictureBoxCompare.BackColor);
                                    gr.DrawString($"{value} >= {visualizer.treeArrayNode[i + 1, j].data}", new Font("Arial", 12), Brushes.Black, new PointF(10, 10));
                                }
                            }

                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        if (visualizer.treeArrayNode[i, j].right != null)
                        {
                            j = visualizer.nextNumRight(i + 1, j);
                            using (Graphics gr = pictureBoxCompare.CreateGraphics())
                            {
                                if (visualizer.treeArray[i + 1, j] > value)
                                {
                                    gr.Clear(pictureBoxCompare.BackColor);
                                    gr.DrawString($"{value} < {visualizer.treeArrayNode[i + 1, j].data}", new Font("Arial", 12), Brushes.Black, new PointF(10, 10));
                                }
                                else
                                {
                                    gr.Clear(pictureBoxCompare.BackColor);
                                    gr.DrawString($"{value} >= {visualizer.treeArrayNode[i + 1, j].data}", new Font("Arial", 12), Brushes.Black, new PointF(10, 10));
                                }
                            }
                        }
                        else
                        {
                            break;
                        }
                    }

                    g.Clear(pictureBoxBT.BackColor);
                    continueStepByStep = false;
                    visualizer.drawTree(g);
                    g.DrawEllipse(redPen, visualizer.x[i + 1, j] - 5, visualizer.y[i + 1, j], 65, 35);
                    while (!continueStepByStep && !stopStepByStep)
                    {
                        Application.DoEvents();
                    }
                }
            }
        }
    }*/

    /*/// <summary>
    /// Выполнение пошагового удаления.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="oldVisualiser"></param>
    private void goStepByStepRemove(int value, Visualizer oldVisualiser)
    {
        using (Graphics g = pictureBoxBT.CreateGraphics())
        {
            Pen redPen = new Pen(Color.Red, 2);
            int j = oldVisualiser.nextNumRight(0, 0);

            g.Clear(pictureBoxBT.BackColor);
            oldVisualiser.drawTree(g);

            if (oldVisualiser.treeArray[0, j] != null)
            {
                g.DrawEllipse(redPen, oldVisualiser.x[0, j] - 5, oldVisualiser.y[0, j], 65, 35);
                continueStepByStep = false;
                using (Graphics gr = pictureBoxCompare.CreateGraphics())
                {
                    if (oldVisualiser.treeArray[0, j] > value)
                    {
                        gr.Clear(pictureBoxCompare.BackColor);
                        gr.DrawString($"{value} < {oldVisualiser.treeArrayNode[0, j].data}", new Font("Arial", 12), Brushes.Black, new PointF(10, 10));
                    }
                    else
                    {
                        gr.Clear(pictureBoxCompare.BackColor);
                        gr.DrawString($"{value} >= {oldVisualiser.treeArrayNode[0, j].data}", new Font("Arial", 12), Brushes.Black, new PointF(10, 10));
                    }
                }
                while (!continueStepByStep && !stopStepByStep)
                {
                    Application.DoEvents();
                }
            }

            for (int i = 0; i < oldVisualiser.treeArray.GetLength(0) && !stopStepByStep; i++)
            {
                if (oldVisualiser.treeArray[i, j] != null)
                {
                    if (oldVisualiser.treeArrayNode[i, j].data > value)
                    {
                        if (oldVisualiser.treeArrayNode[i, j].left != null)
                        {
                            j = oldVisualiser.nextNumLeft(i + 1, j);
                            using (Graphics gr = pictureBoxCompare.CreateGraphics())
                            {
                                j = oldVisualiser.nextNumRight(i + 1, j);
                                if (oldVisualiser.treeArray[i + 1, j] > value)
                                {
                                    gr.Clear(pictureBoxCompare.BackColor);
                                    gr.DrawString($"{value} < {oldVisualiser.treeArrayNode[i + 1, j].data}", new Font("Arial", 12), Brushes.Black, new PointF(10, 10));
                                }
                                else
                                {
                                    gr.Clear(pictureBoxCompare.BackColor);
                                    gr.DrawString($"{value} >= {oldVisualiser.treeArrayNode[i + 1, j].data}", new Font("Arial", 12), Brushes.Black, new PointF(10, 10));
                                }
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        if (oldVisualiser.treeArrayNode[i, j].right != null)
                        {
                            j = oldVisualiser.nextNumRight(i + 1, j);
                            using (Graphics gr = pictureBoxCompare.CreateGraphics())
                            {
                                j = oldVisualiser.nextNumRight(i + 1, j);
                                if (oldVisualiser.treeArray[i + 1, j] > value)
                                {
                                    gr.Clear(pictureBoxCompare.BackColor);
                                    gr.DrawString($"{value} < {oldVisualiser.treeArrayNode[i + 1, j].data}", new Font("Arial", 12), Brushes.Black, new PointF(10, 10));
                                }
                                else
                                {
                                    gr.Clear(pictureBoxCompare.BackColor);
                                    gr.DrawString($"{value} >= {oldVisualiser.treeArrayNode[i + 1, j].data}", new Font("Arial", 12), Brushes.Black, new PointF(10, 10));
                                }
                            }
                        }
                        else
                        {
                            break;
                        }
                    }

                    g.Clear(pictureBoxBT.BackColor);
                    continueStepByStep = false;
                    oldVisualiser.drawTree(g);
                    g.DrawEllipse(redPen, oldVisualiser.x[i + 1, j] - 5, oldVisualiser.y[i + 1, j], 65, 35);
                    while (!continueStepByStep && !stopStepByStep)
                    {
                        Application.DoEvents();
                    }
                }
            }
        }
    }*/

    /// <summary>
    /// Нажатие кнопки "далее".
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void buttonContinue_Click(object sender, EventArgs e)
    {
        if (!stopStepByStep && /*(*/steps.Count > currentStep /*&& (management.operation == OperationType.Insert || management.operation == OperationType.Search) ||
            steps.Count + 1 > currentStep && management.operation == OperationType.Remove)*/)
        {
            switch (management.operation)
            {
                case OperationType.Insert:
                    management.ShowStepByStepInsert(steps[currentStep], oldVisualizer, pictureBoxBT, pictureBoxCompare);
                    currentStep++;
                    break;

                case OperationType.Search:
                    management.ShowStepByStepSearch(steps[currentStep], pictureBoxBT, pictureBoxCompare);
                    currentStep++;
                    
                    break;

                case OperationType.Remove:
                    management.ShowStepByStepRemove(steps[currentStep], pictureBoxBT, pictureBoxCompare);
                    currentStep++;
                    break;
            }
        }
        else if ((/*(*/steps.Count <= currentStep || stopStepByStep)/* && (management.operation == OperationType.Insert || management.operation == OperationType.Search)) ||
            ((steps.Count <= currentStep + 1 || stopStepByStep) && management.operation == OperationType.Remove)*/)
        {
            endOfTheOperation(steps[steps.Count - 1][2]);
            buttonContinue.Enabled = false;
            buttonBack.Enabled = false;
            buttonStop.Enabled = false;
            stopStepByStep = false;
            using (Graphics gr = pictureBoxCompare.CreateGraphics())
            {
                gr.Clear(pictureBoxCompare.BackColor);
            }
            Bitmap bmp = new(pictureBoxBT.Width, pictureBoxBT.Height);
            Graphics g = Graphics.FromImage(bmp);

            management.visualizer.drawTree(g);
            pictureBoxBT.Image = bmp;
        }
    }

    // TODO закинуть в отдельную приватную функцию switch с разными окончаниями (для remove и search)
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

    private void buttonBack_Click(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// Нажатие кнопки "продолжить без остановок".
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void buttonStop_Click(object sender, EventArgs e)
    {
        stopStepByStep = true;
    }
}
