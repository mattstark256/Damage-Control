using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Popup", menuName = "Popup Window", order = 1)]
public class PopupSO : ScriptableObject
{
    public string popupText;
    public Popup popupPrefab;
}
