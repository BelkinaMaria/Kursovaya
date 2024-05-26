using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya;

/// <summary>
/// Класс-параметр.
/// </summary>
public class Node
{
    /// <summary>
    /// Число.
    /// </summary>
    public int data;

    /// <summary>
    /// Ветвь слева.
    /// </summary>
    public Node left;

    /// <summary>
    /// Ветвь справа.
    /// </summary>
    public Node right;

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="data"></param>
    public Node(int data)
    {
        this.data = data;
    }
}
