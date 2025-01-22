using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public class ExamplesInTxt : MonoBehaviour
{
    [SerializeField]private LevelData[] _levelItem;

    private string _fileName = "examplesFile.txt";

    private string _folderName = "Examples";

    private string filePath;
    private void Start()
    {
        RecordExamples();
    }
    private void SaveData(string data)
    {
        string folderPath = Path.Combine(Application.persistentDataPath, _folderName);

        if (!Directory.Exists(folderPath))
        {
            print("Folder does not exist");

            Directory.CreateDirectory(folderPath);
            Debug.Log("Папка создана: " + folderPath);
        }
         filePath = Path.Combine(folderPath, _fileName);

        File.WriteAllText(filePath, data);
    }
    private void RecordExamples()
    {
        string folderPath = Path.Combine(Application.persistentDataPath, _folderName);

        filePath = Path.Combine(folderPath, _fileName);
        int i = 1;
        foreach (LevelData levelItem in _levelItem)
        {
            foreach(ExampleData exampleItem in levelItem.Examples)
            {
                
                string example = exampleItem.Example;
                File.AppendAllText(filePath, i + ") " + example + "\n");
                i++;
            }
            File.AppendAllText(filePath, "\n");
        }
        
    }
}
