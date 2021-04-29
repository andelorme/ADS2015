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
            if (photonView.IsMine == false && PhotonNetwork.IsConnected == true) return;
            rb.velocity = this.velocity * this.playerSpeed;
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