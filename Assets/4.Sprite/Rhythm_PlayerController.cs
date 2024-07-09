using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rhythm_PlayerController : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            // Ű �Է½� ���� ���� �� �ִ��� Ȯ��
            Vector3 origin = new Vector3(-2.5f, 1.5f, -8);
            Debug.DrawRay(origin, Vector3.right * 5, Color.red);
            if (Physics.Raycast(origin, Vector3.right * 5, out RaycastHit hit)) 
            {
                Rhythm_SoundManager.instance.PlaySFX("Hit_Correct");
                print("Hit");
                GameObject obj = hit.collider.gameObject;
                obj.GetComponent<Rigidbody>().Sleep();
                Rhythm_AnimalPooling.instance.ReturnObjectToPool(obj);
            }
            // �꽺��
            else
            {
                Rhythm_SoundManager.instance.PlaySFX("Swing");
                print("No hit");
            }
        }
    }
}
