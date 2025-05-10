using UnityEngine;
using System.Collections;

public class Lever : MonoBehaviour, IInteractable
{
    public GameObject[] spawnPrefabs; // 소환할 프리팹 배열
    private Transform spawnPoint;     // SpawnPoint 위치 캐싱
    [SerializeField] private bool _isRotating = false;


    private void Start()
    {
        // 자식 중 "SpawnPoint"라는 이름을 가진 오브젝트 찾기
        spawnPoint = transform.parent.GetChild(0);
        if (spawnPoint == null)
        {
            Debug.LogError("SpawnPoint를 찾을 수 없습니다.");
        }
    }


    public void Interact(GameObject interactor, float value)
    {
        if(GoldManager.Instance.goldMy >= 50)
        {
            GoldManager.Instance.UseGold(50);
            HandleLevorHit(interactor);
        }
    }

    public void HandleLevorHit(GameObject hitObject)
    {
        if (hitObject == gameObject && !_isRotating)
        {
            Debug.Log("레버가 클릭되었습니다!");
            StartCoroutine(RotateLeverSmoothly());
        }
    }

    private IEnumerator RotateLeverSmoothly()
    {
        if (_isRotating)
            yield break; // 회전 중이면 무시

        _isRotating = true;

        float duration = 1f;
        float elapsed = 0f;
        float totalRotation = 0f;

        while (elapsed < duration)
        {
            float delta = Time.deltaTime;
            float rotationThisFrame = 180f * (delta / duration);

            transform.Rotate(rotationThisFrame, 0f, 0f);
            totalRotation += rotationThisFrame;
            elapsed += delta;

            yield return null;
        }

        // 정확히 정렬 (오차 보정)
        Vector3 finalRotation = transform.eulerAngles;
        finalRotation.x = Mathf.Round(finalRotation.x / 360f) * 360f;
        transform.eulerAngles = finalRotation;


        // 프리팹 소환
        if (spawnPrefabs.Length > 0 && spawnPoint != null)
        {
            int index = Random.Range(0, spawnPrefabs.Length);
            Instantiate(spawnPrefabs[index], spawnPoint.position, spawnPoint.rotation);
        }

        

        

        _isRotating = false;
    }

}
