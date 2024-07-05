using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Kursovaya;

/// <summary>
/// Класс-реализатор.
/// </summary>
public class BinarySearchTree
{
    public Node root;
    private int line;
    private int?[,]? treeArray;
    private Node?[,]? treeArrayNode;

    /// <summary>
    /// Вставить элемент.
    /// </summary>
    /// <param name="node"></param>
    public void insert(Node node)
    {
        root = insertHelper(root, node);
    }

    /// <summary>
    /// Рекурсивная функция для вставки.
    /// </summary>
    /// <param name="root"></param>
    /// <param name="node"></param>
    /// <returns></returns>
    private Node insertHelper(Node root, Node node)
    {
        int data = node.data;

        if (root == null)
        {
            root = node;
            return root;
        }
        else if (data < root.data)
        {
            root.left = insertHelper(root.left, node);
        }
        else
        {
            root.right = insertHelper(root.right, node);
        }
        return root;
    }

    /// <summary>
    /// Поиск элемента.
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public bool search(int data)
    {
        return searchHelper(root, data);
    }

    /// <summary>
    /// Рекурсивная функция поиска элемента.
    /// </summary>
    /// <param name="root"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    private bool searchHelper(Node root, int data)
    {
        if (root == null)
        {
            return false;
        }
        else if (root.data == data)
        {
            return true;
        }
        else if (root.data > data)
        {
            return searchHelper(root.left, data);
        }
        else
        {
            return searchHelper(root.right, data);
        }
    }

    /// <summary>
    /// Удаления элемента.
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public bool remove(int data)
    {
        if (search(data))
        {
            root = removeHelper(root, data);
        }
        else
        {
            return false;
        }

        return true;
    }

    /// <summary>
    /// Рекурсивная функция удаления элемента.
    /// </summary>
    /// <param name="root"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    private Node removeHelper(Node root, int data)
    {
        if (root == null)
        {
            return root;
        }
        else if (data < root.data)
        {
            root.left = removeHelper(root.left, data);
        }
        else if (data > root.data)
        {
            root.right = removeHelper(root.right, data);
        }
        else
        {
            if (root.left == null && root.right == null)
            {
                root = null;
            }
            else if (root.right != null)
            {
                root.data = successor(root);
                root.right = removeHelper(root.right, root.data);
            }
            else
            {
                root.data = predecessor(root);
                root.left = removeHelper(root.left, root.data);
            }
        }
        return root;
    }

    private int successor(Node root)
    {
        root = root.right;
        while (root.left != null)
        {
            root = root.left;
        }
        return root.data;
    }

    private int predecessor(Node root)
    {
        root = root.left;
        while (root.right != null)
        {
            root = root.right;
        }
        return root.data;
    }

    /// <summary>
    /// Получение количества вершин.
    /// </summary>
    /// <param name="root">корень</param>
    /// <returns>количество вершин</returns>
    public int getNumNodes(Node root)
    {
        if (root == null)
        {
            return 0;
        }
        else
        {
            return 1 + getNumNodes(root.right) + getNumNodes(root.left);
        }
    }

    /// <summary>
    /// Получение высоты дерева.
    /// </summary>
    /// <param name="root">корень</param>
    /// <returns>высота дерева</returns>
    public int getHeight(Node root)
    {
        if (root == null)
        {
            return 0;
        }
        else
        {
            int leftHeight = getHeight(root.left);
            int rightHeight = getHeight(root.right);

            if (leftHeight > rightHeight)
            {
                return leftHeight + 1;
            }
            else
            {
                return rightHeight + 1;
            }
        }
    }

    /// <summary>
    /// Помещение дерева в массив.
    /// </summary>
    /// <returns>массив дерева в числах</returns>
    public int?[,]? getTreeInIntArray()
    {
        treeArray = new int?[getHeight(root), getNumNodes(root)];
        line = 0;
        getTreeInIntArrayHelper(root, 0);
        return treeArray;
    }

    /// <summary>
    /// Рекурсивная функция помещения дерева в массив.
    /// </summary>
    /// <param name="root"></param>
    /// <param name="lvl"></param>
    private void getTreeInIntArrayHelper(Node root, int lvl)
    {
        if (root == null)
        {
            return;
        }
        getTreeInIntArrayHelper(root.left, lvl + 1);
        treeArray[lvl, line] = root.data;
        line++;
        getTreeInIntArrayHelper(root.right, lvl + 1);
    }

    /// <summary>
    /// Помещение дерева в массив
    /// </summary>
    /// <returns>массив дерева в вершинах</returns>
    public Node?[,]? getTreeInNodeArray()
    {
        treeArrayNode = new Node?[getHeight(root), getNumNodes(root)];
        line = 0;
        getTreeInNodeArrayHelper(root, 0);
        return treeArrayNode;
    }

    /// <summary>
    /// Рекурсивная функция помещения дерева в массив.
    /// </summary>
    /// <param name="root"></param>
    /// <param name="lvl"></param>
    private void getTreeInNodeArrayHelper(Node root, int lvl)
    {
        if (root == null)
        {
            return;
        }
        getTreeInNodeArrayHelper(root.left, lvl + 1);
        treeArrayNode[lvl, line] = root;
        line++;
        getTreeInNodeArrayHelper(root.right, lvl + 1);
    }
}