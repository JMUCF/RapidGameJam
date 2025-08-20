using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject mapSection;
    private GameManager gm;

    [Header("Movement")]
    public float moveSpeed;
    public float sprintSpeed;

    [Header("Wind Control")]
    public float playerWind = 0f;
    public float windAdjustSpeed = 45f; // how fast wind changes
    public GameObject arrow; // drag in the player arrow 

    public Material Green;
    public Material Yellow;
    public Material Red;

    public float windDiff;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
    }

    void Update()
    {
        //Left right movement
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        //wind control
        float windInput = Input.GetAxis("Wind");
        playerWind += windInput * windAdjustSpeed * Time.deltaTime;
        playerWind = Mathf.Clamp(playerWind, -45f, 45f);

        arrow.transform.localRotation = Quaternion.Euler(0f, playerWind, 0f);

        //change color of the arrow based on how close to the target it is. arrow is made up of children gameobjects cant figure out easy material changing rn so no work
        windDiff = Mathf.Abs(gm.wind - playerWind);
        //if(windDiff < 10 )
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MapTrigger"))
        {
            // Spawn new section exactly after the last one
            Instantiate(mapSection, new Vector3(0, 0, 42), Quaternion.identity); //dont like this way of spawning stuff in but we only have 4 hours
        }
    }
}