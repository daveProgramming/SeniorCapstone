using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;

public class LocalizationManager : MonoBehaviour {

    public static LocalizationManager instance;
    public Dictionary<string, string> localizedText;

    private bool isReady = false;
    private string missingTextString = "Localized text not found";

    public enum LocalizationState { English, Espanol }
    public LocalizationState currentState;
   


    void Awake()
    {
        
        
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != null)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
	void Start () {
	
	}

    public void LoadLocalizedText(string filename)
    {
        
        localizedText = new Dictionary<string, string>();
        string filePath = Path.Combine(Application.streamingAssetsPath, filename);
        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            LocalizationData loadedData = JsonUtility.FromJson<LocalizationData>(dataAsJson);

            for (int i = 0; i < loadedData.items.Length; i++)
            {
                localizedText.Add(loadedData.items[i].key, loadedData.items[i].value);
            }
            Debug.Log("Data Loaded, Dictionary contains:" + localizedText.Count + "entries");

        }
        else
        {
            Debug.Log("Cannot Load File");
        }
        isReady = true;
    }

    public string GetLocalizedValue(string key)
    {
        string result = missingTextString;
        if (localizedText.ContainsKey(key))
        {
            result = localizedText[key];
        }
        return result;
    }
    public bool GetIsReady()
    {
        return isReady;
    }
    public string GetLocalizedData(string key)
    {
        string result = missingTextString;
        return result;

    }

    public void SetSpanishState()
    {
        Debug.Log("SPANISH");
        currentState = LocalizationState.Espanol;
    }

    public void SetEnglishState()
    {
        Debug.Log("ENGLISH");
        currentState = LocalizationState.English;
    }


}
