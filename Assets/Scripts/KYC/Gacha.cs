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
            // 이전 오브젝트 끄기
            if (previousIndex >= 0 && products[previousIndex].activeSelf)
            {
                products[previousIndex].SetActive(false);
            }

            // 이전과 다른 인덱스 선택
            int i;
            do
            {
                i = Random.Range(0, products.Length);
            } while (i == previousIndex);

            // 새 오브젝트 켜기
            products[i].SetActive(true);
            previousIndex = i;

            yield return new WaitForSeconds(0.5f);
        }
    }
}
