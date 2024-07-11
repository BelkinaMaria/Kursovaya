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

    /// <summary>
    /// Конструктор.
    /// </summary>
    public Storage()
    {
        currentIndex = 0;
        states = new List<Status>();
    }

    /// <summary>
    /// Добавление нового статуса.
    /// </summary>
    /// <param name="state">статус</param>
    public void AddStatus(Status state)
    {
        states.Add(state);
        currentIndex++;
    }

    /// <summary>
    /// К следующей стадии.
    /// </summary>
    /// <returns>true - получилось, false - не получилось.</returns>
    public bool MoveToNextState()
    {
        if (currentIndex < states.Count - 1)
        {
            currentIndex++;
            return true;
        }
        return false;
    }

    /// <summary>
    /// К предыдущей стадии.
    /// </summary>
    /// <returns>true - получилось, false - не получилось.</returns>
    public bool MoveToPreviouseState()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
            return true;
        }
        return false;
    }

    /// <summary>
    /// Сохранение в файл.
    /// </summary>
    /// <param name="filePath"></param>
    public void SaveToFile(string filePath)
    {
        using (FileStream stream = new FileStream(filePath, FileMode.Create))
        {
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, states[states.Count - 1].currentTree);
            formatter.Serialize(stream, states[states.Count - 1].currentOperation);
            formatter.Serialize(stream, states[states.Count - 1].data);
        }
    }

    /// <summary>
    /// Загрузка из файла.
    /// </summary>
    /// <param name="filePath"></param>
    public void LoadFromFile(string filePath)
    {
        using (FileStream stream = new FileStream(filePath, FileMode.Open))
        {
            IFormatter formatter = new BinaryFormatter();
            int?[,] newArray = (int?[,])formatter.Deserialize(stream);
            OperationType newOperation = (OperationType)formatter.Deserialize(stream);
            int newValue = (int)formatter.Deserialize(stream);

            states.Add(new Status(newArray, newOperation, newValue));
            currentIndex++;
        }
    }
}
