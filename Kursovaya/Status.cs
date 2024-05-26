using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Kursovaya;

/// <summary>
/// Класс-состояние.
/// </summary>
public class Status
{
    /// <summary>
    /// Состояние дерева на данный момент.
    /// </summary>
    Node currentTree { get; set; }

    /// <summary>
    /// Текущая операция.
    /// </summary>
    OperationType currentOperation { get; set; }

    /// <summary>
    /// Число, над которым оперируют.
    /// </summary>
    int data { get; set; }

    public Status(Node currentTree, OperationType currentOperation, int data)
    {
        this.currentTree = currentTree;
        this.currentOperation = currentOperation;
        this.data = data;
    }
}
