using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Timeline;

public class EnemyAI : MonoBehaviour
{
    #region Public variables
    #endregion

    #region Private variables
    [Header("Enemy Velocity")]
    [SerializeField] private float velocity;

    [Header("Nav Reference")]
    [SerializeField] private NavMeshAgent agent;
    
    [Header("Player")]
    [SerializeField] private Transform player;

    [Header("Layer")]
    [SerializeField] private LayerMask whatIsGround, whatIsPlayer;
    
    [Header("Attack")]
    [SerializeField] private float timeBetweenAttacks;

    [Header("Patrolling Settings")]
    [SerializeField] private float walkPointRange;
    [SerializeField] private float povRange;
    [SerializeField] private float attackRange;

    private bool playerInPovRange, playerInAttackRange;
    private bool isAlreadyAttacked;
    private bool isWalkPointSet;
    private Vector3 walkPoint;
    #endregion

    #region Public properties
    #endregion

    #region Private properties
    #endregion

    #region Lifecycle
    void Awake()
    {
        
    }
    void Start()
    {
        agent.speed = velocity;

    }

    void Update()
    {
        //Check for sight and attack range
        playerInPovRange = Physics.CheckSphere(transform.position, povRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInPovRange && !playerInAttackRange) Patroling();
        if (playerInPovRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInPovRange) AttackPlayer();
    }
    private void OnEnable()
    {
        Collectables.OnCollected += HandleCollectibleCollected;
        Teleport.OnTeleport += HandleTeleport;
    }


    private void OnDisable()
    {
        Collectables.OnCollected -= HandleCollectibleCollected;
        Teleport.OnTeleport -= HandleTeleport;

    }
    #endregion

    #region Public methods
    #endregion

    #region Private methods
    
    private void Patroling()
    {
        if (!agent.isOnNavMesh)
        {
            Debug.LogWarning("Il NavMeshAgent non � posizionato correttamente su un NavMesh!");
            return;
        }
        if (!isWalkPointSet) SearchWalkPoint();

        if (isWalkPointSet)
        {
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1.5f)
        {
            isWalkPointSet = false;
            Debug.Log("Reached walk point.");
        }
    }

    private void SearchWalkPoint()
    {
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        float randomZ = Random.Range(-walkPointRange, walkPointRange);

        Vector3 potentialPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        Debug.DrawRay(potentialPoint, Vector3.up * 10, Color.blue, 5f);
        NavMeshHit hit = new NavMeshHit();
        Debug.DrawRay(hit.position, Vector3.up * 10, Color.blue, 5f);
        Debug.Log($"Trying point: {potentialPoint}");

        if (NavMesh.SamplePosition(potentialPoint, out hit, walkPointRange, NavMesh.AllAreas))
        {
            walkPoint = hit.position;
            isWalkPointSet = true;
            Debug.DrawLine(transform.position, walkPoint, Color.green, 2f);

        }
        else
        {
            Debug.Log("No valid walk point found. Retrying...");
            isWalkPointSet = false; // Retry if no valid NavMesh point
            Debug.DrawLine(potentialPoint, potentialPoint + Vector3.up * 5, Color.red, 2f);

        }
    }


    private float stuckTimer = 0f;
    private const float maxStuckTime = 2f; // Time before handling stuck behavior

    private void ChasePlayer()
    {
        // Verifica che l'agente sia abilitato e posizionato su un NavMesh
        if (!agent.isOnNavMesh)
        {
            Debug.LogWarning("Il NavMeshAgent non � posizionato correttamente su un NavMesh!");
            return;
        }

        NavMeshPath path = new NavMeshPath();

        // Calcola il percorso solo se l'agente � abilitato e correttamente configurato
        if (agent.enabled && agent.CalculatePath(player.position, path) && path.status == NavMeshPathStatus.PathComplete)
        {
            walkPoint = player.position;
            isWalkPointSet = true;
            agent.SetDestination(player.position);
            stuckTimer = 0f; // Reset timer when chasing successfully
        }
        else
        {
            Debug.Log("Player irraggiungibile. L'Enemy smetter� di inseguire.");
            stuckTimer += Time.deltaTime;

            if (stuckTimer >= maxStuckTime)
            {
                Debug.Log("Enemy � bloccato. Passa alla modalit� di pattugliamento.");
                Patroling();
                stuckTimer = 0f;
            }
        }
    }




    private void HandleCollectibleCollected(Transform collectible)
    {
        // Set the new walk point to the collectible's position
        walkPoint = collectible.position;
        isWalkPointSet = true;

        Debug.Log($"Enemy updated walkpoint to {walkPoint} after collectible interaction.");
    }
    private void HandleTeleport(Transform location)
    {
        // Temporarily disable the NavMeshAgent
        agent.enabled = false;

        // Teleport to the target location
        transform.position = location.position;

        // Re-enable the NavMeshAgent
        agent.enabled = true;

        isWalkPointSet = false;

        Debug.Log($"Enemy updated position to {location.position} after teleport invocation.");

    }
    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!isAlreadyAttacked)
        {
            Debug.Log("Enemy is attacking player");
            isAlreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        isAlreadyAttacked = false;
    }
   
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, povRange);
        if (isWalkPointSet)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(walkPoint, 0.5f);
        }

    }
    #endregion


}
