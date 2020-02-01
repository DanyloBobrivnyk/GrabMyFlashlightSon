using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public List<WireClass> wires;
    [SerializeField]
    private List<Material> materials;
    [SerializeField]
    private List<Transform> startPositions;
    List<WireClass> wireClone;


    //private List<Vector3> startPoints;

    /*
        private void AddToListMaterials(ref List<Material> materials)
        {
            Color green = Color.green;
        }*/
    private void AddToListDestination(ref List<Vector3> destinationPoints)
    {
        Vector3 first = new Vector3(1, 1);
        Vector3 second = new Vector3(2, 2);

        destinationPoints.Add(first);
        destinationPoints.Add(second);
    }
    void Start()
    {
        //for (int k = 0; k < wires.Count; k++)
        //{
        //    int counter = 0;
        //    int random = Random.Range(1, 6);
        //    wires[random].SharedMaterial = 
        //}
        Debug.Log("Before first foreach: " + wires.Count);
        foreach (var wire in wires)
        {
            int randomMat = Random.Range(0, materials.Count-1);
            wire.SharedMaterial = materials[randomMat];
            wire.StartPosition = startPositions[randomMat].position;
            startPositions.RemoveAt(randomMat);
            materials.RemoveAt(randomMat);
        }
        CopyWires(wires, ref wireClone);
        Debug.Log("After first foreach: " + wires.Count);

        for (int i = 0; i < wires.Count; i++)
        {
            int rand = Random.Range(0, wires.Count - 1);
            wires[i].DestinationPoint = wireClone[rand].StartPosition;
        }
        Debug.Log("After Second foreach: " + wires.Count);

        foreach (WireClass wire in wires)
        {
            Debug.Log("My Color is: " + wire.SharedMaterial.color);
            Debug.Log("My start position is: " + wire.StartPosition);
            Debug.Log("My destination point is: " + wire.DestinationPoint);

        }
    }

    private void CopyWires(List<WireClass> wires, ref List<WireClass> clone)
    {
        clone = wires;
    } 
}
