using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(SFX))]
public class EnemyAI : MonoBehaviour
{
    #region Private variables
    [Header("Enemy Velocity")]
    [SerializeField] private float velocity;

    [Header("Nav Reference")]
    [SerializeField] private NavMeshAgent agent;

    [Header("Player")]
    [SerializeField] private Transform player;

    [Header("Layer")]
    [SerializeField] private LayerMask whatIsGround, whatIsPlayer;

    [Header("Patrolling Settings")]
    [SerializeField] private float walkPointRange;
    [SerializeField] private float povRange;
    [SerializeField] private float attackRange;

    [Header("SFX")]
    [SerializeField] private SFX sfx;

    private bool isWalkPointSet;
    private Vector3 walkPoint;

    private float stuckTimer = 0f;
    private const float maxStuckTime = 2f;

    private enum EnemyState { Patrolling, Chasing, Attacking }
    private EnemyState currentState;

    private bool isAttacking = false;
    #endregion

    #region Lifecycle
    private void Awake()
    {
        sfx = GetComponent<SFX>();
    }
    void Start()
    {
        agent.speed = velocity;
        currentState = EnemyState.Patrolling; // Inizia pattugliando
    }

    void Update()
    {
        if(transform.position != Vector3.zero)
        {
            sfx.PlaySFX(0);
            sfx.PlaySFX(1);
        }
        // Controlla lo stato del giocatore
        bool playerInPovRange = Physics.CheckSphere(transform.position, povRange, whatIsPlayer);
        bool playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        // Cambia stato in base alla posizione del giocatore
        if (playerInAttackRange)
        {
            currentState = EnemyState.Attacking;
            isAttacking = true;

        }
        else if (playerInPovRange)
        {
            isAttacking = false;
            currentState = EnemyState.Chasing;
        }
        else
        {
            isAttacking = false;
            currentState = EnemyState.Patrolling;
        }

        // Gestisci comportamento in base allo stato
        switch (currentState)
        {
            case EnemyState.Patrolling:
                Patroling();               
                break;
            case EnemyState.Chasing:
                ChasePlayer();
                break;
            case EnemyState.Attacking:
                AttackPlayer();
                break;
        }

        //HandleStuck();
    }

    private void OnEnable()
    {
        Collectables.OnCollected += HandleCollectibleCollected;
        Teleport.OnTeleportation += HandleTeleport;
    }

    private void OnDisable()
    {
        Collectables.OnCollected -= HandleCollectibleCollected;
        Teleport.OnTeleportation -= HandleTeleport;
    }
    #endregion

    #region Private methods
    private void Patroling()
    {
        if (!agent.isOnNavMesh)
        {
            //Debug.LogWarning("Il NavMeshAgent non è posizionato correttamente su un NavMesh!");
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
            //Debug.Log("Punto di pattugliamento raggiunto.");
        }
    }

    private void SearchWalkPoint()
    {
        // Esegui la ricerca del walk point solo se non si è in attacco
        if (currentState == EnemyState.Attacking || isAttacking)
        {
            //Debug.Log("Skip ricerca walk point durante l'attacco.");
            return;
        }

        isWalkPointSet = false;
        for (int i = 0; i < 10; i++) // Limita a 10 tentativi
        {
            float randomX = Random.Range(-walkPointRange, walkPointRange);
            float randomZ = Random.Range(-walkPointRange, walkPointRange);

            Vector3 potentialPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

            NavMeshHit hit;
            if (NavMesh.SamplePosition(potentialPoint, out hit, walkPointRange, NavMesh.AllAreas))
            {
                walkPoint = hit.position;
                isWalkPointSet = true;
                //Debug.Log($"Walk point trovato: {walkPoint}");
                return;
            }
        }

        //Debug.LogWarning("Nessun punto valido trovato per il pattugliamento.");
    }

    private void ChasePlayer()
    {
        if (!agent.isOnNavMesh)
        {
            //Debug.LogWarning("Il NavMeshAgent non è posizionato correttamente su un NavMesh!");
            return;
        }

        NavMeshPath path = new NavMeshPath();

        // Calcola il percorso verso il giocatore
        if (agent.enabled && agent.CalculatePath(player.position, path) && path.status == NavMeshPathStatus.PathComplete)
        {
            agent.SetDestination(player.position);
            //Debug.Log("Inseguendo il giocatore.");
            stuckTimer = 0f; // Resetta il timer di blocco
        }
        else
        {
            stuckTimer += Time.deltaTime;

            if (stuckTimer >= maxStuckTime)
            {
                //Debug.LogWarning("Il nemico è bloccato durante l'inseguimento. Tentativo di percorso alternativo.");
                stuckTimer = 0f;

                // Prova un punto intermedio verso il giocatore
                Vector3 directionToPlayer = (player.position - transform.position).normalized;
                float retryDistance = 5.0f; // Distanza del punto intermedio
                Vector3 intermediatePoint = transform.position + directionToPlayer * retryDistance;

                NavMeshHit hit;
                if (NavMesh.SamplePosition(intermediatePoint, out hit, retryDistance, NavMesh.AllAreas))
                {
                    agent.SetDestination(hit.position);
                    //Debug.Log($"Percorso alternativo impostato verso: {hit.position}");
                }
                else
                {
                    //Debug.LogWarning("Percorso alternativo non trovato. Tornando al pattugliamento.");
                    currentState = EnemyState.Patrolling;
                }
            }
        }
    }


    private void AttackPlayer()
    {
        isAttacking = true;
        agent.SetDestination(transform.position); // Blocca il movimento
        transform.LookAt(player);
        //Debug.Log("Attaccando il giocatore.");
        //Invoke(nameof(ResetAttack), 1f); // Simula un intervallo tra gli attacchi
        PlayerDie();
    }

    private void PlayerDie()
    {
    }


    private void HandleStuck()
    {
        if (!agent.hasPath && !agent.pathPending)
        {
            //Debug.LogWarning("Il nemico sembra bloccato. Tentativo di riposizionamento.");
            currentState = EnemyState.Patrolling;
            SearchWalkPoint();
        }
    }

    private void HandleCollectibleCollected(Transform collectible)
    {
        walkPoint = collectible.position;
        isWalkPointSet = true;
        //Debug.Log($"Enemy updated walkpoint to {walkPoint} after collectible interaction.");
    }

    private void HandleTeleport(Transform location)
    {
        agent.enabled = false;
        transform.position = location.position;
        agent.enabled = true;
        isWalkPointSet = false;
        //Debug.Log($"Enemy updated position to {location.position} after teleport invocation.");
    }
    #endregion

    #region //Debugging
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
