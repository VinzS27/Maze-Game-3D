using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ExitDoor : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {   
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            scoreText.text = "WIN!";
        }
            
    }
}
