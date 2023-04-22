using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LitJson;

[System.Serializable]
public class Quiz {
    public string question;
    public string options;
    public string rightans;
}

public class JsonController : MonoBehaviour {

    public List<Quiz> quizs = new List<Quiz> (0);

    void Start()
    {
        objToJson(quizs);
    }

    void objToJson(List<Quiz> obj)
    {
        JsonData jsonData = JsonMapper.ToJson(obj);
        File.WriteAllText(Application.dataPath + "/Json/quiz", jsonData.ToString());
    }

    [System.Obsolete]
    void jsonToObj()
    {
        WWW www = new WWW(Application.dataPath + "/Json/quiz");
        JsonData jsonData = JsonMapper.ToObject(www.text);
        for (int i = 0; i < jsonData.Count; i++)
        {
            Debug.Log(jsonData[i]["question"]);
            Debug.Log(jsonData[i]["options"]);
            Debug.Log(jsonData[i]["rightans"]);
        }
    }
}