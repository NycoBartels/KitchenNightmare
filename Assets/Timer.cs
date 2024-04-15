using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{

    private TextMeshProUGUI label;

    [SerializeField] private float totalTime;
    private float elapsedTime;

    private void Start() {
        label = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        UpdateText();
    }

    private void UpdateText() {


        var minutes = Mathf.FloorToInt((totalTime - elapsedTime) / 60f) ;
        var seconds = Mathf.FloorToInt((totalTime - elapsedTime) % 60f);
        label.text = "Time remaining: " + minutes.ToString() + ":" + seconds.ToString();

        if (minutes == 1) {
            label.fontSize = 96;
        }
    }


}
