using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

    [SerializeField] ParticleSystem explosion;
    [SerializeField] int hitpoints = 3;
    [SerializeField] float speed = 5f;
    [SerializeField] int scoreValue = 10;

    Scoreboard scoreboard;
    private Transform player;
    private void Awake()
    {
        explosion.Stop();
    }

    private void Start()
    {
        scoreboard = FindFirstObjectByType<Scoreboard>();        
    }

    private IEnumerator DestroyAfterParticles()
    {
        yield return new WaitForSeconds(explosion.main.duration);
        Destroy(this.gameObject);
    }
    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit(){
        hitpoints--;

        if (hitpoints <=0)
        {
            scoreboard.IncreaseScore(scoreValue);
            explosion.Play();
            StartCoroutine(DestroyAfterParticles());
        }
    }

}
