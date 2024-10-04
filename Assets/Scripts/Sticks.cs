using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Sticks : MonoBehaviour
{
    Vector3 startingposition;
    [SerializeField] Vector3 movementVector = new Vector3(0, 8, 0);
    [SerializeField] float period = 7f;
    float movementFactor;
    float startime;
    [SerializeField] float time = 6f;
    void Start()
    {
        startingposition = transform.position;
        startime = Time.time;
    }

    void Update()
    {
        if (Time.time - startime > time)
        {
            if (period < Mathf.Epsilon) { return; }
            const float tau = Mathf.PI * 2;
            float cycles = Time.time / period;
            float rawsinwave = Mathf.Sin(cycles * tau);
            movementFactor = (rawsinwave + 1f) / 2f;
            Vector3 offset = movementVector * movementFactor;
            transform.position = startingposition + offset;
        }
        
    }
}
