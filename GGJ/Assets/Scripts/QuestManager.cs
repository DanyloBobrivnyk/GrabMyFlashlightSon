using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

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
    private bool win = false;
    [SerializeField]
    private GameObject titles;

    private float smoothSpeed = 0.02f;
    [SerializeField]
    private Light LightOn;
    void Awake()
    {
        foreach (var wire in wires)
        {
            int randomDest = Random.Range(0, materials.Count - 1);
            int randomMat = Random.Range(0, materials.Count - 1);
                wire.SharedMaterial = materials[randomMat];
                wire.StartPosition = startPositions[randomDest].position;
                startPositions.RemoveAt(randomDest);
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
                //Debug.Log("Backward");
                i--;
            }
        }

    }

    private void Update()
    {
        
       if(globalCounter == 6)
        {
            tekstMesh.text = "YOU WON !!!"; 
            Time.timeScale = 0;
            globalCounter++;
            SoundManager.instance.PlaySound("Win_pos");
            win = true;
        }
       if(win)
        {
            LightOn.GetComponent<Light>().gameObject.SetActive(true);
            titles.transform.Translate(Vector3.up*smoothSpeed);
        }
    }
    private void CopyWires(List<WireClass> wires, ref List<WireClass> clone)
    {
        clone = wires;
    } 
}
