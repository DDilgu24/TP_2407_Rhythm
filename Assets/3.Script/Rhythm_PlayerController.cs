using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rhythm_PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject meatPrefab, HitParticle;
    private Animator Hunter_ani;
    Vector3 origin = new Vector3(-2, 1, -7);
    private void Start()
    {
        Hunter_ani = GetComponent<Animator>();
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Hunter_ani.SetTrigger("Swing"); 
            // 키 입력시 판정 범위 내 있는지 확인
            if (Physics.Raycast(origin, Vector3.right * 5, out RaycastHit hit)) 
            {
                Rhythm_SoundManager.instance.PlaySFX("Hit_Correct");
                Rhythm_ChapterManager.instance.CountAdd(true);
                ChangeToMeat(hit.collider.gameObject);
            }
            // 헛스윙
            else
            {
                Rhythm_SoundManager.instance.PlaySFX("Swing");
            }
        }

        Debug.DrawRay(origin, Vector3.right * 5, Color.red);
    }

    private void ChangeToMeat(GameObject obj)
    {
        // 고기 형태 생성
        GameObject obj_meat = Instantiate(meatPrefab, obj.transform.position, obj.transform.rotation);
        obj_meat.GetComponent<Rigidbody>().angularVelocity = obj.GetComponent<Rigidbody>().angularVelocity * 0.5f;
        obj_meat.GetComponent<Rigidbody>().velocity = obj.GetComponent<Rigidbody>().velocity * 0.5f;
        // 이펙트 발생
        HitParticle.GetComponent<ParticleSystem>().Play();
        // 동물 형태는 반납
        obj.GetComponent<Rigidbody>().Sleep();
        Rhythm_AnimalPooling.instance.ReturnObjectToPool(obj);

    }
}
