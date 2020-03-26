using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using Photon.Pun;
using Photon.Realtime;


namespace Com.TeslaAngel.MA
{
    public class PlayerNameInputField : MonoBehaviour
    {

        const string playerNamePrefKey = "Default";
        public TMP_InputField NameInputField;

        // Start is called before the first frame update
        void Start()
        {
            string defaultName = string.Empty;
            if (NameInputField != null)
            {
                if (PlayerPrefs.HasKey(playerNamePrefKey))
                {
                    defaultName = PlayerPrefs.GetString(playerNamePrefKey);
                    NameInputField.text = defaultName;
                }
            }


            PhotonNetwork.NickName = defaultName;


        }

        public void SetPlayerName()
        {
            // #Important
            if (string.IsNullOrEmpty(NameInputField.text))
            {
                Debug.LogError("Player Name is null or empty");
                return;
            }
            PhotonNetwork.NickName = NameInputField.text;


            PlayerPrefs.SetString(playerNamePrefKey, NameInputField.text);
        }
    }

}

