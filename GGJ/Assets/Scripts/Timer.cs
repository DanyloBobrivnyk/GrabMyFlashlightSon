using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private float currentTime;
    private float timeSpended;

    [SerializeField] private TextMeshProUGUI _timerText;
    private void Start()
    {
        
    }
    private void Update()
    {
        timeSpended += Time.deltaTime;
        _timerText.text = timeSpended.ToString("F2");
/*        if(timeSpended%60 == 0)TODO
        {
            _timerText.text = (timeSpended /= 60).ToString();
        }*/ 
    }
}
