using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthText : MonoBehaviour
{
    public float timeToLive = 0.5f;

    public float floatSpeed = 500;

    public Vector3 floatDirection = new Vector3(0,1,0);

    public TextMeshProUGUI textMesh;
    Color startingColor;
    RectTransform rTransform;

    float timeElapsed = 0.0f;
    
    void Start()
    {
        startingColor = textMesh.color;
        rTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        rTransform.position += floatDirection * floatSpeed * Time.deltaTime;
        textMesh.color = new Color(startingColor.r, startingColor.g, startingColor.b, 1 - (timeElapsed/ timeToLive));
        if(timeElapsed > timeToLive)
        {
            Destroy(gameObject);
        }
    }
}
