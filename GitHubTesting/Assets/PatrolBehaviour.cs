using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehaviour : StateMachineBehaviour
{
    [SerializeField] private PatrolSpots patrol;
    public Transform[] movePoints;
    public float speed;
    private float waitTime;
    public float startWaitTime;

    public int randomSpot;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        patrol = animator.GetComponent<PatrolSpots>();
        movePoints = new Transform[patrol.patrolPoints.Length];
        for (int i = 0; i < patrol.patrolPoints.Length; i++)
        {
            movePoints[i] = patrol.patrolPoints[i];
        }
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, movePoints.Length);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 targetDirection = movePoints[randomSpot].position - animator.transform.position;
        targetDirection.y = 0f;
        animator.transform.forward = Vector3.Lerp(animator.transform.forward, targetDirection, Time.deltaTime);

        animator.transform.position = Vector3.MoveTowards(animator.transform.position, movePoints[randomSpot].position, speed * Time.deltaTime);

        if (Vector3.Distance(animator.transform.position, movePoints[randomSpot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, movePoints.Length);
                waitTime = startWaitTime;

            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
