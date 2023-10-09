using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovingScript : MonoBehaviour
{
    Rigidbody2D rg;

    public float speed = 3f;
    public float JumpPower = 0f;
    public bool isJump = false;
    public float ConfirmLR = 0;

    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) && !isJump)
        {
            JumpPower += 5f * Time.deltaTime;
        }
        else if(!isJump)
        {
            PlayerMove(KeyCode.LeftArrow, Vector2.left);
            PlayerMove(KeyCode.RightArrow, Vector2.right);
        }

        if (Input.GetKeyUp(KeyCode.UpArrow) && !isJump)
        {
            isJump = !isJump;
            rg.velocity = new Vector2(
                ConfirmLR * 3f,
                JumpPower);

        }


        if (rg.velocity.y == 0f && isJump)
        {
            isJump = !isJump;
            JumpPower = 0f;
        }
    }

    private void PlayerMove(KeyCode key, Vector2 vector)
    {
        if (Input.GetKey(key)) {
            transform.Translate(vector * speed * Time.deltaTime);
            ConfirmLR = (key == KeyCode.LeftArrow) ? -1 : 1;
        }
    }
}
