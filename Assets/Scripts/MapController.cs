using UnityEngine;

public class MapController : MonoBehaviour
{

    private float speed;
    private GameManager gameManager;  // Store reference to the script, not the GameObject

    void Start()
    {
        // Find the GameManager script on the object tagged "GM"
        gameManager = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();

        // Now you can safely grab gameSpeed
        speed = gameManager.gameSpeed;
    }

    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed);
    }
}
