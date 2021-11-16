using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMovement))]
public class CharacterController : MonoBehaviour
{
    Rigidbody2D rb;
    CharacterCharacteristic characteristic;
    CharacterMovement characterMove;
    GameObject character;
    public float rayLen=0.02f;
    
    void Start()
    {
        rb = gameObject.GetComponent("Rigidbody2D") as Rigidbody2D;
        character = gameObject;
        characteristic = character.GetComponent("CharacterCharacteristic") as CharacterCharacteristic;
        characterMove = character.GetComponent("CharacterMovement") as CharacterMovement;
    }

    void Update()
    {
        if ((Is_Ground() || Is_RightWall() || Is_LeftWall()) && Input.GetButtonDown("Vertical"))
        {
            characterMove.Jamp(Is_RightWall(), Is_LeftWall());
        }
        /*if ((Is_RightWall() || Is_LeftWall()) && Input.GetButtonDown("Vertical"))
        {
            characterMove.Climb(Input.GetAxis("Vertical"));
            characterMove.Jamp(Is_RightWall(), Is_LeftWall());
        }*/
        else
        {
            rb.gravityScale = 1f;
        }
    }
    private void FixedUpdate()
    {
        characterMove.Move(Input.GetAxis("Horizontal"), Is_RightWall(), Is_LeftWall());
    }
    public bool Is_Ground()
    {
        bool is_ground;
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, (transform.position.y-transform.localScale.y/2-0.001f)), -Vector2.up * rayLen,rayLen);
        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y-(transform.localScale.y/2-0.001f)), -Vector2.up * rayLen, Color.yellow);
        if(hit.collider != null && hit.collider.tag == "Ground")
        {
            is_ground = true;
        }
        else
        {
            is_ground = false;
        }
        return is_ground;
    }
    public bool Is_RightWall()
    {
        bool is_rightWall;
        RaycastHit2D hit = Physics2D.Raycast(new Vector2((transform.position.x+(transform.localScale.x)/2+0.001f),transform.position.y), Vector2.right * rayLen, rayLen);
        Debug.DrawRay(new Vector2((transform.position.x+(transform.localScale.x)/2+0.001f),transform.position.y), Vector2.right * rayLen, Color.red);
        if(hit.collider != null && hit.collider.tag == "Ground")
        {
            is_rightWall = true;
        }
        else
        {
            is_rightWall = false;
        }
        
        return is_rightWall;
    }
    public bool Is_LeftWall()
    {
        bool is_leftWall;
        RaycastHit2D hit = Physics2D.Raycast(new Vector2((transform.position.x-(transform.localScale.x)/2-0.001f),transform.position.y), -Vector2.right * rayLen, rayLen);
        Debug.DrawRay(new Vector2((transform.position.x-(transform.localScale.x)/2-0.001f),transform.position.y), -Vector2.right * rayLen, Color.green);
        if(hit.collider != null && hit.collider.tag == "Ground")
        {
            is_leftWall = true;
        }
        else
        {
            is_leftWall = false;
        }
        return is_leftWall;
    }
}
