using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    [SerializeField] int hitPoints = 10;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    void ProcessHit()
    {
        hitPoints--;
        if (hitPoints < 1)
        {
            Destroy(gameObject);
        }
    }

}
