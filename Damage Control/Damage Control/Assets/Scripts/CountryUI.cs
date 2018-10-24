using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountryUI : MonoBehaviour {

    [SerializeField]
    private Slider friendlinessMeter;
    [SerializeField]
    private Text nameText;

	public void SetFriendliness(float friendliness)
    {
        friendlinessMeter.value = friendliness;
    }

    public void SetName(string name)
    {
        nameText.text = name;
    }
}
