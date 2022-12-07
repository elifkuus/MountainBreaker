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
    private Animator anim;

    private int numberChild = 0;
    private bool isFinished = false;


    private void Awake()
    {
        playerTransform = transform;

        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        countStickmans = transform.childCount - 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isFinished)
        {
            anim.SetBool("run", true);
            MovePlayer();
            numberStickmans = gameObject.GetComponentInChildren<Counter>().counterPlayer;

        }
       

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
            playerTransform.GetChild(i).localPosition = newPos;


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
        gameObject.GetComponentInChildren<Counter>().counterPlayer = playerTransform.childCount - 3;
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("FinishMountain"))
        {
            isFinished = true;
            anim.SetBool("run", false);


            for (int i = 3; i < playerTransform.childCount; i++)
            {
                Debug.Log("numberStickmans " + numberStickmans);
                gameObject.transform.GetChild(i).gameObject.SetActive(false);
            }

            if (playerTransform.childCount < 10)
            {
                gameObject.transform.localScale = Vector3.one * 1.25f;
            }
            else if (playerTransform.childCount < 50)
            {
                gameObject.transform.localScale = Vector3.one * 2f;

            }
            else
            {
                gameObject.transform.localScale = Vector3.one * 4f;

            }

        }
    }


}
