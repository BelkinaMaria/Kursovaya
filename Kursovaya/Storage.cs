using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
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
    public List<Status> states { get; set; }
    public int currentIndex { get; set; }

    public Storage()
    {
        currentIndex = 0;
        states = new List<Status>();
    }

    public void AddStatus(Status state)
    {
        states.Add(state);
        currentIndex++;
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
            /*BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, states);*/
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, states[states.Count - 1].currentTree);
            formatter.Serialize(stream, states[states.Count - 1].currentOperation);
            formatter.Serialize(stream, states[states.Count - 1].data);
        }
    }

    public void LoadFromFile(string filePath)
    {
        using (FileStream stream = new FileStream(filePath, FileMode.Open))
        {
            /*BinaryFormatter formatter = new BinaryFormatter();
            states = (List<Status>)formatter.Deserialize(stream);
            Reset();*/
            IFormatter formatter = new BinaryFormatter();
            /*states.Add(new Status();*/
            /*states[0].currentTree*/
            int?[,] newArray = (int?[,])formatter.Deserialize(stream);
            OperationType newOperation = (OperationType)formatter.Deserialize(stream);
            int newValue = (int)formatter.Deserialize(stream);
            states.Add(new Status(newArray, newOperation, newValue));
        }
    }
}
