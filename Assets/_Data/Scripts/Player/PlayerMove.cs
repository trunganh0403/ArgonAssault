using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] protected float moveHorizontal;
    [SerializeField] protected float moveVertical; 

    [SerializeField] protected float moveSpeed = 10f;
    [SerializeField] protected float maxPosX = 10f;
    [SerializeField] protected float maxPosy = 10f;

    [SerializeField] protected int controlPitchFactor = -15;
    [SerializeField] protected int controlRollFactor = -20;
    [SerializeField] protected float positionPitchFactor =-2f;
    [SerializeField] protected float positionYawFactor = 2f;

    void Update()
    {
        this.Move();
        this.Rotation();

    }

    protected virtual void Move()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        //transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        float offsetX = moveHorizontal * Time.deltaTime * moveSpeed;
        float newPosX = transform.localPosition.x + offsetX;
        float posX = Mathf.Clamp(newPosX, -maxPosX, maxPosX);

        float offsety = moveVertical * Time.deltaTime * moveSpeed;
        float newPosy = transform.localPosition.y + offsety;
        float posY = Mathf.Clamp(newPosy, -maxPosy, maxPosy);

        transform.localPosition = new Vector3(posX, posY, transform.localPosition.z);
    }

    protected virtual void Rotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = moveVertical * controlPitchFactor;

        float pitch  = pitchDueToPosition + pitchDueToControlThrow;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = moveHorizontal * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch , yaw, roll);
    }

}
