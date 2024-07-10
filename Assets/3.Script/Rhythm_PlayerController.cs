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

        if (Input.GetKeyDown(KeyCode.Space) && !Hunter_ani.GetBool("IsSwing"))
        {
            Hunter_ani.SetBool("IsSwing", true);    
            // Ű �Է½� ���� ���� �� �ִ��� Ȯ��
            if (Physics.Raycast(origin, Vector3.right * 5, out RaycastHit hit)) 
            {
                Rhythm_SoundManager.instance.PlaySFX("Hit_Correct");
                print("Hit");
                GameObject obj_animal = hit.collider.gameObject;


                // ��� ���� ����
                GameObject obj_meat = Instantiate(meatPrefab, obj_animal.transform.position, obj_animal.transform.rotation);
                obj_meat.GetComponent<Rigidbody>().angularVelocity = obj_animal.GetComponent<Rigidbody>().angularVelocity * 0.5f;
                obj_meat.GetComponent<Rigidbody>().velocity = obj_animal.GetComponent<Rigidbody>().velocity * 0.5f;
                // ����Ʈ �߻�
                HitParticle.GetComponent<ParticleSystem>().Play();
                // ���� ���´� �ݳ�
                obj_animal.GetComponent<Rigidbody>().Sleep();
                Rhythm_AnimalPooling.instance.ReturnObjectToPool(obj_animal);


            }
            // �꽺��
            else
            {
                Rhythm_SoundManager.instance.PlaySFX("Swing");
                print("No hit");
            }
            Invoke("PoseReset", 0.3f);
        }

        Debug.DrawRay(origin, Vector3.right * 5, Color.red);
    }

    private void PoseReset()
    {
        Hunter_ani.SetBool("IsSwing", false);
    }
}
