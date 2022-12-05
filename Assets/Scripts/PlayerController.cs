using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float speed = 5f;
    [SerializeField] private float speedDirection = 5f;

    [SerializeField] private TextMeshPro counterText;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private GameObject stickman;


    [SerializeField] private int countStickmans; //child count
    public int numberStickmans; //counter count

    [Range(0f, 1f)] [SerializeField] private float DistanceFactor, Radius; // for player clones


    private Rigidbody rb;


    private int numberChild = 0;


    void Start()
    {
        playerTransform = transform;

        rb = GetComponent<Rigidbody>();
        countStickmans = transform.childCount - 2;


    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        numberStickmans = gameObject.GetComponentInChildren<Counter>().counterPlayer;

    }
    public void MovePlayer()
    {
        float xMove = Input.GetAxis("Horizontal") * Time.deltaTime * speedDirection;
        float zMove = speed * Time.deltaTime;

        transform.position += new Vector3(xMove, 0f, zMove);
    }

    public void FormatStickman() // Circle format 
    {
        for (int i = 3; i < playerTransform.childCount; i++)
        {
            float x = DistanceFactor * Mathf.Sqrt(i) * Mathf.Cos(i * Radius);
            float z = DistanceFactor * Mathf.Sqrt(i) * Mathf.Sin(i * Radius);

            Vector3 newPos = new Vector3(x, 0f, z);
            playerTransform.GetChild(i).localPosition=newPos;


        }
    }

    private void AddStickman(int number)
    {
        for (int i = 0; i < number; i++)
        {
            Instantiate(stickman, transform.position - transform.forward, Quaternion.identity, transform);
        }
        FormatStickman();

    }
    public void ReduceStickman()
    {
        gameObject.GetComponentInChildren<Counter>().counterPlayer -= 1;
        FormatStickman();
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Gate"))
        {
            numberChild = numberStickmans - countStickmans;

            AddStickman(numberChild);

        }
    }


}
