using TMPro;
using UnityEngine;

public class BestScoreTextUpdater : MonoBehaviour
{
    public ScoreManager scoreManager;

    void Start()
    {
        int highestScore = scoreManager.GetHighestScore();
        // Ahora puedes usar 'highestScore' para actualizar tu TextMeshProUGUI.
    }
}
