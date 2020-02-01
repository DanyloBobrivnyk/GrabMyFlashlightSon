using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashlightMovement : MonoBehaviour
{
    private Color colorRed = Color.red;
    private Vector3 target;
    private float currentTime;

    
    public float waitingTime;
    
    public float pointingDownSpeed;
    public GameObject flashlight;
    public GameObject point;
    public float smoothSpeed;
    public GameObject cube;
    public Transform camera;

    public Vector3 RandomCoord()
    {
        int randomNumber = Random.Range(1, 200);
        if(randomNumber == 1)
        {
            
            return new Vector3(target.x + Random.Range(-5f,5f), target.y + Random.Range(-5f, 5f));        
        }
        else
        {
            return target;
        }
    }
    private bool MouseIsMoving()
    {
        if (Input.GetAxis("Mouse X") < 0 || Input.GetAxis("Mouse X") > 0 || Input.GetAxis("Mouse Y") > 0 || Input.GetAxis("Mouse Y") < 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    void Update()
    {
        camera = Camera.main.GetComponent<Transform>();

        if(MouseIsMoving())
        {
            //Debug.Log("yes");
            target = Camera.main.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition + camera.forward * 8);           
            currentTime = waitingTime;
            
        }         
        if(!MouseIsMoving())
        {
            //Debug.Log("No");
            currentTime -= Time.deltaTime;
            if(currentTime <= waitingTime)
            {
                //Debug.Log("cur time 0s");
                cube.transform.position = new Vector3(cube.transform.position.x, cube.transform.position.y - (Time.deltaTime * pointingDownSpeed), cube.transform.position.z);              
            }
        }
       if(currentTime > 0.99f)
       {
           //Debug.Log("To mouse pos");
           cube.transform.position = Vector3.Lerp(cube.transform.position, target + RandomCoord() , smoothSpeed);
       }
        Debug.DrawLine(camera.position, target, colorRed);
        point.transform.position = new Vector2(target.x, target.y);
        //flashlight.transform.position =
        #region Comment  
        /*camera = Camera.main.GetComponent<Transform>();


        //Debug.Log("Mouse Position: " + Camera.main.GetComponent<Camera>().ScreenToViewportPoint(Input.mousePosition));
        //Debug.Log("Mouse position without camera: " + Input.mousePosition);


        var targetPos = Camera.main.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
        var smoothedPos = Vector3.Lerp(cube.transform.position, targetPos, smoothSpeed * Time.deltaTime);
       
        
       // Debug.DrawLine(camera.position,smoothedPos,colorRed);
       

        

           
        //Debug.Log("T" + target);    


        //target = Camera.main.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 3, Camera.main.nearClipPlane);
        // target = Camera.main.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(target.x, target.y * 0.1f * Time.deltaTime) + camera.forward * 10);

        //target += Vector3.up * 0.25f;
        //target.y += target.y * 0.1f * Time.deltaTime;
        //cube.transform.position += Vector3.up * 0.1f * Time.deltaTime;*/

        #endregion
    }

}
