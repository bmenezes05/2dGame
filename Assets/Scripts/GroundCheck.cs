using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{    
    public bool isGrounded;
    public bool hittedSpike;

    private void OnTriggerStay2D(Collider2D collider)
    {
        isGrounded = collider.gameObject.tag == "Ground";
        hittedSpike = collider.gameObject.tag == "Spike";        
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        isGrounded = false;
        hittedSpike = false;
    }
}
