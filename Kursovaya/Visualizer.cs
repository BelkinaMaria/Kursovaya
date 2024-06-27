using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Drawing;
    
namespace Kursovaya;

/// <summary>
/// Класс-визуализатор.
/// </summary>
public class Visualizer
{
    ///<summary>
    ///Ширина окна
    /// </summary>
    private int? _pictureWidth;

    ///<summary>
    ///Высота окна
    /// </summary>
    private int? _pictureHeight;

    public int?[,]? treeArray;
    public Node?[,]? treeArrayNode;
    public int[,] x;
    public int[,] y;
    private PointF[,] points;


    public Visualizer(int width, int height, BinarySearchTree tree)
    {
        _pictureWidth = width;
        _pictureHeight = height;
        treeArray = tree.getTreeInIntArray();
        treeArrayNode = tree.getTreeInNodeArray();

        int horisontalStep = 60;
        int verticalStep = 40;
        points = new PointF[treeArray.GetLength(0), treeArray.GetLength(1)];
        x = new int[treeArray.GetLength(0), treeArray.GetLength(1)];
        y = new int[treeArray.GetLength(0), treeArray.GetLength(1)];

        for (int i = 0; i < treeArray.GetLength(0); i++)
        {
            for (int j = 0; j < treeArray.GetLength(1); j++)
            {
                if (treeArray[i, j] != null)
                {
                    int addStep = 0;
                    if (treeArray[i, j] < 10)
                    {
                        addStep = 15;
                    }
                    else if (treeArray[i, j] < 100)
                    {
                        addStep = 9;
                    }
                    if (j <= treeArray.GetLength(1))
                    {
                        if (i <= treeArray.GetLength(0))
                        {
                            points[i, j] = new PointF((float)(0.1 * _pictureWidth + _pictureWidth * 0.8 / 2 - (treeArray.GetLength(1) / 2 - j) * horisontalStep + addStep),
                                (float)(0.1 * _pictureHeight + _pictureHeight * 0.8 / 2 - (treeArray.GetLength(0) / 2 - i) * verticalStep));
                            x[i, j] = (int)(0.1 * _pictureWidth + _pictureWidth * 0.8 / 2 - (treeArray.GetLength(1) / 2 - j) * horisontalStep);
                            y[i, j] = (int)(0.1 * _pictureHeight + _pictureHeight * 0.8 / 2 - (treeArray.GetLength(0) / 2 - i) * verticalStep);
                        }
                        else
                        {
                            points[i, j] = new PointF((float)(0.1 * _pictureWidth + _pictureWidth * 0.8 / 2 - (treeArray.GetLength(1) / 2 - j) * horisontalStep + addStep),
                                (float)(0.1 * _pictureHeight + _pictureHeight * 0.8 / 2 + i * verticalStep));
                            x[i, j] = (int)(0.1 * _pictureWidth + _pictureWidth * 0.8 / 2 - (treeArray.GetLength(1) / 2 - j) * horisontalStep);
                            y[i, j] = (int)(0.1 * _pictureHeight + _pictureHeight * 0.8 / 2 + i * verticalStep);
                        }
                    }
                    else
                    {
                        if (i <= treeArray.GetLength(0))
                        {
                            points[i, j] = new PointF((float)(0.1 * _pictureWidth + _pictureWidth * 0.8 / 2 + j * horisontalStep + addStep),
                                (float)(0.1 * _pictureHeight + _pictureHeight * 0.8 / 2 - (treeArray.GetLength(0) / 2 - i) * verticalStep));
                            x[i, j] = (int)(0.1 * _pictureWidth + _pictureWidth * 0.8 / 2 + j * horisontalStep);
                            y[i, j] = (int)(0.1 * _pictureHeight + _pictureHeight * 0.8 / 2 - (treeArray.GetLength(0) / 2 - i) * verticalStep);
                        }
                        else
                        {
                            points[i, j] = new PointF((float)(0.1 * _pictureWidth + _pictureWidth * 0.8 / 2 + j * horisontalStep + addStep),
                                (float)(0.1 * _pictureHeight + _pictureHeight * 0.8 / 2 + i * verticalStep));
                            x[i, j] = (int)(0.1 * _pictureWidth + _pictureWidth * 0.8 / 2 + j * horisontalStep);
                            y[i, j] = (int)(0.1 * _pictureHeight + _pictureHeight * 0.8 / 2 + i * verticalStep);
                        }
                    }
                }
            }
        }

    }

    public void drawTree(Graphics g)
    {
        if (_pictureHeight == null || _pictureWidth == null || treeArray == null) return;
        Font font = new Font("Comic Sans MC", 10);
        Brush brush = new SolidBrush(Color.Black);

        for (int i = 0; i < treeArray.GetLength(0); i++)
        {
            for (int j = 0; j < treeArray.GetLength(1); j++)
            {
                if (treeArray[i, j] != null)
                {
                    g.DrawString(treeArray[i, j].ToString(), font, brush, points[i, j]);
                }
            }
        }

        drawLines(g);
    }

    public void drawTreeWithoutElem(Graphics g, int x, int y)
    {
        int?[,]? newTreeArray = (int?[,]?)treeArray.Clone();
        newTreeArray[x, y] = null;

        if (_pictureHeight == null || _pictureWidth == null || treeArray == null) return;
        Font font = new Font("Comic Sans MC", 10);
        Brush brush = new SolidBrush(Color.Black);

        for (int i = 0; i < treeArray.GetLength(0); i++)
        {
            for (int j = 0; j < treeArray.GetLength(1); j++)
            {
                if (newTreeArray[i, j] != null)
                {
                    g.DrawString(treeArray[i, j].ToString(), font, brush, points[i, j]);
                }
            }
        }

        drawLinesWithoutElem(g, newTreeArray);
        //drawLines(g);
    }

    private void drawLines(Graphics g)
    {
        Pen blackPen = new(Color.Black, 3);

        for (int i = 0; i < treeArray.GetLength(0) - 1; i++)
        {
            for (int j = 0; j < treeArray.GetLength(1) - 1; j++)
            {
                if (treeArray[i, j] != null && treeArrayNode[i, j].right != null)
                {
                    /*int k = 0;
                    while (treeArray[i + 1, k] != treeArrayNode[i, j].right.data)
                    {
                        k++;
                    }*/

                    int k = nextNumRight(i + 1, j);

                    Point point1 = new Point(x[i, j] + 25, y[i, j] + 30);
                    Point point2 = new Point(x[i + 1, k] + 25, y[i + 1, k]);
                    g.DrawLine(blackPen, point1, point2);
                }
            }
        }

        for (int i = 0; i < treeArray.GetLength(0) - 1; i++)
        {
            for (int j = 1; j < treeArray.GetLength(1); j++)
            {
                if (treeArray[i, j] != null/* && treeArrayNode[i, j].left != null*/)
                {
                    /*int k = 0;
                    while (treeArray[i + 1, k] != treeArrayNode[i, j].left.data)
                    {
                        k++;
                    }*/
                    int k = nextNumLeft(i + 1, j);
                    Point point1 = new Point(x[i, j] + 25, y[i, j] + 30);
                    Point point2 = new Point(x[i + 1, k] + 25, y[i + 1, k]);
                    g.DrawLine(blackPen, point1, point2);
                }
            }
        }
    }

    private void drawLinesWithoutElem(Graphics g, int?[,]? newTreeArray)
    {
        Pen blackPen = new(Color.Black, 3);

        for (int i = 0; i < treeArray.GetLength(0) - 1; i++)
        {
            for (int j = 0; j < treeArray.GetLength(1) - 1; j++)
            {
                if (newTreeArray[i, j] != null && treeArrayNode[i, j].right != null)
                {
                    int k = 0;
                    while (treeArray[i + 1, k] != treeArrayNode[i, j].right.data)
                    {
                        k++;
                    }
                    if (newTreeArray[i + 1, k] != null)
                    {
                        Point point1 = new Point(x[i, j] + 25, y[i, j] + 30);
                        Point point2 = new Point(x[i + 1, k] + 25, y[i + 1, k]);
                        g.DrawLine(blackPen, point1, point2);
                    }
                    
                }
            }
        }

        for (int i = 0; i < treeArray.GetLength(0) - 1; i++)
        {
            for (int j = 1; j < treeArray.GetLength(1); j++)
            {
                if (newTreeArray[i, j] != null && treeArrayNode[i, j].left != null)
                {
                    int k = 0;
                    while (treeArray[i + 1, k] != treeArrayNode[i, j].left.data)
                    {
                        k++;
                    }
                    if (newTreeArray[i + 1, k] != null)
                    {
                        Point point1 = new Point(x[i, j] + 25, y[i, j] + 30);
                        Point point2 = new Point(x[i + 1, k] + 25, y[i + 1, k]);
                        g.DrawLine(blackPen, point1, point2);
                    }
                    
                }
            }
        }
    }



    public int nextNumRight(int line, int index) 
    {
        //if ((line < 0) || (line >= treeArray.GetLength(1)))
        for (int i = index; i < treeArray.GetLength(1); i++)
        {
            if (treeArray[line, i] != null) return i;
        }
        return -1;
    }

    public int nextNumLeft(int line, int index)
    {
        for (int i = index; i >= 0; i--)
        {
            if (treeArray[line, i] != null) return i;
        }
        return -1;
    }

    public int[] newElemXY(int?[,] oldTreeArray)
    {
        int[] xy = new int[2];
        int j;
        for (j = 0; j < oldTreeArray.GetLength(1); j++)
        {
            if (oldTreeArray[findData(j, oldTreeArray), j] != treeArray[findData(j, treeArray), j])
            {
                xy[0] = findData(j, treeArray);
                xy[1] = j;
                return xy;
            }
        }
        xy[0] = findData(j, treeArray);
        xy[1] = j;
        return xy;
    }

    /*public int[] removedElemXY(int?[,] oldTreeArray)
    {
        int[] xy = new int[2];
        int j;
        for (j = 0; j < treeArray.GetLength(1); j++)
        {
            if (oldTreeArray[findData(j, oldTreeArray), j] != treeArray[findData(j, treeArray), j])
            {
                xy[0] = findData(j, treeArray);
                xy[1] = j;
                return xy;
            }
        }
        xy[0] = findData(j, );
        xy[1] = j;
        return xy;
    }*/

    private int findData(int row, int?[,] array)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            if (array[i, row] != null) 
                return i;
        }
        return -1;
    }

}
