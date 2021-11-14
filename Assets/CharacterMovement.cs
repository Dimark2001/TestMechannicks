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
            character.transform.position += Vector3.right * characteristic.speedWalk * direction;
        }
        if (leftWall && direction > 0)
        {
            character.transform.position += Vector3.right * characteristic.speedWalk * direction;
        }
        if(!rightWall && !leftWall)
        {
            character.transform.position += Vector3.right * characteristic.speedWalk * direction;
        }
        
    }
    public void Move(Vector3 direction)
    {
        character.transform.position += characteristic.speedWalk * direction;
    }
    public void Jamp()
    {
        rb.AddForce(Vector2.up * characteristic.forceJamp, ForceMode2D.Impulse);
    }
    public void Climb(float direction) //вниз dir < 0 > dir вверх
    {
        rb.gravityScale = 0;
        character.transform.position += Vector3.up * characteristic.speedClimb * direction;
    }
    public void Climb(Vector3 direction) //лазанье в любом направлении(2д)
    {
        character.transform.position += characteristic.speedClimb * direction;
    }

}
