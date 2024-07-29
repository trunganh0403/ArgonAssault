using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] ParticleSystem explosionEffect;
    [SerializeField] PlayerMove playerMove;
    private void Start()
    {
        explosionEffect.Stop();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Enemy") return;
        this.Dead();
    }

    protected virtual void Dead()
    {
        explosionEffect.Play();
        playerMove.enabled = false;
        Invoke(nameof(ReloadLevel), 1f);
    }
    protected virtual void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
