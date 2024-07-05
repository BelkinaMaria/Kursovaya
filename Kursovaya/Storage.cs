using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;

namespace Kursovaya;

/// <summary>
/// Класс-хранилище.
/// </summary>
public class Storage
{
    List<Status> states { get; set; }
    int currentIndex { get; set; }

    public Storage(List<Status> states)
    {
        this.states = states;
        this.currentIndex = 0;
    }

    public void AddStatus(Status state)
    {
        states.Add(state);
    }

    public void Reset()
    {
        currentIndex = 0;
    }

    public Status GetCurrentState()
    {
        if (currentIndex < states.Count)
        {
            return states[currentIndex];
        }
        else
        {
            return null;
        }
    }

    public bool MoveToNextState()
    {
        if (currentIndex < states.Count - 1)
        {
            currentIndex++;
            return true;
        }
        return false;
    }

    public void SaveToFile(string filePath)
    {
        using (FileStream stream = new FileStream(filePath, FileMode.Create))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, states);
        }
    }

    public void LoadFromFile(string filePath)
    {
        using (FileStream stream = new FileStream(filePath, FileMode.Open))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            states = (List<Status>)formatter.Deserialize(stream);
            Reset();
        }
    }
}
