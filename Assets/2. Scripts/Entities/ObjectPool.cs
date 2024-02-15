using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [System.Serializable]
    public struct Pool // poll 구조체
    {
        public string tag; // 오브젝트 식별용 태그
        public GameObject prefab; // 투사체 프리팹
        public int size; // 복제될 개수
    }

    public List<Pool> pools; // 오브젝트(투사체) 풀 저장용 리스트
    public Dictionary<string, Queue<GameObject>> poolDictionary;
    // 딕셔너리,   태그 = 키, 오브젝트 큐 = 값

    private void Awake()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>(); //딕셔너리 초기화
        foreach (var pool in pools) // 반복
        {
            Queue<GameObject> objectPool = new Queue<GameObject>(); // 큐 생성
            for (int i = 0; i < pool.size; i++) // 풀 사이즈만큼 반복
            {
                GameObject obj = Instantiate(pool.prefab); // 프리팹 인스턴스화
                obj.SetActive(false); // 인스턴스화된 오브젝트 비활성화
                objectPool.Enqueue(obj); // 큐에 추가
            }
            poolDictionary.Add(pool.tag, objectPool); // 딕셔너리에 큐 추가
        }
    }

    public GameObject SpawnFromPool(string tag) // 풀에서 오브젝트 스폰
    {
        if (!poolDictionary.ContainsKey(tag))
            return null; // tag 없으면 null

        GameObject obj = poolDictionary[tag].Dequeue(); // 오브젝트 풀에서 오브젝트 하나를 가져옴
        
        poolDictionary[tag].Enqueue(obj); // 사용한 오브젝트 다시 큐에 추가(재사용)

        return obj; // 스폰 된 오브젝트 반환
    }


    //1. Awake에서 투사체 오브젝트 생성하고 poolDictionary에 저장
    //2. SpawnFromPool 메서드로 투사체 오브젝트 풀에서 꺼내서 사용
    //   사용이 끝난 오브젝트는 다시 풀로 반환하여 재사용
}
