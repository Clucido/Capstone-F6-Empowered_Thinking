using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Health : MonoBehaviour
{
    public float Max_Health;
    public float Current_Health;
    public float Health_Cap;

    public HealthBar healthBar;

    private void OnEnable()
    {
        Current_Health = Max_Health;
        healthBar.SetMaxHealth(Max_Health);
    }

    void Update(){
        if(Current_Health>Max_Health){
            Current_Health=Max_Health;
        }
        if(Max_Health>Health_Cap){
            Max_Health=Health_Cap;
        }
    }

    public void TakeDamage(float damage){
        Current_Health -= damage;
        healthBar.SetHealth(Current_Health);
        if(Current_Health <= 0){
            Die();
        }
    }

    public void HealDamage(float health){
        Current_Health = Current_Health + health;
        if(Current_Health>Max_Health){
            healthBar.SetHealth(Max_Health);
        }
        else{
            healthBar.SetHealth(Current_Health);
        }
    }

    public void HealMax(float health,float max){
        Max_Health = max + Max_Health;
        Current_Health=Current_Health+health;
        healthBar.SetMaxHealth(Max_Health);
        healthBar.SetHealth(Current_Health);
    }

    private void Die(){
        gameObject.SetActive(false);
    }

}
