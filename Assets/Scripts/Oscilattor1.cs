using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Oscilattor1 : MonoBehaviour
{
    Vector3 startingPosition;
    Vector3 offset;
    [SerializeField] Vector3 movementVector;
    [SerializeField] float period = 7f;
    [SerializeField] [Range(0, 1)] float movementFactor;
    float start;
    
    void Start()
    {
        startingPosition = transform.position;
        
    }

    void Update()
    {

        float cycles = Time.time / period;
        const float tau = Mathf.PI * 2;
        float rawsinwave = Mathf.Sin(cycles * tau);
        movementFactor = (rawsinwave + 1f) / 2f;
        offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;

    }

}
