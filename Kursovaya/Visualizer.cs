using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
    
namespace Kursovaya;

/// <summary>
/// Класс-визуализатор.
/// </summary>
public class Visualizer
{

    public void Display()
    {
        //DisplayHelper();
    }

    private void DisplayHelper(Node root)
    {
        if (root != null)
        {
            DisplayHelper(root.left);
            Console.WriteLine(root.data);
            DisplayHelper(root.right);
        }
    }
}
