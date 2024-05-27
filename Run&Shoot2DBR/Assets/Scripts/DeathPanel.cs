using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DeathPanel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    void Start()
    {
        WaveSpawner waveSpawner = FindObjectOfType<WaveSpawner>();
        scoreText.text = "Текущая волна " + waveSpawner.currentWaveIndex.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
