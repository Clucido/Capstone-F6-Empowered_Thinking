using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim_Controller : MonoBehaviour
{
    Transform Target;

    private void Awake(){
        Target = GameObject.Find("Player").transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Target);
    }
}
