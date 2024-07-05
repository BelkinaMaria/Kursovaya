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
    ///Ширина окна.
    /// </summary>
    private int? _pictureWidth;

    ///<summary>
    ///Высота окна.
    /// </summary>
    private int? _pictureHeight;

    public int?[,]? treeArray;
    public Node?[,]? treeArrayNode;
    public int[,] x;
    public int[,] y;
    private PointF[,] points;

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <param name="tree"></param>
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

    /// <summary>
    /// Отрисовка дерева.
    /// </summary>
    /// <param name="g"></param>
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

    /// <summary>
    /// Отрисовка дерева без элемента x, y (для пошаговой вставки).
    /// </summary>
    /// <param name="g"></param>
    /// <param name="x"></param>
    /// <param name="y"></param>
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
    }

    /// <summary>
    /// Отрисовка линий для дерева.
    /// </summary>
    /// <param name="g"></param>
    private void drawLines(Graphics g)
    {
        Pen blackPen = new(Color.Black, 3);

        for (int i = 0; i < treeArray.GetLength(0) - 1; i++)
        {
            for (int j = 0; j < treeArray.GetLength(1) - 1; j++)
            {
                if (treeArray[i, j] != null && treeArrayNode[i, j].right != null)
                {
                    int k = j/*nextNumRight(i + 1, j)*/;
                    while (treeArray[i + 1, k] != treeArrayNode[i, j].right.data)
                    {
                        k++;
                    }
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
                if (treeArray[i, j] != null && treeArrayNode[i, j].left != null)
                {
                    int k = j;
                    while (treeArray[i + 1, k] != treeArrayNode[i, j].left.data)
                    {
                        k--;
                    }
                    Point point1 = new Point(x[i, j] + 25, y[i, j] + 30);
                    Point point2 = new Point(x[i + 1, k] + 25, y[i + 1, k]);
                    g.DrawLine(blackPen, point1, point2);
                }
            }
        }
    }

    /// <summary>
    /// Отрисовка линий для дерева без одного элемента.
    /// </summary>
    /// <param name="g"></param>
    /// <param name="newTreeArray"></param>
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

    /// <summary>
    /// Поиск следующего элемнета дерева.
    /// </summary>
    /// <param name="line"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    public int nextNumRight(int line, int index) 
    {
        for (int i = index; i < treeArray.GetLength(1); i++)
        {
            if (treeArray[line, i] != null) return i;
        }
        return -1;
    }

    /// <summary>
    /// Поиск предыдущего элемента дерева.
    /// </summary>
    /// <param name="line"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    public int nextNumLeft(int line, int index)
    {
        for (int i = index; i >= 0; i--)
        {
            if (treeArray[line, i] != null) return i;
        }
        return -1;
    }

    /// <summary>
    /// Поиск добавленого элемента.
    /// </summary>
    /// <param name="oldTreeArray"></param>
    /// <returns></returns>
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

    /// <summary>
    /// Значение элемента.
    /// </summary>
    /// <param name="row"></param>
    /// <param name="array"></param>
    /// <returns></returns>
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
