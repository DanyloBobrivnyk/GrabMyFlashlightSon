using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EventDetecting : MonoBehaviour
{
    private EventController eventController;

    public bool buttonPressed;
    public Image loadingBar;
    public GameObject button; 
    public float timeToGrap ;
    public float startTime;

    private void Awake()
    {
        eventController = GetComponent<EventController>();
    }
    public void Update()
    {
        
        if(buttonPressed)
        {
            var howLongGrapped = Time.time - startTime;
            loadingBar.fillAmount = Mathf.Min(howLongGrapped / timeToGrap, 1.0f);
            if(howLongGrapped >= timeToGrap && buttonPressed)
            {
                Debug.Log("Grabbed!");
                Detected();
            }
        }
    }

    public void Detected()
    {
        eventController.SetToDefault(eventController.oldData,eventController.id);
        //TODO
        buttonPressed = false;
        loadingBar.fillAmount = 0;
    }

    public void OnPointerDown()
    {
        buttonPressed = true;
        startTime = Time.time;
    }
    public void OnPointerUp()
    {
        buttonPressed = false;
        loadingBar.fillAmount = 0;
    }

}

