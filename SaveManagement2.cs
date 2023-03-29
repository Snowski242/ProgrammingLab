using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.Windows.Speech;

public class SaveManagement : MonoBehaviour
{
    public TextMeshProUGUI saveTime;
    public TextMeshProUGUI loadTime;
    string encryptSave;
    string decryptSave;


    public void SaveData()
    {

        Debug.Log("Saved at " + saveTime.text);
        encryptSave = XORCipher(saveTime.text, "super");
        File.WriteAllText(Application.dataPath + "/save.json", encryptSave);

    }

    public void LoadData()
    {
        
        decryptSave = XORCipher(encryptSave, "super");
        loadTime.text = decryptSave;

    }

    public static string XORCipher(string data, string key)
    {
        int dataLen = data.Length;
        int keyLen = key.Length;
        char[] output = new char[dataLen];

        for (int i = 0; i < dataLen; ++i)
        {
            output[i] = (char)(data[i] ^ key[i % keyLen]);
        }

        return new string(output);
    }
}
