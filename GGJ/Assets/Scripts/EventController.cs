using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventController : MonoBehaviour,IEvent 
{
    private EventDetecting eventDetecting;
    private FlashlightMovement flashlightMovement;
    private bool activeEvent = false;
    private bool gameOver = false;

    public float oldData;
    public int id;

    public void ChangeMovement() 
    {
        activeEvent = true;
            oldData = flashlightMovement.smoothSpeed;
            flashlightMovement.smoothSpeed = 0.0025f;
            eventDetecting.button.GetComponentInChildren<Text>().text = "Facebook notifications";
            eventDetecting.button.SetActive(true);
/*        
        else if (id == 2)
        {
            oldData = flashlightMovement.pointingDownSpeed;
            flashlightMovement.waitingTime -= 1;
            eventDetecting.button.GetComponentInChildren<Text>().text = "Sleepless";
            eventDetecting.button.SetActive(true);
        }*/
    }

    public void SetToDefault(float oldData,int id)
    {
        activeEvent = false;

            flashlightMovement.smoothSpeed = oldData;
            eventDetecting.button.SetActive(false);
/*        else if(id == 2)
        {
            flashlightMovement.pointingDownSpeed = oldData;
            eventDetecting.button.SetActive(false);
        }*/
    }
    private void Start()
    {
        flashlightMovement = GetComponent<FlashlightMovement>();
        eventDetecting = GetComponent<EventDetecting>();
        if(!activeEvent)
        {
            InvokeRepeating("ChangeMovement", 1, Random.Range(5,14));
        }
    }
}
