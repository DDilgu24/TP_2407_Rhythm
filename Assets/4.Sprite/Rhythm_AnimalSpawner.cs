using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Rhythm_AnimalSpawner : MonoBehaviour
{
    // public Rhythm_AnimalPooling animalPool;
    [SerializeField] private Transform Spawner;
    private GameObject obj;
    private double current_time = -3.225d;
    private int BPM = 130;
    private int count = 0;
    private int[] animal_appear;

    private void Start()
    {
        animal_appear = new int[112]
        {
            0,0,1,0,0,0,0,0,0,0,
            1,0,0,0,0,0,0,0,1,0,
            0,0,1,0,0,0,1,0,0,1,
            1,0,0,0,1,0,0,0,0,0,
            0,0,1,0,0,0,0,0,0,0,

            1,0,0,0,1,0,0,0,1,0,
            0,0,1,0,0,0,1,0,0,0,
            1,0,0,0,1,0,0,1,1,0,
            0,0,1,0,0,0,1,0,0,0,
            1,0,0,0,1,1,0,0,1,0,

            0,0,1,1,0,0,1,0,0,0,
            1,1
        };
    }

    private void FixedUpdate()
    {
        if (count > 111) return;
        current_time += Time.deltaTime;
        if (current_time > 60d / BPM)
        {
            if(animal_appear[count] < 1)
            {
                // 안 나오는 박자
            }
            else
            {
                // 동물 생성하는 부분
                // 1. 동물을 풀에서 꺼내온다.
                obj = Rhythm_AnimalPooling.instance.GetObjectFromPool();
                // 2. 풀에서 꺼낸 동물의 위치를 설정한다.
                obj.transform.position = Spawner.position;
                // 3. Rigidbody에 힘 적용(방향 - forward / 크기 / 힘의 종류)
                Vector3 v = new Vector3(-0.5f, 0.5f, -0.7f);
                obj.GetComponent<Rigidbody>().AddForce(v * 13f, ForceMode.Impulse);
            }
            count++;
            current_time -= (60d / BPM);
        }
    }

    
}