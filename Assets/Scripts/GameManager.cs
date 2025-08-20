using UnityEngine;
using System.Collections;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Stats")]
    public float gameSpeed;
    public float score;
    public bool isDead = false;

    [Header("Wind Settings")]
    public float wind;
    public float windChangeInterval = 8f; //how often to change wind
    public PlayerController player;

    [Header("UI")]
    public TMP_Text scoreText;
    public TMP_Text speedText;

    void Start()
    {
        StartCoroutine("ChangeWind");
    }
    void Update()
    {
        if (isDead == false)
        {
            if (player.windDiff <= 5)
                gameSpeed = 20;
            else if (player.windDiff > 5 && player.windDiff < 20)
                gameSpeed = 12;
            else
                gameSpeed = 5;
            score += gameSpeed * Time.deltaTime;

            scoreText.text = Mathf.FloorToInt(score).ToString();
            speedText.text = Mathf.FloorToInt(gameSpeed).ToString();
        }
       if (isDead == true)
            gameSpeed = 0;
    }

    private IEnumerator ChangeWind()
    {
        while (true) // run forever
        {
            // Pick a random wind value
            wind = Random.Range(-45f, 45f);
            print(wind);

            // Wait before changing again
            yield return new WaitForSeconds(windChangeInterval);
        }
    }
}