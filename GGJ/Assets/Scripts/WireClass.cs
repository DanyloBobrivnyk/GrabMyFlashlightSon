using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WireClass : MonoBehaviour
{
    public Material SharedMaterial { get => GetComponent<Renderer>().sharedMaterial; set => GetComponent<Renderer>().sharedMaterial = value; }
    public Vector3 StartPosition { get => GetComponent<Transform>().position; set => GetComponent<Transform>().position = value; }
    public Vector3 DestinationPoint { get; set; }
    [SerializeField]
    private TextMeshProUGUI textMesh;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.position == DestinationPoint)
        {
            QuestManager.globalCounter++;
            this.gameObject.GetComponent<DragableGameObject>().enabled = false;
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        else if(other.transform.position != DestinationPoint && other.transform.position != StartPosition)
        {
            Time.timeScale = 0;
            textMesh.text = "You lose !";
        }
    }

}
