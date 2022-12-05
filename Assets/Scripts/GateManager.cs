using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GateManager : MonoBehaviour
{
    public TextMeshPro gateNumber;
    public int randomNumber;

    public bool calculateState; // true-> multiply or false-> sum

    void Start()
    {
        randomNumber = Random.Range(1, 3);

        if (randomNumber > 1)
            calculateState = true;
        else
            calculateState = false;

        if (calculateState) //multiply
        {
            randomNumber = Random.Range(1, 4);
            gateNumber.text = "x" + randomNumber.ToString();

        }
        else //sum
        {
            randomNumber = Random.Range(10, 50);
            gateNumber.text = "+" + randomNumber.ToString();

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (calculateState)
            {
                if (randomNumber == 1)
                {
                    return;
                }
                else
                {
                    other.GetComponentInChildren<Counter>().counterPlayer *= randomNumber;

                }

            }
            else
            {
                other.GetComponentInChildren<Counter>().counterPlayer += randomNumber;
               
            }


        }
    }

}
