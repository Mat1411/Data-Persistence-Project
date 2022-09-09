using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{

    public string userName;
    private string input;

    public static MenuUIHandler Instance;
    public InputField inputName;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);


    }

    private void Start()
    {


    }

    private void Update()
    {

    }
    public void StartNew()
    {
        userName = inputName.text;
        SceneManager.LoadScene(1);
    }

    public void NameDeclaration()
    {
        
    }

    class SaveData
    {
        public string name;
    }
    public void SaveName()
    {
        SaveData data = new SaveData();
        data.name = userName;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void Exit()
    {



#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();

#else
        Application.Quit();

#endif

    }



}
