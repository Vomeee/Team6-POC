using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;

        if (!agent.isOnNavMesh)
        {
            Debug.LogWarning("❌ 적이 NavMesh 위에 생성되지 않았습니다!");
        }
    }


    void Update()
    {
        if (target != null)
        {
            if (agent != null)
            {
                Debug.Log($"Agent Enabled: {agent.enabled}, ActiveAndEnabled: {agent.isActiveAndEnabled}, OnNavMesh: {agent.isOnNavMesh}");
                
                if (agent.isOnNavMesh)
                {
                    agent.SetDestination(target.position);
                }
            }
        }
    }

}
