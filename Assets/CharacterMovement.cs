using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CharacterCharacteristic))]
public class CharacterMovement : MonoBehaviour
{
    Rigidbody2D rb;
    CharacterCharacteristic characteristic;
    GameObject character;

    Vector2 newVelocity;


    void Start()
    {
        rb = gameObject.GetComponent("Rigidbody2D") as Rigidbody2D;
        character = gameObject;
        characteristic = character.GetComponent("CharacterCharacteristic") as CharacterCharacteristic;
    }
    public void Move(float direction, bool rightWall, bool leftWall) //влево dir < 0 > dir вправо
    {
        if (rightWall && direction < 0)
        {
            rb.AddForce(new Vector2(direction * (characteristic.speedWalk - (Mathf.Abs(rb.velocity.x) * 2)), 0f));
        }
        if (leftWall && direction > 0)
        {
            rb.AddForce(new Vector2(direction * (characteristic.speedWalk - (Mathf.Abs(rb.velocity.x) * 2)), 0f));
        }
        if (!rightWall && !leftWall)
        {
            rb.AddForce(new Vector2(direction * (characteristic.speedWalk - (Mathf.Abs(rb.velocity.x) * 2)), 0f));
        }

    }
    public void Move(Vector2 direction)
    {
    }
    public void Jamp(bool rightWall, bool leftWall)
    {
        Vector2 dir = new Vector2(0, 1);
        if (rightWall)
        {
            dir = new Vector2(-1, 1);
        }
        if (leftWall)
        {
            dir = new Vector2(1, 1);
        }
        if (!leftWall && !rightWall)
        {
            dir = Vector2.up;
        }
        rb.AddForce(dir * characteristic.forceJamp, ForceMode2D.Impulse);
    }
    public void Climb(float direction) //вниз dir < 0 > dir вверх лазание
    {
        rb.gravityScale = 0f;
        rb.velocity = Vector2.zero;

        character.transform.position += Vector3.up * characteristic.speedClimb * direction;

    }
    public void Climb(Vector3 direction) //лазанье в любом направлении(2д)
    {
        character.transform.position += characteristic.speedClimb * direction;
    }
}
