using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rhythm_AnimalPooling : MonoBehaviour
{
    // 0�ܰ� : �̱��� ����
    public static Rhythm_AnimalPooling instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else { Destroy(gameObject); }
    }
    // 1�ܰ�: Ǯ ����
    // 1-1. Ǯ���� ������Ʈ�� �������� ����
    public GameObject AnimalPrefab;
    // 1-2. Ǯ���� ���� ����
    private int poolSize = 10;
    // 1-3. Ǯ���� ������ ť�� ����
    public Queue<GameObject> AnimalPool = new Queue<GameObject>();
    // 1-4. ť�� ������Ʈ���� ä���
    private void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            // 1-4-1. ������Ʈ ����
            GameObject note_obj = Instantiate(AnimalPrefab);
            // 1-4-2. ������ �� ��Ȱ��ȭ
            note_obj.SetActive(false);
            // 1-4.3. ť�� �߰�
            AnimalPool.Enqueue(note_obj);
        }
    }

    // 2�ܰ�: ������Ʈ�� Ǯ���� ���� �� �޼���
    public GameObject GetObjectFromPool()
    {
        // ���� ó��: Ǯ�� ���� ����ع��� ���
        if (AnimalPool.Count.Equals(0))
        {
            Debug.Log("!!! Ǯ�� ������ �ʰ���");
            return null;
        }
        // 2-1. ť���� ������Ʈ�� ������
        GameObject note_obj = AnimalPool.Dequeue();
        // 2-2. ���� �� Ȱ��ȭ
        note_obj.SetActive(true);
        // 2-3. ���� ������Ʈ�� ��ȯ
        return note_obj;
    }

    // 3�ܰ�: ������Ʈ�� Ǯ�� �ݳ��ϴ� �޼���
    public void ReturnObjectToPool(GameObject obj)
    {
        // 3-1. ���� �� ��Ȱ��ȭ
        obj.SetActive(false);
        // 3-2. �ٽ� ť�� �ֱ�
        AnimalPool.Enqueue(obj);
    }

}
