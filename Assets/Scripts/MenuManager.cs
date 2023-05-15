using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private AudioSource _source;
    public void QuitGame()
    {
        _source.Play();
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
