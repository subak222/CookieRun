using System.Collections;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private Animator anim;

    public float JumpPower;

    public BoxCollider2D collider1;
    public BoxCollider2D collider2;
    private Rigidbody2D rigid;

    private int jumpCount = 0;
    private bool jump = true;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        anim.SetInteger("isJumping", 0);
        anim.SetBool("isSliding", false);
        anim.SetBool("isDying", false);

        collider1.enabled = true;
        collider2.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)&&jump==true)
        {
            StartCoroutine("Jump");
            rigid.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
            jumpCount++;
            jump = false;
            anim.SetInteger("isJumping", jumpCount);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            StartCoroutine("Slide");
        }
        else
        {
            anim.SetBool("isSliding", false);
            collider1.enabled = true;
            collider2.enabled = false;
        }
    }

    IEnumerator Jump()
    {
        anim.SetInteger("isJumping", 1);
        yield return new WaitForSeconds(0.1f);
    }

    IEnumerator Slide()
    {
        anim.SetBool("isSliding", true);
        collider1.enabled = false;
        collider2.enabled = true;
        yield return new WaitForSeconds(0.1f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Platform"))
        {
            jumpCount = 0;
            anim.SetInteger("isJumping", jumpCount);
            jump = true;
        }
    }
}
