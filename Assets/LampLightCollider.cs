using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
public class LampLightCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        
        if(other.gameObject.tag.Contains("DeadByLight")){
            Debug.Log("OnTrigger2DSTAY");
            //Color target = other.gameObject.GetComponent<SpriteRenderer>().color;
            //other.gameObject.GetComponent<SpriteRenderer>().color = new Color (target.r,target.g,target.b,0.20f);
            other.gameObject.GetComponent<BoxCollider2D>().isTrigger=true;
        }
        if(other.gameObject.tag.Contains("AliveByLight")){
            //Color target = other.gameObject.GetComponent<SpriteRenderer>().color;
            //other.gameObject.GetComponent<SpriteRenderer>().color = new Color (target.r,target.g,target.b,0.20f);
            other.gameObject.GetComponent<BoxCollider2D>().isTrigger=false;
        }

    }
    void OnTriggerExit2D(Collider2D other){
        
        if(other.gameObject.tag.Contains("DeadByLight")){
            
            Debug.Log("OnTriggerEXIT");
            //Color target = other.gameObject.GetComponent<SpriteRenderer>().color;
            //target.a = 1f;
            //other.gameObject.GetComponent<SpriteRenderer>().color = target;
            other.gameObject.GetComponent<BoxCollider2D>().isTrigger=false;
        }
        if(other.gameObject.tag.Contains("AliveByLight")){
            //Color target = other.gameObject.GetComponent<SpriteRenderer>().color;
            //other.gameObject.GetComponent<SpriteRenderer>().color = new Color (target.r,target.g,target.b,0.20f);
            other.gameObject.GetComponent<BoxCollider2D>().isTrigger=true;
        }
    }
}
