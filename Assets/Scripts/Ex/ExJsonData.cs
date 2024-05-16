using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class ExJsonData : MonoBehaviour
{
    string filePath;

    // Start is called before the first frame update
    void Start()
    {
        filePath = Application.persistentDataPath + "/PlayerData.json";
        Debug.Log(filePath);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            PlayerData playerData = new PlayerData();
            playerData.playerName = "플레이어 1";
            playerData.playerLevel = 1;
            playerData.items.Add("돌 1");
            playerData.items.Add("바위 1");
            SaveData(playerData);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            PlayerData playerData = new PlayerData();

            playerData = LoadData();

            Debug.Log(playerData.playerName);
            Debug.Log(playerData.playerLevel);
            Debug.Log(playerData.items[0]);
            Debug.Log(playerData.items[1]);
        }
    }
    void SaveData(PlayerData data)
    {
        string jsonData = JsonConvert.SerializeObject(data);
        File.WriteAllText(filePath, jsonData);
    }

    PlayerData LoadData()
    {
        if(File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);

            PlayerData data = JsonConvert.DeserializeObject<PlayerData>(jsonData);
            return data;
        }
        else
        {
            return null;
        }
    }
}
