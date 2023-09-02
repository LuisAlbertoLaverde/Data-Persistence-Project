using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreUI : MonoBehaviour
{
    public RowUI rowUi;
    public ScoreManager scoreManager;
    public Transform rowContainer; // Referencia al contenedor de las filas en la UI

    // Llama a este método para actualizar la UI con los datos de scoreData
    void UpdateUI()
    {
        // Elimina todas las filas existentes en el contenedor
        foreach (Transform child in rowContainer.transform)
        {
            Destroy(child.gameObject);
            Debug.Log("se esta eliminado las filas");
        }

        var scores = scoreManager.GetHighScores().ToArray();
        for (int i = 0; i < scores.Length; i++)
        {
            var row = Instantiate(rowUi, rowContainer).GetComponent<RowUI>();
            row.rankTxt.text = (i + 1).ToString();
            row.nameTxt.text = scores[i].name;
            row.scoreTxt.text = scores[i].score.ToString();
        }
    }

    void Start()
    {
        // Llama a UpdateUI() al inicio para mostrar los puntajes iniciales
        UpdateUI();
    }

    public void ResetScores()
    {
        Debug.Log("reset Score se ha llamado");
        if (scoreManager != null)
        {
            scoreManager.ClearScores(); // Método que deberías crear en ScoreManager para borrar los puntajes
            scoreManager.SaveScore();

            // Llama a UpdateUI() después de borrar los puntajes para actualizar la UI
            UpdateUI();
        }
    }
}
