using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;
        public bool holding = false;

        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }


        private void Update()
        {
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }
        }


        private void FixedUpdate()
        {
            // Read the inputs.
            bool crouch = Input.GetKey(KeyCode.LeftControl);
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            // Pass all parameters to the character control script.
            m_Character.Move(h, crouch, m_Jump);
            m_Jump = false;
            if (!Input.GetButton("Interact")){
                Destroy(this.GetComponent<FixedJoint2D>());
                this.holding=false;
            }
        }

        private void OnTriggerStay2D ( Collider2D touching ){
            if((this.gameObject.tag.Contains("Player")) && (touching.gameObject.tag.Contains("drag"))){
                Debug.Log(touching.gameObject.name+ "Triggered");
                if (Input.GetButton("Interact") && (!this.holding)) {
                    Debug.Log("Interact");
                    this.holding=true;
                    this.gameObject.AddComponent<FixedJoint2D>();
                    this.GetComponent<FixedJoint2D>().connectedBody = touching.gameObject.transform.parent.gameObject.GetComponent<Rigidbody2D>();
                }
            }
        }
    }
}
