using System;
using System.IO;
using System.Collections;
using UnityEngine;

[Serializable]
public class MyJsonData
{
    public int dropRein;
    public int fireRein;
    public int crystalRein;

    public int dropAmount;
    public int fireAmount;
    public int crystalAmount;

    public bool timeFreeze;
    public bool bigger;
    public bool dash;
}

public class JsonData : MonoBehaviour
{
    public PlayerMove playerMove;
    public Timer timer;

    private MyJsonData myJData = new MyJsonData();
    private DataManager dataM;
    private SkillManager skillManager;

    void Awake()
    {
        dataM = GetComponent<DataManager>();
        skillManager = GetComponent<SkillManager>();

        //DataSaveText(myJData, "Data.json");

        MyJsonData myData = DataLoadText<MyJsonData>("Data.json");

        myJData = myData;

        dataM.itemAmount[0] = myJData.dropAmount;
        dataM.itemAmount[1] = myJData.fireAmount;
        dataM.itemAmount[2] = myJData.crystalAmount;

        dataM.reinLv[0] = myJData.dropRein;
        dataM.reinLv[1] = myJData.fireRein;
        dataM.reinLv[2] = myJData.crystalRein;

        dataM.skillSet[0] = myJData.timeFreeze;
        dataM.skillSet[1] = myJData.bigger;
        dataM.skillSet[2] = myJData.dash;
    }
    void Start()
    {
        SaveJData();
    }

    public void SaveJData()
    {
        myJData.dropAmount = dataM.itemAmount[0];
        myJData.fireAmount = dataM.itemAmount[1];
        myJData.crystalAmount = dataM.itemAmount[2];

        myJData.dropRein = dataM.reinLv[0];
        myJData.fireRein = dataM.reinLv[1];
        myJData.crystalRein = dataM.reinLv[2];

        myJData.timeFreeze = dataM.skillSet[0];
        myJData.bigger = dataM.skillSet[1];
        myJData.dash = dataM.skillSet[2];

        DataSaveText(myJData, "Data.json");
    }

    public void DataSaveText<T>(T data, string _fileName)
    {
        try
        {
            string json = JsonUtility.ToJson(data, true);

            if (json.Equals("{}"))
            {
                Debug.Log("json null");
                return;
            }
            string path = Application.persistentDataPath + "/" + _fileName;
            File.WriteAllText(path, json);

            Debug.Log(json);
            Debug.Log(path);
        }
        catch (FileNotFoundException e)
        {
            Debug.Log("The file was not found:" + e.Message);
        }
        catch (DirectoryNotFoundException e)
        {
            Debug.Log("The directory was not found: " + e.Message);
        }
        catch (IOException e)
        {
            Debug.Log("The file could not be opened:" + e.Message);
        }
    }

    public T DataLoadText<T>(string _fileName)
    {
        try
        {
            string path = Application.persistentDataPath + "/" + _fileName;
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                Debug.Log(json);
                T t = JsonUtility.FromJson<T>(json);
                return t;
            }
        }
        catch (FileNotFoundException e)
        {
            Debug.Log("The file was not found:" + e.Message);
        }
        catch (DirectoryNotFoundException e)
        {
            Debug.Log("The directory was not found: " + e.Message);
        }
        catch (IOException e)
        {
            Debug.Log("The file could not be opened:" + e.Message);
        }
        return default;
    }
}