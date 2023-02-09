using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class CenterFlame : MonoBehaviour
{
    bool isPlaying = false;
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isPlaying)
        {
            if (collision.CompareTag("Note2"))
            {
                isPlaying = true;
                Managers.isPlayingGame = true;
            }

        }
    }
       
        
    
}
