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

    public void insert(Node node)
    {
        root = insertHelper(root, node);
        Status status = new(root, OperationType.Insert, node.data);
    }
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



    public bool search(int data)
    {
        Status status = new(root, OperationType.Search, data);
        return searchHelper(root, data);
    }

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

        Status status = new(root, OperationType.Remove, data);
        return true;
    }

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

    public int?[,]? getTreeInIntArray()
    {
        treeArray = new int?[getHeight(root), getNumNodes(root)];
        line = 0;
        getTreeInIntArrayHelper(root, 0);
        return treeArray;
    }

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

    public Node?[,]? getTreeInNodeArray()
    {
        treeArrayNode = new Node?[getHeight(root), getNumNodes(root)];
        line = 0;
        getTreeInNodeArrayHelper(root, 0);
        return treeArrayNode;
    }

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