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

    /*List<int[]> steps { get; set; }

    int currentStep;*/
    public Status(int?[,] currentTree, OperationType currentOperation, int data)
    {
        this.currentTree = currentTree;
        this.currentOperation = currentOperation;
        this.data = data;
    }
}
