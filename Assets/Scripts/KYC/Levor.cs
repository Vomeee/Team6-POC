using UnityEngine;
using System.Collections;

public class Lever : MonoBehaviour
{
    private bool _isRotating = false;

    private void OnEnable()
    {
        TemporaryFirstPersonController.OnLevorHit += HandleLevorHit;
    }

    private void OnDisable()
    {
        TemporaryFirstPersonController.OnLevorHit -= HandleLevorHit;
    }

    private void HandleLevorHit(GameObject hitObject)
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

        _isRotating = false;
    }

}
