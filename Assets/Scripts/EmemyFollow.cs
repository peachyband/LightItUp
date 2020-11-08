using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmemyFollow : MonoBehaviour
{
    [Range (0, 20f)]    
    public float speed;
    [Range(0, 20f)]
    public float stoppingDistance;
    public Transform target;

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
   
   

    }
}
