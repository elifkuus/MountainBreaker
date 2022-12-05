using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Counter : MonoBehaviour
{
    public TextMeshPro textCounter;

    public int counterPlayer;

    // Start is called before the first frame update
    private void Start()
    {
        counterPlayer = 1;

    }

    // Update is called once per frame
    void Update()
    {

        textCounter.text = counterPlayer.ToString();

    }
}
