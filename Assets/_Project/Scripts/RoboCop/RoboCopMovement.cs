using UnityEngine;
using UnityEngine.AI;

public class RoboCopMovement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float range = 10f;
    [SerializeField] private Transform centerPoint;
    [SerializeField] private GameObject player;

    private RoboCopController controller;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        controller = GetComponent<RoboCopController>();

        if (!agent.isOnNavMesh)
        {
            NavMeshHit hit;
            if (NavMesh.SamplePosition(transform.position, out hit, 2.0f, NavMesh.AllAreas))
            {
                transform.position = hit.position;
                agent.Warp(hit.position);
            }
            else
            {
                Debug.LogError("Не удалось найти NavMesh рядом! Переместите объект вручную.");
            }
        }
    }

    private void Update()
    {
        if (controller.isPlayerFind)
            MoveToPlayer();
        else
            Move();
    }

    private void Move()
    {
        agent.speed = 7;
        agent.angularSpeed = 150;
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            Vector3 point;
            if (RandomPoint(transform.position, range, out point))
            {
                Debug.DrawRay(point, Vector3.up, Color.yellow, 1.0f);
                agent.SetDestination(point);
            }
        }
    }

    private void MoveToPlayer()
    {
        agent.speed = 20;
        agent.angularSpeed = 300;
        if (player != null)
        {
            agent.SetDestination(player.transform.position);
        }
    }

    private bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }
        result = Vector3.zero;
        return false;
    }

    private void OnDrawGizmosSelected()
    {
        if (centerPoint != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(centerPoint.position, range);
        }
    }
}
