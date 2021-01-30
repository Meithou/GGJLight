using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Torch : MonoBehaviour
{

    private Camera cam;
    private TorchRotate spotlight;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        spotlight = GameObject.Find("Point Light 2D (1)").GetComponent<TorchRotate>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 positionOnScreen = cam.WorldToViewportPoint(spotlight.transform.position);

        //Get the Screen position of the mouse
        Vector2 mouseOnScreen = (Vector2)cam.ScreenToViewportPoint(Input.mousePosition);

        //Get the angle between the points
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
        spotlight.LookAtMouse(angle);
    }

    

    private float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
