using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyDead : MonoBehaviour
{
    [SerializeField] ParticleSystem explosionEffect;
    [SerializeField] BoxCollider boxCollider;
    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
        
    }

    private void OnEnable()
    {
        explosionEffect.Stop();
    }

    private void OnParticleCollision(GameObject other)
    {
        this.Dead();
    }

    protected virtual void Dead()
    {
        GameManager.Instance.SetScore();
        boxCollider.enabled = false;
        explosionEffect.Play();
        Invoke(nameof(SetActive), 0.35f);
    }

    protected virtual void SetActive()
    {
        gameObject.SetActive(false);
    }    
}
