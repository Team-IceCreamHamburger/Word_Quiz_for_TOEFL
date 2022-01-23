using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GamaManager : MonoBehaviour
{
    public int progress = 0;   
    public int score = 0;

    private TMP_Text scoreText;
    private TMP_Text progressText;
    private TMP_Text YNText;
    private WordDataManager wordDataManager;


    void Awake() {
        scoreText = GameObject.Find("Score Text").GetComponent<TMP_Text>();
        progressText = GameObject.Find("Progress Text").GetComponent<TMP_Text>();
        YNText = GameObject.Find("YN Text").GetComponent<TMP_Text>();
        wordDataManager = gameObject.GetComponent<WordDataManager>();
    }


    void Start() {
        scoreText.text = "SCORE: 0";
        progressText.text = "0%";
        YNText.text = "START!";
        Debug.Log(Application.persistentDataPath);
        wordDataManager.LoadWord();
        wordDataManager.WordRandomLoad();
    }


    public void ScoreUpdate(int clicked) {
        if (clicked == wordDataManager.whichOne) {
            score += 1;
            YNText.text = "Currect";
        }
        else {
            YNText.text = "Wrong";
        }
        scoreText.text = "SCORE: " + score;
        wordDataManager.WordRandomLoad();
    }
}
