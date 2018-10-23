using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupScheduler : MonoBehaviour {

    PopupManager popupManager;

    [SerializeField]
    private PopupSO turn1Popup;

    private void Awake()
    {
        popupManager = GetComponent<PopupManager>();
    }

    public void ShowPopupsForTurn(int turn)
    {
        if (turn == 1)
        {
            //popupManager.ShowPopup(turn1Popup);
            PopupManager.instance.ShowPopup(turn1Popup);
        }
    }
}
