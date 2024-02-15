using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [System.Serializable]
    public struct Pool // poll ����ü
    {
        public string tag; // ������Ʈ �ĺ��� �±�
        public GameObject prefab; // ����ü ������
        public int size; // ������ ����
    }

    public List<Pool> pools; // ������Ʈ(����ü) Ǯ ����� ����Ʈ
    public Dictionary<string, Queue<GameObject>> poolDictionary;
    // ��ųʸ�,   �±� = Ű, ������Ʈ ť = ��

    private void Awake()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>(); //��ųʸ� �ʱ�ȭ
        foreach (var pool in pools) // �ݺ�
        {
            Queue<GameObject> objectPool = new Queue<GameObject>(); // ť ����
            for (int i = 0; i < pool.size; i++) // Ǯ �����ŭ �ݺ�
            {
                GameObject obj = Instantiate(pool.prefab); // ������ �ν��Ͻ�ȭ
                obj.SetActive(false); // �ν��Ͻ�ȭ�� ������Ʈ ��Ȱ��ȭ
                objectPool.Enqueue(obj); // ť�� �߰�
            }
            poolDictionary.Add(pool.tag, objectPool); // ��ųʸ��� ť �߰�
        }
    }

    public GameObject SpawnFromPool(string tag) // Ǯ���� ������Ʈ ����
    {
        if (!poolDictionary.ContainsKey(tag))
            return null; // tag ������ null

        GameObject obj = poolDictionary[tag].Dequeue(); // ������Ʈ Ǯ���� ������Ʈ �ϳ��� ������
        
        poolDictionary[tag].Enqueue(obj); // ����� ������Ʈ �ٽ� ť�� �߰�(����)

        return obj; // ���� �� ������Ʈ ��ȯ
    }


    //1. Awake���� ����ü ������Ʈ �����ϰ� poolDictionary�� ����
    //2. SpawnFromPool �޼���� ����ü ������Ʈ Ǯ���� ������ ���
    //   ����� ���� ������Ʈ�� �ٽ� Ǯ�� ��ȯ�Ͽ� ����
}
