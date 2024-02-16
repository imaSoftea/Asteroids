using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Timer
    float timerTillDestruction = 3.0f;

    // Update is called once per frame
    void Update()
    {
        timerTillDestruction -= Time.deltaTime;
        if(timerTillDestruction < 0)
        {
            Destroy(gameObject);
        }
    }
}
