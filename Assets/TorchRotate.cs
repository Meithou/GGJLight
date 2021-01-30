using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class TorchRotate : MonoBehaviour
{
    private float angleOffset = 85f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LookAtMouse(float angle)
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + angleOffset));
    }
}
