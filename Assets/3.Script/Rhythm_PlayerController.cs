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
            // Ű �Է½� ���� ���� �� �ִ��� Ȯ��
            if (Physics.Raycast(origin, Vector3.right * 5, out RaycastHit hit)) 
            {
                Rhythm_SoundManager.instance.PlaySFX("Hit_Correct");
                Rhythm_ChapterManager.instance.CountAdd(true);
                ChangeToMeat(hit.collider.gameObject);
            }
            // �꽺��
            else
            {
                Rhythm_SoundManager.instance.PlaySFX("Swing");
            }
        }

        Debug.DrawRay(origin, Vector3.right * 5, Color.red);
    }

    private void ChangeToMeat(GameObject obj)
    {
        // ��� ���� ����
        GameObject obj_meat = Instantiate(meatPrefab, obj.transform.position, obj.transform.rotation);
        obj_meat.GetComponent<Rigidbody>().angularVelocity = obj.GetComponent<Rigidbody>().angularVelocity * 0.5f;
        obj_meat.GetComponent<Rigidbody>().velocity = obj.GetComponent<Rigidbody>().velocity * 0.5f;
        // ����Ʈ �߻�
        HitParticle.GetComponent<ParticleSystem>().Play();
        // ���� ���´� �ݳ�
        obj.GetComponent<Rigidbody>().Sleep();
        Rhythm_AnimalPooling.instance.ReturnObjectToPool(obj);

    }
}
