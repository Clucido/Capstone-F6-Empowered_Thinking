using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_Text : MonoBehaviour
{
    public Text healthText;
    public HealthBar healthBar;
    public GameObject actor;
    
    void Update(){
        changeText();
    }
    public void changeText(){
        var health = actor.GetComponent<Object_Health>();
        
        healthText.text=health.Current_Health.ToString(); 
    }
}
