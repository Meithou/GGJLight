using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UIElements;
using UnityStandardAssets._2D;

public class Torch : MonoBehaviour
{

    private Camera cam;
    private TorchRotate spotlight;
    private PlatformerCharacter2D player;
    private float armLength = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        spotlight = GameObject.Find("Point Light 2D (1)").GetComponent<TorchRotate>();
        player = GameObject.Find("CharacterRobotBoy (1)").GetComponent<PlatformerCharacter2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveTorch();
    }

    private void moveTorch()
    {
        Vector2 positionOnScreen = cam.WorldToViewportPoint(player.transform.position);

        //Get the Screen position of the mouse
        Vector2 mouseOnScreen = (Vector2)cam.ScreenToViewportPoint(Input.mousePosition);

        //Get position between character and mouse
        Vector2 arm = (mouseOnScreen - positionOnScreen).normalized * armLength;
        Debug.Log("arm x " + arm.x + " ,arm y " + arm.y);
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
