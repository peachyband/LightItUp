using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Point : MonoBehaviour
{
    private Light2D lightctrl;

    public int lightningOrder = 0;
    public bool isChecked = false;
    public bool CouldBeChecked = false;
    public bool LayingNext = false;
    
    public void SetBeing(bool prop){ CouldBeChecked = prop; }
    public void SetLightningOrder(int order){ lightningOrder = order; }
    public bool GetChecked() { return isChecked; }

    

    private void Start()
    {
        lightctrl = gameObject.GetComponent<Light2D>();
    }

    private void Update()
    {
        if (isChecked) lightctrl.intensity = 1;
        //if (LayingNext) creatingALine();
    }

    

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.transform.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E) && CouldBeChecked)
            {
                isChecked = true;
            }
        }
    }
}
