using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class StatsCounter : MonoBehaviour
{
    SpawnPlayer spawn;
    ExplodePlayer player;
    public TMP_Text scoreText;
    public TMP_Text livesText;
    public GameObject gameOverText;
    public Slider fuelSlider;
    public float fuelSpeed = -1;
    public int score;
    public int lives = 3;
    public float fuel = 100;
    private void Start()
    {
        player = FindObjectOfType<ExplodePlayer>();
        spawn = FindObjectOfType<SpawnPlayer>();
    }
    void Update()
    {
        fuel += Time.deltaTime *fuelSpeed;
        scoreText.text = "" +score;
        livesText.text = "" +lives;
        fuelSlider.value = fuel;
        if (fuel < 0)
        {
            player.ExplodeNow();
        }
        if (!player)
        {
            player = FindObjectOfType<ExplodePlayer>();
        }
    }
    public void AddPoints(int value)
    {
        score += value;
    }
    public void AddFuel()
    {
        fuel += 25;
    }
    public void LoseLife()
    {
        if (lives > 0)
        {
            lives--;
            Debug.Log("LoseLife called");
        }
        else
        {
            lives = 0;
        }
    }
    public void RespawnPlayer()
    {
        if (lives > 0)
        {
            // Find respawn point
            // Instantiate player
            spawn.RespawnPlayer();
            Debug.Log("Respawning Player");
            fuel = 100;
        }
        else
        {
            gameOverText.SetActive(true);
        }
    }
}
