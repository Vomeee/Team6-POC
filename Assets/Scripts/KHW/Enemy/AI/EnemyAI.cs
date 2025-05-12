using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;
    public GameObject jumpScare;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent.updateRotation = true;
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            jumpScare.SetActive(true);
            StartCoroutine(ExitGame());
        }
        
    }

    IEnumerator ExitGame()
    {
        yield return new WaitForSeconds(1.5f);
        Application.Quit();
    }

}
