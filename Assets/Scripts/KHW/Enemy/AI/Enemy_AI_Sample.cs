using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy_AI_Sample : MonoBehaviour
{
    public float detectionRange = 7f;
    private GameObject player;
    private NavMeshAgent agent;
    private List<Vector3> navmeshPositions = new List<Vector3>();
    private float changeTargetTime = 3f;
    private float timer;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        timer = changeTargetTime;

        // 이름이 "Ground_Up"인 오브젝트들을 찾아 NavMesh 위의 위치 저장
        GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();
        foreach (GameObject obj in allObjects)
        {
            if (obj.name == "Ground_Up")
            {
                NavMeshHit hit;
                if (NavMesh.SamplePosition(obj.transform.position, out hit, 1.0f, NavMesh.AllAreas))
                {
                    navmeshPositions.Add(hit.position);
                }
            }
        }

        if (navmeshPositions.Count == 0)
        {
            Debug.LogWarning("⚠️ NavMesh 위에 유효한 'Ground_Up' 위치가 없습니다!");
        }
    }

    void Update()
    {
        if (player == null || !agent.isOnNavMesh) return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToPlayer <= detectionRange)
        {
            agent.SetDestination(player.transform.position);
        }
        else
        {
            timer -= Time.deltaTime;
            if (timer <= 0f && navmeshPositions.Count > 0)
            {
                Vector3 randomPos = navmeshPositions[Random.Range(0, navmeshPositions.Count)];
                agent.SetDestination(randomPos);
                timer = changeTargetTime;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}