using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rhythm_Platform : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        // 동물이 닿았을 때, 즉 미스
        if (col.CompareTag("Animal"))
        {
            Rhythm_SoundManager.instance.PlaySFX("Miss");
            print("Miss");
            col.GetComponent<Rigidbody>().Sleep();
            Rhythm_AnimalPooling.instance.ReturnObjectToPool(col.gameObject);
        }
    }
}
