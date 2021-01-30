using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UIElements;
using UnityStandardAssets._2D;

public class Torch : MonoBehaviour
{

    public Camera cam;
    public TorchRotate spotlight;
    public Platformer2DUserControl player;
    public float armLength = 0.6f;
    private float futureAngle;
    private Vector2 futurePosition;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player.holdingTorch)
        {
            
        }

    }
    void FixedUpdate(){
        if (player.holdingTorch)
        {
            StartCoroutine(MoveTorch());
            spotlight.GetComponent<BoxCollider2D>().enabled = false;
            
            spotlight.MoveToMouse(futurePosition, futureAngle);
        }
                else
        {
            spotlight.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
     IEnumerator MoveTorch()
    {
        Vector2 positionOnScreen = cam.WorldToViewportPoint(player.transform.position);

        //Get the Screen position of the mouse
        Vector2 mouseOnScreen = (Vector2)cam.ScreenToViewportPoint(Input.mousePosition);

        //Get position between character and mouse
        Vector2 arm = (mouseOnScreen - positionOnScreen).normalized * armLength;
        futurePosition = new Vector2(player.transform.position.x, player.transform.position.y) + arm;
        //Get the angle between the character and mouse
         futureAngle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
        spotlight.MoveToMouse(futurePosition, futureAngle);
         yield return null;
    }

    private float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
