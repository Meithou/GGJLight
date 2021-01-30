using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UIElements;
using UnityStandardAssets;
public class Torch : MonoBehaviour
{

    private Camera cam;
    private TorchRotate spotlight;
    private PlatformerCharacter2D player;
    public float armLength = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        spotlight = GameObject.Find("Torch").GetComponent<TorchRotate>();
        player = GameObject.Find("CharacterRobotBoy (1)").GetComponent<Platformer2DUserControl>();
        Debug.Log("spotlight START enabled " + spotlight.GetComponent<BoxCollider2D>().enabled);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.holdingTorch)
        {
            spotlight.GetComponent<BoxCollider2D>().enabled = false;
            moveTorch();
        }
        else
        {
            spotlight.GetComponent<BoxCollider2D>().enabled = true;
        }
        Debug.Log("spotlight enabled " + spotlight.GetComponent<BoxCollider2D>().enabled);
    }

    private void moveTorch()
    {
        Vector2 positionOnScreen = cam.WorldToViewportPoint(player.transform.position);

        //Get the Screen position of the mouse
        Vector2 mouseOnScreen = (Vector2)cam.ScreenToViewportPoint(Input.mousePosition);

        //Get position between character and mouse
        Vector2 arm = (mouseOnScreen - positionOnScreen).normalized * armLength;
        Vector2 position = new Vector2(player.transform.position.x, player.transform.position.y) + arm;

        //Get the angle between the character and mouse
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
        spotlight.MoveToMouse(position, angle);
    }

    private float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
