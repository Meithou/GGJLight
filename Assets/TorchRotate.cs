using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class TorchRotate : MonoBehaviour
{
    private float angleOffset = 165f;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        transform.position=Player.transform.position+new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveToMouse(Vector2 position, float angle)
    {
        transform.position = position;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + angleOffset));
    }
}
