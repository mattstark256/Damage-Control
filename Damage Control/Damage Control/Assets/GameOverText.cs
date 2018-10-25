using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This overrides the popup text to change it based on the game outcome
public class GameOverText : MonoBehaviour
{
    [SerializeField]
    private Text gameOverMessage;

    [SerializeField, TextArea(5, 20)]
    private string winMessage1;
    [SerializeField, TextArea(5, 20)]
    private string winMessage2;
    [SerializeField, TextArea(5, 20)]
    private string winMessage3;
    [SerializeField, TextArea(5, 20)]
    private string loseMessage;

    // Use this for initialization
    void Start()
    {
        int hostileCountries = GameController.instance.GetHostileCountryCount();
        if (hostileCountries == 0)
        { gameOverMessage.text = winMessage1; }
        if (hostileCountries == 1)
        { gameOverMessage.text = winMessage2; }
        if (hostileCountries == 2)
        { gameOverMessage.text = winMessage3; }
        if (hostileCountries >= 3)
        { gameOverMessage.text = loseMessage; }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
