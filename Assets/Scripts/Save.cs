using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Save : MonoBehaviour
{
    public void writeText()
    {
        string save_path = Application.dataPath + "/save_file.txt";

        if (!File.Exists(save_path))
        {
            File.WriteAllText(save_path, "Test test\n");
        }

        string data = "John, 450, 4:30\n";

        File.AppendAllText(save_path, data);
    }
}
