using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    private ScoreData sd;
    private void Awake()
    {
        var json = PlayerPrefs.GetString("scores", "{}");
        sd = JsonUtility.FromJson<ScoreData>(json);
    }
    public IEnumerable<Score> GetHighScores()
    {
        return sd.scores.OrderByDescending(keySelector: x => x.score);
    }
    public void AddScore(Score score)
    {
        sd.scores.Add(score);
    }
    public void ClearScores()
    {
        sd.scores.Clear();
    }

    private void OnDestroy()
    {
        SaveScore();
    }
    public void SaveScore()
    {
        var json=JsonUtility.ToJson(sd);
        PlayerPrefs.SetString("scores", json);
    }

}