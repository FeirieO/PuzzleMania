using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class JsonReadWriteSystem : MonoBehaviour
{
    public InputField idInputField;
    public InputField nameInputField;
    public InputField infoInputField;

    public void SaveToJson()
    {
        //QuestionData data = new QuestionData();
        //data.Id = idInputField.text;
        //data.Name = nameInputField.text;
        //data.Information = infoInputField.text;

        //string json = JsonUtility.ToJson(data, true);
        //File.WriteAllText(Application.dataPath + "/QuestionDataFile.json", json);
    }

    public void LoadToJson()
    {
        //string json = File.ReadAllText(Application.dataPath + "/QuestionDataFile.json");
        //QuestionData data = JsonUtility.FromJson<QuestionData>(json);

        //idInputField.text = data.Id;
        //nameInputField.text = data.Name;
        //infoInputField.text = data.Information;
    }
}
