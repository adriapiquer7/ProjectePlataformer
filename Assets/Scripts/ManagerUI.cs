using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class ManagerUI : MonoBehaviour
{
    public static ManagerUI Instance;
    private int puntuacion = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        ActualizarTexto();
    }

    public void AddPuntos(int points)
    {
        puntuacion += points;
        ActualizarTexto();
    }

    public void UpdateTimer(int segundos)
    {
        timerText.text = "Tiempo: " + segundos;
    }

    private void ActualizarTexto()
    {
        puntuacion++;
        scoreText.text = "Puntos: " + puntuacion;
    }
    
}
