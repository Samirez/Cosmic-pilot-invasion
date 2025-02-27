using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] ParticleSystem PlayerExplosion;

    GameSceneManager gameSceneManager;
    private void Awake()
    {
        PlayerExplosion.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("You hit " + other.name);
        PlayerExplosion.Play();
        gameSceneManager.ReloadLevel();
    }
}
