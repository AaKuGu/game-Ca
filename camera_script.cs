using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_script : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform ballPosition;
    public Vector3 distance;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = ballPosition.position - distance;
    }
}
