using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {

        // Aim variabeles
        public bool VisibleAimCursor = true;
        GameObject aim;

        // Teleport variables
        public float TeleportationDistance;
        public bool TeleportEnabled = true;

        public float TeleportRate;
        private float nextTeleport = 0;

        public GameObject SmokePS;

        // Movement variables
        public float MaxSpeed;

        // Jumping variable
        //public AudioClip JumpClip;
        private bool grounded = false;

        private float groundCheckRadius = 0.2f;
        public LayerMask GroundLayer;
        public Transform GroundCheck;
        public float JumpHeight;

        private Rigidbody2D myRB;
        private Animator myAnim;
        private bool facingRight;

        // Use this for initialization
        void Start()
        {
            myRB = GetComponent<Rigidbody2D>();
            myAnim = GetComponent<Animator>();

            aim = transform.Find("Aim").gameObject;

            facingRight = true;
        }

        // Update is called once per frame
        void Update()
        {
            // Jump
            if (grounded && Input.GetKeyDown(KeyCode.Space))
            {
                grounded = false;
                myAnim.SetBool("isGrounded", grounded);
                myRB.AddForce(new Vector2(0, JumpHeight));

                GetComponent<RichUnity.Audio.SoundSource>().PlaySound();
            }

        }

        void FixedUpdate()
        {
            float horisontalAxis = Input.GetAxis("Horizontal");
            float verticalAxis = Input.GetAxis("Vertical");

            // Check on collision with Mobile Enemy and destroy this enemy
            Collider2D enemyCollision = Physics2D.OverlapCircle
                (TeleportCoordinates(horisontalAxis, verticalAxis), 0.1f,
                1 << LayerMask.NameToLayer("Mobile Enemy"));
                // Check on other collision
            Collider2D collision = Physics2D.OverlapCircle
                (TeleportCoordinates(horisontalAxis, verticalAxis), 0.1f);

            // Teleportation
            if (grounded && Input.GetButton("Fire1")
                && Time.time > nextTeleport && TeleportEnabled)
            {
                nextTeleport = Time.time + TeleportRate;

                if (enemyCollision != null)
                {
                    Destroy(enemyCollision.gameObject);
                    Instantiate(SmokePS, transform.position, transform.rotation);
                    Instantiate(SmokePS, TeleportCoordinates(horisontalAxis, verticalAxis), transform.rotation);
                    myRB.transform.position = TeleportCoordinates(horisontalAxis, verticalAxis);
                }
                else if (collision == null)
                {
                    Instantiate(SmokePS, transform.position, transform.rotation);
                    Instantiate(SmokePS, TeleportCoordinates(horisontalAxis, verticalAxis), transform.rotation);
                    myRB.transform.position = TeleportCoordinates(horisontalAxis, verticalAxis);
                }


            }

            // Aim
            if (!VisibleAimCursor || !grounded)
            {
                aim.GetComponent<SpriteRenderer>().enabled = false;
            }                
            else if (horisontalAxis != 0|| verticalAxis != 0)
            {

                if (collision == null || enemyCollision != null)
                {
                    aim.transform.position = TeleportCoordinates(horisontalAxis, verticalAxis);
                    aim.GetComponent<SpriteRenderer>().enabled = true;
                }
                else
                {
                    aim.GetComponent<SpriteRenderer>().enabled = false;
                }

            }          


            // Check if we are grounded if no, then we are falling
            grounded = Physics2D.OverlapCircle(GroundCheck.position, groundCheckRadius, GroundLayer);
            myAnim.SetBool("isGrounded", grounded);

            myAnim.SetFloat("verticalSpeed", myRB.velocity.y);

            myAnim.SetFloat("speed", Mathf.Abs(horisontalAxis));

            myRB.velocity = new Vector2(horisontalAxis * MaxSpeed, myRB.velocity.y);

            if (horisontalAxis > 0 && !facingRight)
            {
                Flip();
            }
            else if (horisontalAxis < 0 && facingRight)
            {
                Flip();
            }

        }

        void Flip()
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }

        void OnCollisionEnter2D(Collision2D other)
        {
            if (other.transform.tag == "MovingPlatform")
            {
                transform.parent = other.transform;
            }
        }

        void OnCollisionExit2D(Collision2D other)
        {
            if (other.transform.tag == "MovingPlatform")
            {
                transform.parent = null;
            }
        }

        private Vector2 TeleportCoordinates(float horisontalAxis, float verticalAxis)
        {
            float positionX = myRB.position.x;
            float positionY = myRB.position.y;

            if (horisontalAxis > 0)
            {
                positionX += TeleportationDistance;
            }
            else if (horisontalAxis < 0)
            {
                positionX -= TeleportationDistance;
            }
            if (verticalAxis > 0)
            {
                positionY += TeleportationDistance;
            }
            else if (verticalAxis < 0)
            {
                positionY -= TeleportationDistance;
            }
            return new Vector2(positionX, positionY);
        }
    }
}