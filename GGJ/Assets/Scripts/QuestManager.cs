using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestManager : MonoBehaviour
{
    public List<WireClass> wires;
    [SerializeField]
    private List<Material> materials;
    [SerializeField]
    private List<Transform> startPositions;
    List<WireClass> wireClone;
    public static int globalCounter;
    [SerializeField]
    private TextMeshProUGUI tekstMesh;
    void Start()
    {
        foreach (var wire in wires)
        {
            //int randomDest = Random.Range(0, materials.Count - 1);
            int randomMat = Random.Range(0, materials.Count - 1);
                wire.SharedMaterial = materials[randomMat];
                wire.StartPosition = startPositions[randomMat].position;
                startPositions.RemoveAt(randomMat);
                materials.RemoveAt(randomMat);
        }
        CopyWires(wires, ref wireClone);


        for (int i = 0; i < wires.Count; i++)
        {
            int rand = Random.Range(0, wires.Count - 1);
            //******Debug.Log($"Rand = {rand}; i = {i}");
            if (rand != i)
            {
                wires[i].DestinationPoint = wireClone[rand].StartPosition;
            }
            else
            {
                Debug.Log("Backward");
                i--;
            }
        }

    }

    private void Update()
    {
       if(globalCounter >= 6)
        {
            tekstMesh.text = "YOU WON !!!";
            Time.timeScale = 0;
        }
    }
    private void CopyWires(List<WireClass> wires, ref List<WireClass> clone)
    {
        clone = wires;
    } 
}
