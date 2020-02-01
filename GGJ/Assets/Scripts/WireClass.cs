using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireClass : MonoBehaviour
{
    public Material SharedMaterial { get => GetComponent<Renderer>().sharedMaterial; set => GetComponent<Renderer>().sharedMaterial = value; }
    public Vector3 StartPosition { get => GetComponent<Transform>().position; set => GetComponent<Transform>().position = value; }
    public Vector3 DestinationPoint { get; set; }
    
    public Material _mat;
    public Vector3 destinationPoint;
    public Vector3 startPoint;



    //gameObject.GetComponent<MeshRenderer>().sharedMaterial = _mat;
    
    //public WireClass()
    //{

    //}
    //public WireClass (Color color, Vector3 destinationPoint, Vector3 startPoint)
    //{

    //}

    //Renderer rend;
}
