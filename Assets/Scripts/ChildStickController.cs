using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildStickController : MonoBehaviour
{

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            gameObject.GetComponentInParent<PlayerController>().ReduceStickman();
            Destroy(gameObject);
        }

    }


    public void FinishedDestroy()
    {
        Destroy(gameObject);
    }
}
