using UnityEngine;

public class ChangeSail : MonoBehaviour
{
    public PlayerController pc;
    public GameObject front;
    public GameObject left;
    public GameObject right;
    private float windAngle;

    // Update is called once per frame
    void Update()
    {
        windAngle = pc.playerWind;
        if(windAngle < -15)
        {
            front.SetActive(false);
            left.SetActive(true);
        }
        else if(windAngle > -15 && windAngle < 15)
        {
            front.SetActive(true); 
            left.SetActive(false);
            right.SetActive(false);
        }
        else if (windAngle > 15)
        {
            front.SetActive(false);
            right.SetActive(true);
        }
    }
}
