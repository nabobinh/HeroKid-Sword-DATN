using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickS : MonoBehaviour
{
    
    [SerializeField] private AudioSource _source;

    public void playsoundclick()
    {
        _source.Play();
    }
}
