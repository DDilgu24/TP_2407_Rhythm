using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rhythm_PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject meatPrefab;
    Vector3 origin = new Vector3(-2, 1, -7);
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            // 키 입력시 판정 범위 내 있는지 확인
            if (Physics.Raycast(origin, Vector3.right * 5, out RaycastHit hit)) 
            {
                Rhythm_SoundManager.instance.PlaySFX("Hit_Correct");
                print("Hit");
                GameObject obj_animal = hit.collider.gameObject;


                // 고기 형태 생성
                GameObject obj_meat = Instantiate(meatPrefab, obj_animal.transform.position, Quaternion.identity);
                // obj_meat.GetComponent<Rigidbody>().AddForce(obj_animal.GetComponent<Rigidbody>().velocity, ForceMode.VelocityChange);
                // 이펙트 발생
                // obj_meat.GetComponent<ParticleSystem>().Play();
                // 동물 형태는 반납
                obj_animal.GetComponent<Rigidbody>().Sleep();
                Rhythm_AnimalPooling.instance.ReturnObjectToPool(obj_animal);


            }
            // 헛스윙
            else
            {
                Rhythm_SoundManager.instance.PlaySFX("Swing");
                print("No hit");
            }
        }
        Debug.DrawRay(origin, Vector3.right * 5, Color.red);
    }
}
