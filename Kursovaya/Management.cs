using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursovaya;

/// <summary>
/// Класс-управленец.
/// </summary>
public class Management
{
    public BinarySearchTree tree = new();
    public Visualizer? visualizer;
    public OperationType operation;
    public Storage storage = new Storage();

    //public bool continueStepByStep;

/*    public void refresh(int value, bool stepByStep, PictureBox bigPictureBox, PictureBox smallPictureBox,
        OperationType operation, Button buttonContinue, Button buttonStop, Form form)
    {
        Bitmap bmp = new(bigPictureBox.Width, bigPictureBox.Height);
        Graphics g = Graphics.FromImage(bmp);
        //int?[,] oldTreeArray;
        Visualizer? oldVisualizer;
        if (visualizer != null)
        {
            //oldTreeArray = visualizer.treeArray;
            oldVisualizer = visualizer;
        }
        else
        {
            //oldTreeArray = null;
            oldVisualizer = null;
        }

        visualizer = new Visualizer(bigPictureBox.Width,
            bigPictureBox.Height, tree);

        if (stepByStep && visualizer != null && oldVisualizer != null)
        {
            buttonContinue.Enabled = true;
            buttonStop.Enabled = true;
            
            switch (operation)
            {
                case OperationType.Insert:
                    List<int[]> steps = GetStepByStepList(value, visualizer);
                    //проходка по шагам.
                    break;

                //case OperationType.Search:
                

            }
        }
    }




*/
    public List<int[]> GetStepByStepList(int value, Visualizer visualizer)
    {
        List<int[]> result = new List<int[]>();
        int j = visualizer.nextNumRight(0, 0);

        if (visualizer.treeArray[0, j] != null)
        {
            result.Add(new int[] { 0, j, value, (int)visualizer.treeArray[0, j] });
        }

        for (int i = 0; i < visualizer.treeArray.GetLength(0); i++)
        {
            if (visualizer.treeArray[i, j] != null)
            {
                if (visualizer.treeArrayNode[i, j].data > value)
                {
                    if (visualizer.treeArrayNode[i, j].left != null)
                    {
                        j = visualizer.nextNumLeft(i + 1, j);
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
                    }
                    else
                    {
                        break;
                    }
                }

                result.Add(new int[] {i + 1, j, value, (int)visualizer.treeArray[i + 1, j] });
            }
        }

        return result;
    }

    public void ShowStepByStepInsert(int[] step, Visualizer oldVisualizer, PictureBox bigPictureBox, PictureBox smallPictureBox)
    {
        int[] xy = visualizer.newElemXY(oldVisualizer.treeArray);
        int x = xy[0];
        int y = xy[1];

        using (Graphics g = bigPictureBox.CreateGraphics())
        {
            Pen redPen = new Pen(Color.Red, 2);
            g.Clear(bigPictureBox.BackColor);

            visualizer.drawTreeWithoutElem(g, x, y);

            g.DrawEllipse(redPen, visualizer.x[step[0], step[1]] - 5, visualizer.y[step[0], step[1]], 65, 35);

            using (Graphics gr = smallPictureBox.CreateGraphics())
            {
                if (step[3] > step[2])
                {
                    gr.Clear(smallPictureBox.BackColor);
                    gr.DrawString($"{step[2]} < {step[3]}", new Font("Arial", 12), Brushes.Black, new PointF(10, 10));
                }
                else
                {
                    gr.Clear(smallPictureBox.BackColor);
                    gr.DrawString($"{step[2]} >= {step[3]}", new Font("Arial", 12), Brushes.Black, new PointF(10, 10));
                }
            }
        }
    }

    public void ShowStepByStepSearch(int[] step, PictureBox bigPictureBox, PictureBox smallPictureBox)
    {
        using (Graphics g = bigPictureBox.CreateGraphics())
        {
            Pen redPen = new Pen(Color.Red, 2);
            g.Clear(bigPictureBox.BackColor);

            visualizer.drawTree(g);

            g.DrawEllipse(redPen, visualizer.x[step[0], step[1]] - 5, visualizer.y[step[0], step[1]], 65, 35);
            using (Graphics gr = smallPictureBox.CreateGraphics())
            {
                if (step[3] > step[2])
                {
                    gr.Clear(smallPictureBox.BackColor);
                    gr.DrawString($"{step[2]} < {step[3]}", new Font("Arial", 12), Brushes.Black, new PointF(10, 10));
                }
                else
                {
                    gr.Clear(smallPictureBox.BackColor);
                    gr.DrawString($"{step[2]} >= {step[3]}", new Font("Arial", 12), Brushes.Black, new PointF(10, 10));
                }
            }
        }
    }

    public void ShowStepByStepRemove(int[] step, PictureBox bigPictureBox, PictureBox smallPictureBox)
    {
        using (Graphics g = bigPictureBox.CreateGraphics())
        {
            Pen redPen = new Pen(Color.Red, 2);
            g.Clear(bigPictureBox.BackColor);

            visualizer.drawTree(g);

            g.DrawEllipse(redPen, visualizer.x[step[0], step[1]] - 5, visualizer.y[step[0], step[1]], 65, 35);
            using (Graphics gr = smallPictureBox.CreateGraphics())
            {
                if (step[3] > step[2])
                {
                    gr.Clear(smallPictureBox.BackColor);
                    gr.DrawString($"{step[2]} < {step[3]}", new Font("Arial", 12), Brushes.Black, new PointF(10, 10));
                }
                else
                {
                    gr.Clear(smallPictureBox.BackColor);
                    gr.DrawString($"{step[2]} >= {step[3]}", new Font("Arial", 12), Brushes.Black, new PointF(10, 10));
                }
            }
        }
    }

    public void updateStorage(int data)
    {
        Status status = new Status(visualizer.treeArray, operation, data);
        storage.AddStatus(status);
    }

    public void arraytoTree()
    {
        int?[,] array = storage.states[storage.currentIndex].currentTree;

        tree = new BinarySearchTree();
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                if (array[i, j] != null)
                {
                    tree.insert(new Node((int)array[i, j]));
                }
            }
        }
    }
}
