using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] protected List<Transform> bullets;

    private void Start()
    {
        this.LoadBullet(false);
    }
    private void Update()
    {
        this.OnClick();
    }

    protected virtual void OnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.LoadBullet(true);
        }

        if (Input.GetMouseButtonUp(0))
        {
            this.LoadBullet(false);
        }
    }

    protected virtual void LoadBullet(bool isShooting)
    {
        foreach (Transform bullet in bullets)
        {
            var particle = bullet.GetComponent<ParticleSystem>().emission;
            particle.enabled = isShooting;
        }
    }    
}
