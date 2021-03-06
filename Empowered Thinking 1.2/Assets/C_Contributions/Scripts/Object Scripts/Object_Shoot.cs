using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Shoot : MonoBehaviour
{
    // Start is called before the first frame update

    public float moveforce = 0f;
    private Rigidbody rigidbody;
    public GameObject projectile;
    public Transform gun;
    public float fireRate = 0f;
    public float projectileForce = 0f;

    public float moveforce2 = 0f;
    public GameObject projectile2;
    public Transform gun2;
    public float fireRate2 = 0f;
    public float projectileForce2 = 0f;

    private float fireRateTimeStamp = 0f;
    private int weapon=1;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Alpha1)){
            weapon=1;
            Debug.Log("weapon 1");
        }
        if(Input.GetKey(KeyCode.Alpha2)){
            weapon=2;
            Debug.Log("weapon 2");
        }

        if(weapon==1){
            shoot(moveforce,projectile,fireRate,projectileForce);
        }
        if(weapon==2){
            shoot(moveforce2,projectile2,fireRate2,projectileForce2);
        }

    }

    void shoot(float mf,GameObject p, float fr, float pf){
        float Horizontal = Input.GetAxisRaw("Horizontal")*mf;
        float Vertical = Input.GetAxisRaw("Vertical")*mf;
        rigidbody.velocity = new Vector3(Horizontal,Vertical,0);

        if(Input.GetKey(KeyCode.Mouse0)){
            if(Time.time > fireRateTimeStamp){
                GameObject go = (GameObject)Instantiate(p,gun.position, gun.rotation);
                go.GetComponent<Rigidbody>().AddForce(gun.forward * pf);
                fireRateTimeStamp = Time.time + fr;
            }
        }
    }
}
