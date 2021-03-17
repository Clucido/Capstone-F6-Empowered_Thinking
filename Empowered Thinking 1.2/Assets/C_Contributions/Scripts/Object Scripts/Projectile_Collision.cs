using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Collision : MonoBehaviour
{
    // Start is called before the first frame update
    public string target_tag;
    public string projectile_tag;
    public Transform Self;
    public GameObject Destroy;
    public GameObject SpawnOnCollide;
    public float Damage;
    private bool fool;
    void OnCollisionEnter (Collision collisionInfo){
        var health = collisionInfo.collider.GetComponent<Object_Health>();
        fool = collisionInfo.gameObject.CompareTag(projectile_tag);
        if(collisionInfo.collider.tag == target_tag){
            //Debug.Log ("Hit");
            if(health!=null){
                health.TakeDamage(Damage);
            }
        }

        if(!fool){
            GameObject go = (GameObject)Instantiate(SpawnOnCollide,Self.position, Self.rotation);
            Destroy(Destroy);
        }
        

    }

}
