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
    private OperationType operation;
    BinarySearchTree tree = new();
    private Visualizer? visualizer;

    private bool continueStepByStep;
    private bool stopStepByStep;

    public MainForm()
    {
        InitializeComponent();
    }

    private void buttonInsert_Click(object sender, EventArgs e)
    {
        if (tree.getNumNodes(tree.root) <= 20)
        {
            operation = OperationType.Insert;
            NewNumberForm numForm = new();
            numForm.ShowDialog();
            int? value = numForm.Number;
            if (value != null)
            {
                tree.insert(new Node((int)value));
                refresh((int)value);

            }
        }
        else
        {
            MessageBox.Show("Больше нет свободных мест для элементов!", "Результат",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void buttonSearch_Click(object sender, EventArgs e)
    {
        if (tree.getNumNodes(tree.root) > 0)
        {
            operation = OperationType.Search;
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

    private void buttonRemove_Click(object sender, EventArgs e)
    {
        if (tree.getNumNodes(tree.root) > 0)
        {
            operation = OperationType.Remove;
            NewNumberForm numForm = new();
            numForm.ShowDialog();
            int? value = numForm.Number;
            if (value != null)
            {
                tree.remove((int)value);

                refresh((int)value);
            }
        }
        else
        {
            MessageBox.Show("Отсутствуют элементы для удаления!", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void refresh(int value)
    {
        if (tree.root == null) return;

        Bitmap bmp = new(pictureBoxBT.Width,
            pictureBoxBT.Height);
        Graphics g = Graphics.FromImage(bmp);
        int?[,] oldTreeArray;
        Visualizer? oldVisualizer;
        if (visualizer != null)
        {
            oldTreeArray = visualizer.treeArray;
            oldVisualizer = visualizer;
        }
        else
        {
            oldTreeArray = null;
            oldVisualizer = null;
        }

        visualizer = new Visualizer(pictureBoxBT.Width,
            pictureBoxBT.Height, tree);

        if (checkBoxStepByStep.Checked && visualizer != null && oldTreeArray != null)
        {
            buttonContinueStepByStep.Enabled = true;
            buttonContinueWithoutStops.Enabled = true;
            switch (operation)
            {
                case OperationType.Insert:
                    goStepByStepInsert(value, oldTreeArray);
                    break;
                case OperationType.Search:
                    {
                        goStepByStepSearch(value);

                        if (tree.search(value))
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
                    }

                case OperationType.Remove:
                    {
                        goStepByStepRemove(value, oldVisualizer);
                        if (tree.remove(value))
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
            buttonContinueStepByStep.Enabled = false;
            buttonContinueWithoutStops.Enabled = false;
            stopStepByStep = false;
            using (Graphics gr = pictureBoxCompare.CreateGraphics())
            {
                gr.Clear(pictureBoxCompare.BackColor);
            }
        }

        visualizer.drawTree(g);
        pictureBoxBT.Image = bmp;
    }

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
    }

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
                            using (Graphics gr = pictureBoxCompare.CreateGraphics())
                            {
                                j = visualizer.nextNumRight(i + 1, j); 
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
    }

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
    }

    private void buttonContinueStepByStep_Click(object sender, EventArgs e)
    {
        continueStepByStep = true;
    }

    private void buttonContinueWithoutStops_Click(object sender, EventArgs e)
    {
        stopStepByStep = true;
    }
}
