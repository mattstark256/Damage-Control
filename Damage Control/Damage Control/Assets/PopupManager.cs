using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupManager : MonoBehaviour
{
    public static PopupManager instance;
    private void Awake()
    {
        if (instance == null) { instance = this; }
    }

    public Transform popupParent;

    public void ShowPopup(PopupSO popupSO)
    {
        Popup newPopup = Instantiate(popupSO.popupPrefab);
        newPopup.transform.SetParent(popupParent, false);
        newPopup.transform.SetAsFirstSibling();
        newPopup.SetMessage(popupSO.popupText);
    }
}
