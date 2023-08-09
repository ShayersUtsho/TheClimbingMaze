using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private KeyCode up = KeyCode.UpArrow;
    [SerializeField] private KeyCode down = KeyCode.DownArrow;
    [SerializeField] private KeyCode left = KeyCode.LeftArrow;
    [SerializeField] private KeyCode right = KeyCode.RightArrow;
    public bool win = false;
    private Rigidbody rb;
    private bool inTrigger = false;
    [SerializeField] private Transform winMessage;
    [SerializeField] private float winMessageMoveDuration = 0f;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {
        if (!win)
        {
            if (Input.GetKey(right))
                rb.MovePosition(rb.position + Vector3.forward * moveSpeed * Time.deltaTime);
            if (Input.GetKey(left))
                rb.MovePosition(rb.position + Vector3.back * moveSpeed * Time.deltaTime);
            if (inTrigger)
            {
                if (Input.GetKey(up))
                    rb.MovePosition(rb.position + Vector3.up * moveSpeed * 2f * Time.deltaTime);
                if (Input.GetKey(down))
                    rb.MovePosition(rb.position + Vector3.down * moveSpeed * 0.5f * Time.deltaTime);
            }
        }
        else if(winMessageMoveDuration < 5f)
        {
            winMessage.Translate(Vector3.right * Time.deltaTime);
            winMessageMoveDuration += 1f * Time.deltaTime;
        }
        else
        {
            
        }
    }

    // Trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Updraft"))
            inTrigger = true;
        if (other.CompareTag("Goal"))
            win = true;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Updraft"))
            inTrigger = true;
        if (other.CompareTag("Goal"))
            win = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Updraft"))
            inTrigger = false;
    }
}
