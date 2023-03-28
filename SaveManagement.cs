using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class SaveManagement : MonoBehaviour
{
    public TextMeshProUGUI saveTime;
    public TextMeshProUGUI loadTime;

    public void SaveData()
    {

        Debug.Log("Saved at " + saveTime.text);
        File.WriteAllText(Application.dataPath + "/save.json", saveTime.text);
    }

    public void LoadData()
    {
       loadTime.text = File.ReadAllText(Application.dataPath + "/save.json");
    }
}
