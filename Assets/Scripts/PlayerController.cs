using UnityEngine;
using Photon.Pun;

namespace br.unorp.ads
{
    public class PlayerController : MonoBehaviourPunCallbacks
    {
        public static GameObject LocalPlayerInstance;
        public float playerSpeed = 4.0f;
        private Rigidbody2D rb;
        public Vector2 velocity;
        private bool facingRight = true;

        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            if (photonView.IsMine == false && PhotonNetwork.IsConnected == true) return;

            velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            velocity.Normalize();
        }

        void FixedUpdate()
        {
            float  h = Input.GetAxisRaw("Horizontal");
            if (photonView.IsMine == false && PhotonNetwork.IsConnected == true) return;
            rb.velocity = this.velocity * this.playerSpeed;
            if(h > 0 && !facingRight)
            {
                Flip();
            }
            else if(h < 0 && facingRight)
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

        void Awake()
        {
            if (photonView.IsMine)
            {
                PlayerController.LocalPlayerInstance = this.gameObject;
            }
        }
    }
}