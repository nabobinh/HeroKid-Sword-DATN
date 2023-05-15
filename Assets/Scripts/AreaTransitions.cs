using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaTransitions : MonoBehaviour
{
    private CameraScript cam;

    public Vector2 newMinPos;
    public Vector2 newMaxPos;
    public Vector3 movePlayer;

    void Start()
    {
        cam = Camera.main.GetComponent<CameraScript>();

    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            cam.minPos = newMinPos;
            cam.maxPos = newMaxPos;
            other.transform.position += movePlayer;
        }
    }
}
