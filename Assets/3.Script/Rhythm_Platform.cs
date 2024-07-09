using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rhythm_Platform : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        col.GetComponent<Rigidbody>().Sleep();
        // ������ ����� ��, �� �̽�
        if (col.CompareTag("Animal"))
        {
            Rhythm_SoundManager.instance.PlaySFX("Miss");
            print("Miss");
            Rhythm_AnimalPooling.instance.ReturnObjectToPool(col.gameObject);
        }
        else
        {
            Destroy(col.gameObject);
        }
    }
}
