using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class WordDataManager : MonoBehaviour
{
    [System.Serializable]
    class SaveData 
    {
        public List<string> words = new List<string>();
        public List<string> means = new List<string>();
    }

    private int btnSelect;
    private int index;
    private int index_C;
    private int index_W;
    private string word;
    private string json;
    private string path;
    private SaveData saveData;

    public int whichOne;
    public TMP_Text word_Text;
    public TMP_Text mean1_Text;
    public TMP_Text mean2_Text;


    private void Awake() {
       saveData = new SaveData();
    }


    public void SaveWord(string word, string mean) {
        saveData.words.Add(word);
        saveData.means.Add(mean);
    }


    public void WriteToFile() {
        json = JsonUtility.ToJson(saveData);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }


    public void LoadWord() {
        path = Application.persistentDataPath + "/savefile.json";

        if(File.Exists(path)) {
            json = File.ReadAllText(path);
            saveData = JsonUtility.FromJson<SaveData>(json);
        }
    }


    public void WordRandomLoad() {
        index = Random.Range(0, saveData.words.Count);
        word = saveData.words[index];

        word_Text.text = word;

        index_C = index;    // Currect
        index_W = index;    // Wrong

        while (index_W == index_C) {
            index_W = Random.Range(0, saveData.means.Count);
        }
        
        btnSelect = Random.Range(0, 2);

        if (btnSelect == 0) {
            mean1_Text.text = saveData.means[index_C];
            mean2_Text.text = saveData.means[index_W];
            whichOne = 1;

        }
        else {
            mean1_Text.text = saveData.means[index_W];
            mean2_Text.text = saveData.means[index_C];
            whichOne = 2;
        }
    }
}
