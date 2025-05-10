using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class Player_Status : MonoBehaviour
{
    private CharacterController _controller;
    private GameObject _hideUi;
    private Coroutine hideCoroutine;

    public float hp = 100;
    public float stamina = 100;

    public bool playerHide = false;


    private void Start()
    {
        _hideUi = transform.GetComponentInChildren<Hide_UI>(true).gameObject;
    }

    public void OnHide(InputValue value)
    {
        if (value.isPressed)
        {
            if (hideCoroutine != null)
                StopCoroutine(hideCoroutine);

            if (playerHide)
                hideCoroutine = StartCoroutine(AnimateBottom(0f , 1080f)); // 숨기기
            else
                hideCoroutine = StartCoroutine(AnimateBottom(1080f, 0f)); // 숨기기 UI 펼치기

            playerHide = !playerHide;
        }
    }

    private IEnumerator AnimateBottom(float from, float to)
    {
        float duration = 0.1f;
        float elapsed = 0f;
        Vector2 offsetMin = _hideUi.GetComponent<RectTransform>().offsetMin;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;
            float newY = Mathf.Lerp(from, to, t);
            _hideUi.GetComponent<RectTransform>().offsetMin = new Vector2(offsetMin.x, newY);
            yield return null;
        }

        _hideUi.GetComponent<RectTransform>().offsetMin = new Vector2(offsetMin.x, to); // 마지막 보정
    }
}
