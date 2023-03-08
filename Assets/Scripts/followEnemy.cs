using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followEnemy : MonoBehaviour
{
    [SerializeField] float speed;
    [HideInInspector] public Transform target = null; // dusri script se leti hai
    private Animator anim;

    public float minDistance;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {

        if (Vector3.Distance(transform.position, target.position) > minDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            transform.LookAt(target);
            
        }
       if (Vector3.Distance(transform.position , target.position) > 0.1f)
        {
            
            anim.SetBool("isWalking" , true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        } 
    }
}
