using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;
    [SerializeField] int hitPoints = 20;

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
            var death = Instantiate<ParticleSystem>(deathParticlePrefab, transform.position, Quaternion.identity);
            death.Play();
            Destroy(gameObject);
        }
        else
        {
            hitParticlePrefab.Play();
        }
    }

}
