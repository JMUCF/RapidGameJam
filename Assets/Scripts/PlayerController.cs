using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float sprintSpeed;

    public GameObject mapSection;

    void Update()
    {
        //Left right movement
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
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