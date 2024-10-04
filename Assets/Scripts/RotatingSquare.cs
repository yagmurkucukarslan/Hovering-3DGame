using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingSquare : MonoBehaviour
{
    [SerializeField] float rotationX = 0f;
    [SerializeField] float rotationY = 1f;
    [SerializeField] float rotationZ = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationX,rotationY,rotationZ);    
    }
}
