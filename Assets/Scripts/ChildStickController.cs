using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildStickController : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            gameObject.GetComponentInParent<PlayerController>().ReduceStickman();
            Destroy(gameObject);

        }
    }
}
