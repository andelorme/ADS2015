using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace br.unorp.ads
{
    public class PlayerController : MonoBehaviourPunCallbacks
    {
        [Tooltip("The local player instance. Use this to know if the local player is represented in the Scene")]
        public static GameObject LocalPlayerInstance;
        private float playerSpeed = 2.0f;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (photonView.IsMine == false && PhotonNetwork.IsConnected == true)
            {
                return;
            }
            var delta = Time.deltaTime * playerSpeed;
            transform.position = transform.position +
            new Vector3(delta * Input.GetAxis("Horizontal"), delta * Input.GetAxis("Vertical"), 0);
        }

        void Awake()
        {
            // #Important
            // used in GameManager.cs: we keep track of the localPlayer instance to prevent instantiation when levels are synchronized
            if (photonView.IsMine)
            {
                PlayerController.LocalPlayerInstance = this.gameObject;
            }
            // #Critical
            // we flag as don't destroy on load so that instance survives level synchronization, thus giving a seamless experience when levels load.
            DontDestroyOnLoad(this.gameObject);
        }
    }
}