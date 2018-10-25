using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popup : MonoBehaviour {

    public Text messageText;

    public void UpdateAppearance(PopupSO popupSO)
    {
        messageText.text = popupSO.popupText;
        if (popupSO.popupSound != "")
        { SoundEffectManager.instance.PlayEffect(popupSO.popupSound); }
    }

    public void ClosePopup()
    {
        PopupManager.instance.PopupHasBeenClosed();
        Destroy(gameObject);
    }
}
