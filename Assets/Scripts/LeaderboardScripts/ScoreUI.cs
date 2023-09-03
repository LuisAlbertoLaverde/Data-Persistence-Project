using System.Linq;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public RowUI rowUi;
    public ScoreManager scoreManager;
    public Transform rowContainer; // Referencia al contenedor de las filas en la UI

    void Start()
    {
        // Llama a UpdateUI() al inicio para mostrar los puntajes iniciales
        UpdateUI();
    }
    // Llama a este método para actualizar la UI con los datos de scoreData
    void UpdateUI()
    {
        var scores = scoreManager.GetHighScores().ToArray();
        for (int i = 0; i < scores.Length; i++)
        {
            var row = Instantiate(rowUi, rowContainer).GetComponent<RowUI>();
            row.rankTxt.text = (i + 1).ToString();
            row.nameTxt.text = scores[i].name;
            row.scoreTxt.text = scores[i].score.ToString();
        }
    }

    void ClearUI()
    {
        // Elimina todas las filas existentes en el contenedor
        foreach (Transform child in rowContainer.transform)
        {
            Destroy(child.gameObject);
            Debug.Log("se esta eliminado las filas");
        }
    }

    public void ResetScores()
    {
        Debug.Log("reset Score se ha llamado");
        if (scoreManager != null)
        {
            //Limpia la UI
            ClearUI();
            //Borra los puntajes y guarda los cambios
            scoreManager.ClearScores(); // Método que deberías crear en ScoreManager para borrar los puntajes
            scoreManager.SaveScore();
            // Actualiza la UI despues de borrar los puntajes para actualizar
            UpdateUI();
        }
    }
}
