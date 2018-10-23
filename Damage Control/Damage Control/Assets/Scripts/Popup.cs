using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popup : MonoBehaviour {

    public Text messageText;

    public void SetMessage(string message)
    {
        messageText.text = message;
    }

    public void ClosePopup()
    {
        Destroy(gameObject);
    }
}
