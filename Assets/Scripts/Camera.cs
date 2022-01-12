using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Camera : MonoBehaviour
{
    
    public GameObject player;
    private Vector3 offset = new Vector3(0, 7, 7);
    private void Start()
    {
        
    }

    private void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
   
}
