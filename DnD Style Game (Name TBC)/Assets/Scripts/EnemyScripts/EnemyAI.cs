using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] LayerMask playerLayer;

    [SerializeField] Transform[] walkPoints;
    int index = 0;

    float distance;
    float pDistance;

    [SerializeField] NavMeshAgent agent;
    [SerializeField] Animator anim;

    bool idle = true;
    bool ableToCheck = true;

    /*general aim for editing this script is for the ai to have 3 states
     1. idle - it goes through the walking loop as usual
     2. detecting something - the player gets too close to the ai and it rotates around trying to detect the player
                              if not found then goes back to idle after certain time or the player gets too far away
     3. finding + going after player - player gets hit with a raycast in certain distance + then the ai chases after the player
                                       player either then needs to get out of range or kill enemy - maybe do something with hiding behind objs?
    */
    void Start()
    {
        //setting AI to walk to its first point on idle route
        if (walkPoints != null)
                {
            agent.SetDestination(walkPoints[index].position);
        }
    }

    void Update()
    {
        //to detect player
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
        //check distance + if player close change AI state
        ChangeMode();

        //print(index);
        //if they've not seen player get them to cont route
        if (idle == true)
        {
            //print("walk");
            WalkPattern();
        }
    }

    void ChangeMode()
    {
        pDistance = Vector3.Distance(target.position, this.transform.position);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, playerLayer) && pDistance <= 15){
            idle = false;
            AttackPlayer();
        }
        //change to an attacking state
        else if (pDistance <= 10 && ableToCheck == true)
        {
            //print("GetP");
            idle = false;
            CheckSurroundings();
            //use this for attack state when made via raycast
            //agent.SetDestination(target.position);
        }
        //mainly for setting it back to idle when player gets too far away from ai
        else if (pDistance <= 30)
        {
            print("X");
            idle = true;
            agent.SetDestination(walkPoints[index].position);
        }
    }

    //looping through walkPoints array so it continues walking in a loop until discovering player
    void WalkPattern()
    {
        distance = Vector3.Distance(walkPoints[index].position, this.transform.position);
        //print(distance);

        if (distance <= 7)
        {
            if (index == (walkPoints.Length-1))
            {
                index = 0;
            }
            else { index += 1; }
            agent.SetDestination(walkPoints[index].position);
        }
    }

    [System.Obsolete]
    void CheckSurroundings()
    {
        StartCoroutine(CheckAreaCoolDown());
        print("Checking");
        //stops movement
        agent.Stop();
        anim.Play("EnemyCheckArea");
        ableToCheck = false;
        //if raycast hit player then change state else go back to idle
        //idle = true;
    }

    //goes through at the end of the check from enemy to stop repetition
    void CheckResult()
    {
        anim.Play("Normal");
    }

    void AttackPlayer()
    {
        agent.SetDestination(target.position);
    }

    public IEnumerator CheckAreaCoolDown()
    {
        Debug.Log("Cooling down");
        yield return new WaitForSeconds(3);
        ableToCheck = true;
        agent.Resume();
        //agent.ResetPath();
        //agent.SetDestination(walkPoints[index].position);
    }
}
