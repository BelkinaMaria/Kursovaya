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
[Serializable]
public class Status
{
    /// <summary>
    /// Состояние дерева на данный момент.
    /// </summary>
    public int?[,] currentTree { get; set; }

    /// <summary>
    /// Текущая операция.
    /// </summary>
    public OperationType currentOperation { get; set; }

    /// <summary>
    /// Число, над которым оперируют.
    /// </summary>
    public int data { get; set; }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="currentTree"></param>
    /// <param name="currentOperation"></param>
    /// <param name="data"></param>
    public Status(int?[,] currentTree, OperationType currentOperation, int data)
    {
        this.currentTree = currentTree;
        this.currentOperation = currentOperation;
        this.data = data;
    }
}
