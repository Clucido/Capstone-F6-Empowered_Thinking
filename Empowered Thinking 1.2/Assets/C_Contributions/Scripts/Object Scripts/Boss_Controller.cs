using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss_Controller : MonoBehaviour
{
// Related to Enemy_Movement
    Transform Target;
    NavMeshAgent agent;
    //public LayerMask whatIsGround, whatIsPlayer;
    public float Detect_Range = 0f;
    public float Attack_Range = 0f;
    private bool isDetected;
    private bool Attack;
    private Vector3 ogPos;
    private bool hasAttacked = false;


    // Related to shooting Projectiles

    public float moveforce = 0f;
    private Rigidbody rigidbody;
    public GameObject projectile;
    public Transform gun;
    public Transform gun2;
    public float resetTime = 0f;
    public float fireRate = 0f;
    public int shotsPerAttack=0;
    public float projectileForce = 0f;
    private float fireRateTimeStamp = 0f;
    



    private void Awake(){
        Target = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        rigidbody = GetComponent<Rigidbody>();
        ogPos = new Vector3(transform.position.x, transform.position.y, transform.position.x);
    }

    private void Update(){
        float distance = Vector3.Distance(Target.position, transform.position); 
        isDetected=detection(distance,Detect_Range);
        Attack = detection(distance,Attack_Range);
        //isDetected = true;
        //Attack = false;
        if (isDetected && Attack){
            attack();
            //Debug.Log("Attack");
        }
        if (isDetected && !Attack){
            chase();
            //Debug.Log("Chase");
            //Debug.Log(isDetected);
            //Debug.Log(Attack);
        } 
        if(!isDetected && !Attack){
            returnToPos();
            //Debug.Log("Return");
        }
    }

    private void attack(){
        agent.SetDestination(transform.position);
        transform.LookAt(Target);

        
        if (!hasAttacked){
            
            StartCoroutine(shootBurst());

            hasAttacked=true;
            Invoke(nameof(resetAttack),resetTime);
        } 

    }

    private void chase(){
        agent.SetDestination(Target.position);
    }
    private void returnToPos(){
        agent.SetDestination(ogPos);

    }
    
    private void shoot(){
        float Horizontal = Input.GetAxisRaw("Horizontal")*moveforce;
        float Vertical = Input.GetAxisRaw("Vertical")*moveforce;
        rigidbody.velocity = new Vector3(Horizontal,Vertical,0);
        if(Time.time > fireRateTimeStamp){
            GameObject go = (GameObject)Instantiate(projectile,gun.position, gun.rotation);
            go.GetComponent<Rigidbody>().AddForce(gun.forward * projectileForce);
            GameObject go2 = (GameObject)Instantiate(projectile,gun2.position, gun2.rotation);
            go2.GetComponent<Rigidbody>().AddForce(gun2.forward * projectileForce);
            fireRateTimeStamp = Time.time + fireRate;
        }
    
    }

     private IEnumerator shootBurst(){
        WaitForSeconds wait = new WaitForSeconds( fireRate ) ;
        for (int i =0;i < shotsPerAttack; i++){
            shoot();
            yield return wait;   
        }

    }

    private void resetAttack(){
        hasAttacked=false;
    }


    private bool detection(float x, float y){
        bool fool = false;
        if(x <= y){
            fool = true;
        }
        return fool;
    }

    void OnDrawGizmosSelected(){
        Gizmos.color=Color.red;
        Gizmos.DrawWireSphere(transform.position, Detect_Range);
        Gizmos.DrawWireSphere(transform.position, Attack_Range);
    }


}
