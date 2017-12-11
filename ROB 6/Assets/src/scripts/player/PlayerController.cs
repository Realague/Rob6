using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/**
 * PlayerController.
 *
 * @author Rémi Wickuler
 * @author Julien Delane
 * @version 17.11.19
 * @since 17.10.10
 */
public class PlayerController : MonoBehaviour
{
    /**
     * Player.
     *
     * @since 17.10.10
     */
    private Rigidbody2D rigidBody;

    /**
     * Right foot.
     *
     * @since 17.10.10
     */
    private Transform groundCheckRight;

    /**
     * Left foot.
     *
     * @since 17.10.10
     */
    private Transform groundCheckLeft;

    /**
     * If the player jump.
     *
     * @since 17.10.10
     */
    private bool jump;

    /**
     * If the player is on the ground.
     *
     * @since 17.10.10
     */
    private bool grounded = true;

    /**
     * The number of jump the has done without hit the ground.
     *
     * @unityParam
     * @since 17.10.10
     */
    [SerializeField]
    private int jumpCount;

    /**
     * Jump force.
     *
     * @unityParam
     * @since 17.10.10
     */
    [SerializeField]
    private float jumpForce = 1.0F;

    /**
     * Player speed.
     *
     * @unityParam
     * @since 17.10.10
     */
    [SerializeField]
    private float speed = 1.0F;

    /**
     * Jump speed.
     *
     * @unityParam
     * @since 17.10.10
     */
    [SerializeField]
    private float jumpSpeed = 1.0F;

    /**
     * Number of jump the player can performed without hit the ground.
     *
     * @unityParam
     * @since 17.10.10
     */
    [SerializeField]
    private int maxJump = 2;

    /**
     * Define which layer is ground.
     *
     * @unityParam
     * @since 17.10.10
     */
    [SerializeField]
    private LayerMask whatIsGround;

    /**
     * List of sound we can play when he walk jump etc.
     *
     * @unityParam
     * @since 17.10.10
     */
    [SerializeField]
    private AudioClip[] sounds;

    /**
     * Define if the player is facing right or left.
     *
     * @unityParam
     * @since 17.10.10
     */
    public static bool facingRight = true;

    /**
     * The direction the player move.
     *
     * @unityParam
     * @since 17.10.10
     */
    [SerializeField]
    private static float x;

    /**
     * Animator.
     *
     * @unityParam
     * @since 17.10.10
     */
    public static Animator anim;

    /**
     * Define if the player is alive.
     *
     * @unityParam
     * @since 17.10.10
     */
    public static bool death = false;

    /**
     * The number of scrap the player got.
     *
     * @unityParam
     * @since 17.10.10
     */
    [SerializeField]
    private Text nbScrap;

    private int nb = 0;
    public static GameObject fly;
    public GameObject[] robH;

    /**
     * Define if the player can run.
     *
     * @since 17.10.10
     */
    private bool run = false;
    public static bool stop = false;

    /**
     * The multiplicator for the second jump 
     *
     * @since 17.10.30   
     */

    private float mult;

    /**
     * Init the variable at the beginning of the level.
     *
     * @since 17.10.10
     */
    private void Start()
    {
        fly = null;
        jumpCount = 0;
        jump = false;
        facingRight = true;
        groundCheckRight = transform.Find("GroundCheckLeft");
        groundCheckLeft = transform.Find("GroundCheckRight");
        rigidBody = GetComponent<Rigidbody2D>();
    }

    /**
     * Do all the player action when he pressed the associated key.
     *
     * @since 17.10.10
     */
    private void Update()
    {
        if (stop == false)
        {
            nb = 0;
            if (PlayerManager.inventory[transform.name] != null)
            {
                nb = PlayerManager.inventory[transform.name].Count;
            }
            nbScrap.text = "= " + nb.ToString();
            if (Input.GetKey(KeyCode.D))
            {
                x = 1;
                run = true;
                facingRight = true;
            }
            else if (Input.GetKey(KeyCode.A))
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
            if (transform.name.CompareTo("Rob.I") == 0 || transform.name.CompareTo("Rob.B") == 0 || transform.name.CompareTo("Rob.6") == 0 )
            {
                anim.SetBool("run", run);
            }
            if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2)
            {
                jump = true;
            }
            else
            {
                jump = false;
            }
            if (facingRight == true && transform.localScale.x < 0)
            {
                flip();
            }
            if (facingRight == false && transform.localScale.x > 0)
            {
                flip();
            }
            if (jump == true)
            {
                transform.rotation = new Quaternion(0, 0, 0, 0);
            }
            if (transform.name.CompareTo("Rob.L") == 0)
            {
                takeRobH();
            }
        }
    }

    /**
     * Init the variable at the beginning of the level.
     *
     * @since 17.10.10
     */
    private void takeRobH()
    {
        float closer = 100;
        GameObject stock = null;

        if (Input.GetKeyDown(KeyCode.F))
        {
            foreach (GameObject rob in robH)
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

    /**
     * Flip the player sprite if the direction change.
     *
     * @since 17.10.10
     */
    private void flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        if (PlayerManager.stock != null)
        {
            theScale = PlayerManager.stock.transform.localScale;
            theScale.x *= -1;
            PlayerManager.stock.transform.localScale = theScale;
        }
    }

    /**
     * Jump management.
     *
     * @since 17.10.10
     * @update 17.10.30
     */
    private void FixedUpdate()
    {
        if (stop == false)
        {
            //check if the player is on the ground\\
            grounded = Physics2D.Linecast(groundCheckLeft.position, groundCheckRight.position, whatIsGround);
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
                if (jumpCount == 1)
                    mult = 1.4f;
                else
                    mult = 1;
                rigidBody.AddForce(new Vector2(0, 100 * jumpForce * mult));
                jumpCount++;
            }

            //anim.SetBool("jump", grounded);
            //anim.SetFloat("Speed", Mathf.Abs(x));
        }
    }

    /**
     * If the ground is not flat rotate the rob to match with the ground rotation.
     *
     * @param collision ground
     * @since 17.10.10
     */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.CompareTo("ground") == 0)
        {
            transform.rotation = new Quaternion(collision.transform.rotation.x, collision.transform.rotation.y, collision.transform.rotation.z, collision.transform.rotation.w);
        }
    }

    /**
     * Ignore collision with scrap.
     *
     * @param collider scrap
     * @since 17.10.10
     */
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag.CompareTo("scrap") == 0)
        {
             Physics2D.IgnoreCollision(this.gameObject.GetComponent<BoxCollider2D>(), collider.GetComponent<PolygonCollider2D>(), true);
        }
    }

    /**
     * Get the scrap if the player collide with it and press the action key.
     *
     * @param collider scrap
     * @since 17.10.10
     */
    private void OnTriggerStay2D(Collider2D collider)
    {
        if (PlayerManager.current == this.gameObject)
        {
            if (collider.gameObject.tag.CompareTo("scrap") == 0 && Input.GetKeyDown(KeyCode.F))
            {
                Physics2D.IgnoreCollision(this.gameObject.GetComponent<BoxCollider2D>(), collider.GetComponent<PolygonCollider2D>(), true);
                if (PlayerManager.inventory[transform.name] == null)
                {
                    PlayerManager.inventory[transform.name] = new List<GameObject>();
                }
                PlayerManager.inventory[transform.name].Add(collider.gameObject);
                collider.gameObject.SetActive(false);
            }
        }
    }

    /**
     * If the ground is not flat rotate the rob to match with the ground rotation.
     *
     * @param collision ground
     * @since 17.10.10
     */
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (PlayerManager.current == this.gameObject)
        {
            if (collision.gameObject.tag.CompareTo("ground") == 0)
            {
                transform.rotation = new Quaternion(collision.transform.rotation.x, collision.transform.rotation.y, collision.transform.rotation.z, collision.transform.rotation.w);
            }
            else if (collision.gameObject.tag.CompareTo("door") == 0)
            {
                transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, (collision.transform.rotation.z + 0.4f) * -1, transform.rotation.w);
            }
        }
    }

}