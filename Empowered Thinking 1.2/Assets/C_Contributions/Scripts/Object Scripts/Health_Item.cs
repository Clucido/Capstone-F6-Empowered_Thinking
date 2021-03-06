using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Item : MonoBehaviour
{
    // Start is called before the first frame update
    public string target_tag;
    public Transform Self;
    public GameObject Destroy;
    public float Health_Points;
    public float Max_Health_Points;
    private float x;

    void OnCollisionEnter (Collision collisionInfo){
        var health = collisionInfo.collider.GetComponent<Object_Health>();
        if(collisionInfo.collider.tag == target_tag){
            //Debug.Log ("Hit");
            if(health!=null){
                if((health.Current_Health+Max_Health_Points)>(health.Max_Health+Max_Health_Points)){
                    x = (health.Max_Health+Max_Health_Points)-health.Current_Health;  
                }
                else{
                    x=health.Max_Health+Max_Health_Points;
                }
                Debug.Log(x);
                health.HealMax(x,Max_Health_Points);
                gameObject.SetActive(false);
            }
        }
    }

}
