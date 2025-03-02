using UnityEngine;
using UnityEngine.AI;

public class RoboCopMovement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float range = 10f;

    [SerializeField] private Transform centerPoint;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (!agent.isOnNavMesh)
        {
            NavMeshHit hit;
            if (NavMesh.SamplePosition(transform.position, out hit, 2.0f, NavMesh.AllAreas))
            {
                transform.position = hit.position; // Перемещаем объект на NavMesh
                agent.Warp(hit.position); // Телепортируем агента на NavMesh
            }
            else
            {
                Debug.LogError("Не удалось найти NavMesh рядом! Переместите объект вручную.");
            }
        }
    }

    private bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        for(int i = 0; i < 30;  i++)
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
        return true;
    }

    private void Update()
    {
        if(agent.remainingDistance <= agent.stoppingDistance)
        {
            Vector3 point;
            if (RandomPoint(transform.position, range, out point))
            {
                Debug.DrawRay(point, Vector3.up, Color.yellow, 1.0f);
                agent.SetDestination(point);
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (centerPoint != null)
        {
            Gizmos.color = Color.green; // Цвет сферы
            Gizmos.DrawWireSphere(centerPoint.position, range); // Отрисовка сферы
        }
    }

}
