using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour {

    public static SaveManager saveManager;

    public float playerPositionX;
    public float playerPositionY;
    public float playerPositionZ;
    public int scene;
    
    public bool isLoading = false;

    void Awake()
    {
        if(saveManager == null)
        {
            DontDestroyOnLoad(gameObject);
            saveManager = this;
        }
        else if (saveManager != this)
        {
            Destroy(gameObject);
        }
        
        //print(Application.persistentDataPath);
    }
	// Use this for initialization

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        PlayerData data = new PlayerData();
        data.playerPosX = playerPositionX;
        data.playerPosY = playerPositionY;
        data.playerPosZ = playerPositionZ;

        scene = SceneManager.GetActiveScene().buildIndex;
        data.curScene = scene;

        bf.Serialize(file, data);
        file.Close();
    }
    public void Load()
    {
        isLoading = true;
        if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);

            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            playerPositionX = data.playerPosX;
            playerPositionY = data.playerPosY;
            playerPositionZ = data.playerPosZ;
            scene = data.curScene;

            SceneManager.LoadScene(scene);
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }
    public void Delete()
    {
        if (File.Exists(Application.persistentDataPath + "playerInfo.dat"))
        {
            File.Delete(Application.persistentDataPath + "playerInfo.dat");
        }
    }
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown("n"))
	    {
            print("Getting here");
	        Load();
	    }
	}
}
[Serializable]
class PlayerData
{
    public float playerPosX;
    public float playerPosY;
    public float playerPosZ;
    public int curScene;
}
