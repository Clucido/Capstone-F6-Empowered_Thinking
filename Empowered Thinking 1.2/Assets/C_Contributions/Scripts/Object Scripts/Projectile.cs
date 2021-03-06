using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update

    public float liveTime = 0f;
    void Start()
    {
        Destroy(gameObject,liveTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
