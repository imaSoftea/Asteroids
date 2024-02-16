using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    int count = 3;

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 8)
        {
            Destroy(collision.gameObject);
            count -= 1;
            if(count < 0)
            {
                Destroy(gameObject);
            }
        }
        else if(collision.gameObject.layer == 7)
        {
            Destroy(collision.gameObject);
        }
    }
}
