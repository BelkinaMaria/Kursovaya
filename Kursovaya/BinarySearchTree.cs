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
    private Node root;

    public void Insert(Node node)
    {
        root = InsertHelper(root, node);
        Status status = new(root, OperationType.Insert, node.data);
    }
    private Node InsertHelper(Node root, Node node)
    {
        int data = node.data;

        if (root == null)
        {
            root = node;
            return root;
        }
        else if (data < root.data)
        {
            root.left = InsertHelper(root.left, node);
        }
        else
        {
            root.right = InsertHelper(root.right, node);
        }
        return root;
    }

    public bool Search(int data)
    {
        Status status = new(root, OperationType.Search, data);
        return SearchHelper(root, data);
    }

    private bool SearchHelper(Node root, int data)
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
            return SearchHelper(root.left, data);
        }
        else
        {
            return SearchHelper(root.right, data);
        }
    }

    public void Remove(int data)
    {
        if (Search(data))
        {
            root = RemoveHelper(root, data);
        }
        else
        {
            Console.WriteLine(data + " could not be found!");
        }

        Status status = new(root, OperationType.Insert, data);
    }

    private Node RemoveHelper(Node root, int data)
    {
        if (root == null)
        {
            return root;
        }
        else if (data < root.data)
        {
            root.left = RemoveHelper(root.left, data);
        }
        else if (data > root.data)
        {
            root.right = RemoveHelper(root.right, data);
        }
        else
        {
            if (root.left == null && root.right == null)
            {
                root = null;
            }
            else if (root.right != null)
            {
                root.data = Successor(root);
                root.right = RemoveHelper(root.right, root.data);
            }
            else
            {
                root.data = Predecessor(root);
                root.left = RemoveHelper(root.left, root.data);
            }
        }
        return root;
    }

    private int Successor(Node root)
    {
        root = root.right;
        while (root.left != null)
        {
            root = root.left;
        }
        return root.data;
    }

    private int Predecessor(Node root)
    {
        root = root.left;
        while (root.right != null)
        {
            root = root.right;
        }
        return root.data;
    }
}