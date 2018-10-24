﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountryUI : MonoBehaviour {

    [SerializeField]
    private Slider friendlinessMeter;
    [SerializeField]
    private Text nameText;
    [SerializeField]
    private Image meterImage;
    [SerializeField]
    private float goodHue = 0.33f;
    [SerializeField]
    private float badHue = 0f;

	public void SetFriendliness(float friendliness)
    {
        friendlinessMeter.value = friendliness;
        meterImage.color = Color.HSVToRGB(Mathf.Lerp(badHue, goodHue, friendliness / friendlinessMeter.maxValue), 1, 1);
    }

    public void SetName(string name)
    {
        nameText.text = name;
    }
}
