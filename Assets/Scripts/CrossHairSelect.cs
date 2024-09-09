using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHairSelect : MonoBehaviour
{

    public float distance = 10;
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, distance))
        {
            if (hit.collider.gameObject.CompareTag("Hid") && !HiddenObject.onObject)
            {
                hit.collider.gameObject.GetComponent<HiddenObject>().CSEnter();
            }
            else if (!hit.collider.gameObject.CompareTag("Hid"))
            {
                HiddenObject.onObject = false;
            }
        }
    }
    
    
}
