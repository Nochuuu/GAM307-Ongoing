using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public enum EnemyState { PATROL, CHASE, IDLE }

public class EnemyAI : MonoBehaviour
{
    public float speed = 1.0f;
    public EnemyState enemyState;
    public NavMeshAgent agent { get; private set; }             // the navmesh agent required for the path finding
    public ThirdPersonCharacter character { get; private set; } // the character we are controlling
    public Transform target;                                    //The target is what this agent will follow
    public List<Transform> patrolPoints;
    Transform player;

	private void Start()
    {
        // get the components on the object we need ( should not be null due to require component so no need to check )
        agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
        character = GetComponent<ThirdPersonCharacter>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

	   agent.updateRotation = false;
       agent.updatePosition = true;
    }


    private void Update()
    {
        switch (enemyState)
        {
            case EnemyState.PATROL:
                PatrolActions();
                break;

            case EnemyState.IDLE:
                IdleActions();
                break;

            case EnemyState.CHASE:
                ChaseActions();
                break;

        }

        if (target != null)
            agent.SetDestination(target.position);

            if (agent.remainingDistance > agent.stoppingDistance)
                character.Move(agent.desiredVelocity, false, false);
            else
                character.Move(Vector3.zero, false, false);

            DebugControl();
        }

    private int destPoint = 0;
    void PatrolActions()
    {
        agent.isStopped = false;
        agent.speed = 0.5f;
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            //return if no points have been set up
            if (patrolPoints.Count == 0)
                return;
            //set the target to go to the currently selected destination
            SetTarget(patrolPoints[destPoint]);

            //Choose the next point in the list as the destination
            //cycling to the start if neccessary
            destPoint = (destPoint + 1) % patrolPoints.Count;
        }

    }


    void IdleActions()
    {
        agent.isStopped = true;
        SetTarget(null);

    }

    void ChaseActions()
    {
        agent.isStopped = false;
        agent.speed = 1f;
        SetTarget(player);
    }



    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    void DebugControl()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            enemyState = EnemyState.PATROL;

        if (Input.GetKeyDown(KeyCode.Alpha2))
            enemyState = EnemyState.IDLE;

        if (Input.GetKeyDown(KeyCode.Alpha3))
            enemyState = EnemyState.CHASE;
    }

}
