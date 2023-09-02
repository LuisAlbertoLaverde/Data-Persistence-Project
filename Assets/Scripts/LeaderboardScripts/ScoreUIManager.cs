using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreUIManager : MonoBehaviour
{
    private ScoreData sd;
    private ScoreManager sm;

    public ScoreData scoreData;
    public ScoreManager scoreManager;

    private void Awake()
    {
        sd = scoreData;
        sm= scoreManager;
    }

    public void ResetScores()
    {
        Debug.Log("resetScores() calling");

        if (sd!=null)
        {
            scoreData.scores.Clear();
            scoreManager.SaveScore();
            Debug.Log("number of scores after clear:" + scoreData.scores.Count);
        }
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }


}
