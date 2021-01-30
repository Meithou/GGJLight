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
 IEnumerator EnablePlatTimed(float time,Collider2D other)
 {
     yield return new WaitForSeconds(time);
 
     // Code to execute after the delay
    EnablePlatform(other);
 }
 IEnumerator DisablePlatTimed(float time,Collider2D other)
 {
     yield return new WaitForSeconds(time);
 
     // Code to execute after the delay
     DisablePlatform(other);
 }
    void OnTriggerStay2D(Collider2D other){
        
        if(other.gameObject.CompareTag("DeadByLight")){
            //Color target = other.gameObject.GetComponent<SpriteRenderer>().color;
        
            //other.gameObject.GetComponent<SpriteRenderer>().color = new Color (target.r,target.g,target.b,0.20f);
           // other.gameObject.GetComponent<ShadowCaster2D>().castsShadows = false;
            
            //this.GetComponent<BoxCollider2D>().enabled=false;
            DisablePlatform(other);
        }
        if(other.gameObject.CompareTag("AliveByLight")){
            //Color target = other.gameObject.GetComponent<SpriteRenderer>().color;
        
            //other.gameObject.GetComponent<SpriteRenderer>().color = new Color (target.r,target.g,target.b,0.20f);
           // other.gameObject.GetComponent<ShadowCaster2D>().castsShadows = false;
            
            //this.GetComponent<BoxCollider2D>().enabled=false;
            EnablePlatform(other);
        }

    }
    void OnTriggerExit2D(Collider2D other){
        
        if(other.gameObject.CompareTag("DeadByLight")){
            //Color target = other.gameObject.GetComponent<SpriteRenderer>().color;
            //target.a = 1f;
            //other.gameObject.GetComponent<SpriteRenderer>().color = target;
            StartCoroutine(EnablePlatTimed(0.4f,other));
        }
                if(other.gameObject.CompareTag("AliveByLight")){
            //Color target = other.gameObject.GetComponent<SpriteRenderer>().color;
        
            //other.gameObject.GetComponent<SpriteRenderer>().color = new Color (target.r,target.g,target.b,0.20f);
           // other.gameObject.GetComponent<ShadowCaster2D>().castsShadows = false;
            
            //this.GetComponent<BoxCollider2D>().enabled=false;
            DisablePlatform(other);
        }

    
    }
     private void DisablePlatform(Collider2D platform){
        platform.gameObject.GetComponent<PlatformEffector2D>().surfaceArc=0;
    }
    private void EnablePlatform(Collider2D platform){
        platform.gameObject.GetComponent<PlatformEffector2D>().surfaceArc=180;;
            
    }
}
