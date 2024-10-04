using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Oscilattor : MonoBehaviour
{
    Vector3 startingPosition;
    Vector3 offset;
    [SerializeField] Vector3 movementVector = new Vector3(0, -28, 0);
    float movementFactor;
    [SerializeField] float period = 7f;
    float start;
    
    void Start()
    {
        startingPosition = transform.position;
        
    }

    void Update()
    {

        if (period < Mathf.Epsilon) { return; }
        float cycles = Time.time / period;
        const float tau = Mathf.PI * 2;
        float rawsinwave = Mathf.Sin(cycles * tau);
        movementFactor = (rawsinwave + 1f) / 2f;
        offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;

    }

}
