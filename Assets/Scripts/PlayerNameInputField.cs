using UnityEngine;
using UnityEngine.UI;

using Photon.Pun;

namespace br.unorp.ads
{

    [RequireComponent(typeof(InputField))]
    public class PlayerNameInputField : MonoBehaviour
    {

        const string playerNamePrefKey = "PlayerName";

        void Start () {

            string defaultName = string.Empty;
            InputField _inputField = this.GetComponent<InputField>();

            if (_inputField!=null)
            {
                if (PlayerPrefs.HasKey(playerNamePrefKey))
                {
                    defaultName = PlayerPrefs.GetString(playerNamePrefKey);
                    _inputField.text = defaultName;
                }
            }
            PhotonNetwork.NickName =  defaultName;
        }

        public void SetPlayerName(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                Debug.LogError("Player Name is null or empty");
                return;
            }
            PhotonNetwork.NickName = value;
            PlayerPrefs.SetString(playerNamePrefKey,value);
        }
    }
}