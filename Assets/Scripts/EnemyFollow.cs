using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    [Header("Enemy speed:")][Range (0, 20f)]    
    public float speed;
    [Header("Enemy reach distance:")][Range (0, 20f)]
    public float stoppingDistance;
    [Header("Enemy health:")][Range(0, 20f)]
    public float health;
    [Header("Enemy causing damage")][Range(0, 5f)]
    public float damage;
    [Header("Enemy reload time")][Range(0, 5f)]
    public float reloadTime;
    public Transform target;

    private bool CanAttack = true;

    public void SetHealth(float hp)
    {
        health += hp;
    }

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }

    void Update()
    {
        if(Vector2.Distance(transform.position, target.position) < stoppingDistance)
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, (target.position - transform.position));
        transform.rotation = targetRotation;
        HealthCheck();
    }

    void HealthCheck()
    {
        if(health < 0)
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator WaitReload()
    {
        yield return new WaitForSeconds(reloadTime);
        CanAttack = true;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.transform.tag == "Player" && CanAttack)
        {
            other.GetComponent<PlayerMovement>().SetHealth(-damage);
            CanAttack = false;
            StartCoroutine(WaitReload());
        }
    }


}
