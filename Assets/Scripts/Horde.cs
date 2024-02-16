using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horde : MonoBehaviour
{

    //Determines Horizontal Movement
    public float speed;

    //Determines Forward Movement
    public float jumpDistance;

    //Direction
    bool isGoingLeft = true;

    //Prevents Double Direction Switches
    float switchDirTimer = 1.0f;

    int tickCount = 0;

    //Update is called once per frame
    void FixedUpdate()
    {
        switchDirTimer -= Time.deltaTime;

        if(isGoingLeft)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
    }

    public void FlipDirection()
    {
        if(switchDirTimer <= 0)
        {
            isGoingLeft = !isGoingLeft;
            switchDirTimer = 1.0f;
            tickCount++;
            transform.position += -Vector3.forward * jumpDistance;

            if(tickCount >= 4)
            {
                #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
                #else
                Application.Quit();
                #endif
            }
        }
    }
}
