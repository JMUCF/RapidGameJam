using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float gameSpeed;
    public float score;

    [Header("UI")]
    public TMP_Text scoreText;

    // Update is called once per frame
    void Update()
    {
        score += gameSpeed * Time.deltaTime;

        scoreText.text = Mathf.FloorToInt(score).ToString();
    }
}