using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    #region Public variables
    #endregion

    #region Private variables
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
    #endregion

    #region Public methods
    #endregion

    #region Private methods
    private void Patroling()
    {
        if (!isWalkPointSet) SearchWalkPoint();

        if (isWalkPointSet)
        {
            //Debug.Log($"Setting agent destination to walkPoint: {walkPoint}");
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
        {
            isWalkPointSet = false;
            Debug.Log("Reached walk point.");
        }
    }

    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            isWalkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }
    private void OnEnable()
    {
        Debug.Log("EnemyAI: Subscribed to Collectibles.OnCollected");

        Collectables.OnCollected += HandleCollectibleCollected;
    }

    private void OnDisable()
    {
        Debug.Log("EnemyAI: Unsubscribed from Collectibles.OnCollected");

        Collectables.OnCollected -= HandleCollectibleCollected;
    }

    private void HandleCollectibleCollected(Transform collectible)
    {
        // Set the new walk point to the collectible's position
        walkPoint = collectible.position;
        isWalkPointSet = true;

        Debug.Log($"Enemy updated walkpoint to {walkPoint} after collectible interaction.");
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
