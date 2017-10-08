using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform groundCheck;
    private Transform groundCheck2;
    private bool jump;
    private bool grounded = true;
    public int jumpCount;
    public float jumpForce = 1.0F;
    public float speed = 1.0F;
    public float jumpspeed = 1.0F;
    public int maxJump = 2;
    public LayerMask whatIsGround;
    public AudioClip[] sounds;
    public static bool facingRight = true;
    public static float x;
    public static Animator anim;
    public static bool death = false;
    public Text nbScrap;
    private int nb = 0;
    public static GameObject fly;
    public GameObject[] rob_H;
    private bool run = false;
    public static bool stop = false;

    // Use this for initialization
    void Start()
    {
        fly = null;
        jumpCount = 0;
        jump = false;
        facingRight = true;
        groundCheck = transform.Find("GroundCheck");
        groundCheck2 = transform.Find("GroundCheck2");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (stop == false)
        {
            nb = 0;
            if (cursor.inventory[transform.name] != null)
            {
                nb = cursor.inventory[transform.name].Count;
            }
            nbScrap.text = "= " + nb.ToString();
            if (Input.GetKey(KeyCode.D))
            {
                x = 1;
                run = true;
                facingRight = true;
            }
            else if (Input.GetKey(KeyCode.Q))
            {
                x = -1;
                facingRight = false;
                run = true;
            }
            else
            {
                x = 0;
                run = false;
            }
            if (transform.name == "Rob.I" || transform.name == "Rob.B")
            {
                anim.SetBool("run", run);
            }
            if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2)
                jump = true;
            else
                jump = false;
            if (facingRight == true && transform.localScale.x < 0)
                Flip();
            if (facingRight == false && transform.localScale.x > 0)
                Flip();
            if (jump == true)
                transform.rotation = new Quaternion(0, 0, 0, 0);
            if (transform.name == "Rob.L")
                takeRob_H();
        }
    }

    void takeRob_H()
    {
        float closer = 100;
        GameObject stock = null;

        if (Input.GetKeyDown(KeyCode.F))
        {
            foreach (GameObject rob in rob_H)
            {
                if (Vector2.Distance(transform.position, rob.transform.position) < closer)
                {
                    closer = Vector2.Distance(transform.position, rob.transform.position);
                    stock = rob;
                }
            }
            if (stock != null && closer <= 3)
            {
                fly = stock;
                stock.SetActive(false);
            }
        }
    }
    
    void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        if (cursor.stock != null)
        {
            theScale = cursor.stock.transform.localScale;
            theScale.x *= -1;
            cursor.stock.transform.localScale = theScale;
        }
    }


    void FixedUpdate()
    {
        if (stop == false)
        {
            //check if the player is on the ground\\
            grounded = Physics2D.Linecast(groundCheck2.position, groundCheck.position, whatIsGround);
            if (grounded)
            {
                jumpCount = 0;
                //anim.SetBool("space", true);
            }
            /*else
                anim.SetBool("space", false);*/

            //move in the x axis\\
            transform.Translate(new Vector2(x, 0) * Time.deltaTime * speed);
            //if spacebar is pressed and the player can jump do a jump\\
            if (jump == true && jumpCount < maxJump)
            {
                rb.AddForce(new Vector2(0, 100 * jumpForce));
                jumpCount++;
            }

            //anim.SetBool("jump", grounded);
            //anim.SetFloat("Speed", Mathf.Abs(x));
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "ground")
        {
            transform.rotation = new Quaternion(coll.transform.rotation.x, coll.transform.rotation.y, coll.transform.rotation.z, coll.transform.rotation.w);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "scrap")
             Physics2D.IgnoreCollision(this.gameObject.GetComponent<BoxCollider2D>(), coll.GetComponent<PolygonCollider2D>(), true);
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if (cursor.current == this.gameObject)
        {
            if (coll.gameObject.tag == "scrap" && Input.GetKeyDown(KeyCode.F))
            {
                Physics2D.IgnoreCollision(this.gameObject.GetComponent<BoxCollider2D>(), coll.GetComponent<PolygonCollider2D>(), true);
                if (cursor.inventory[transform.name] == null)
                {
                    cursor.inventory[transform.name] = new List<GameObject>();
                }
                cursor.inventory[transform.name].Add(coll.gameObject);
                coll.gameObject.SetActive(false);
            }
        }
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        if (cursor.current == this.gameObject)
        {
            if (coll.gameObject.tag == "ground")
            {
                transform.rotation = new Quaternion(coll.transform.rotation.x, coll.transform.rotation.y, coll.transform.rotation.z, coll.transform.rotation.w);
            }
            else if (coll.gameObject.tag == "door")
            {
                
                transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, (coll.transform.rotation.z + 0.4f) * -1, transform.rotation.w);
            }
        }
    }
}