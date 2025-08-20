using UnityEngine;

public class MapController : MonoBehaviour
{

    private float speed;
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
    }

    void Update()
    {
        speed = gameManager.gameSpeed;
        transform.Translate(Vector3.back * Time.deltaTime * speed);
    }
}
