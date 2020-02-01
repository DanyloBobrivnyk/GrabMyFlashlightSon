using System;
using UnityEngine;

public class DragableGameObject : MonoBehaviour, IGrabbable {
    [SerializeField]
    private Transform dragPoint;
    private HandController assignedHand;
    public bool releaseBool;


    public void Grab(HandController handController) {
        assignedHand = handController;
        releaseBool = false;
        if(dragPoint != null)
            dragPoint.transform.position = assignedHand.GrabbingTransform.position;
            //assignedHand.isGrabbing = true;
    }

    public void Release() {
        releaseBool = true;
    }


    private void Update() {

        if (assignedHand != null&&!releaseBool) {
            transform.position = assignedHand.GrabbingTransform.position;
        }
        
    }
}