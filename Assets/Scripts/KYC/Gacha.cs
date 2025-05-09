using UnityEngine;
using System.Collections;

public class Gacha : MonoBehaviour
{
    public GameObject[] products;

    void Start()
    {
        // 모든 product 비활성화
        for (int i = 0; i < products.Length; i++)
        {
            products[i].SetActive(false);
        }

        // 셔플 시작
        StartShuffle();
    }

    private void StartShuffle()
    {
        StartCoroutine(SpawnGacha());
    }

    IEnumerator SpawnGacha()
    {
        int previousIndex = -1;

        while (true)
        {
            // 이전에 켜졌던 오브젝트 끄기
            if (previousIndex >= 0)
            {
                products[previousIndex].SetActive(false);
            }

            // 랜덤으로 새 오브젝트 선택
            int i = Random.Range(0, products.Length);
            products[i].SetActive(true);
            previousIndex = i;

            yield return new WaitForSeconds(0.5f);
        }
    }
}
