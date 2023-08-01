using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private KeyCode up = KeyCode.UpArrow;
    [SerializeField] private KeyCode down = KeyCode.DownArrow;
    [SerializeField] private KeyCode left = KeyCode.LeftArrow;
    [SerializeField] private KeyCode right = KeyCode.RightArrow;
    private Rigidbody rb;
    private bool inTrigger = false;
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
        if (Input.GetKey(right))
            rb.MovePosition(Vector3.forward * moveSpeed * Time.deltaTime);
        if (Input.GetKey(left))
            rb.MovePosition(Vector3.back * moveSpeed * Time.deltaTime);
        if (inTrigger)
        {
            if (Input.GetKey(up))
                rb.MovePosition(Vector3.up * moveSpeed * 2f * Time.deltaTime);
            if (Input.GetKey(down))
                rb.MovePosition(Vector3.down * moveSpeed * 0.5f * Time.deltaTime);
        }
    }

    // Trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
            inTrigger = true;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Wall"))
            inTrigger = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Wall"))
            inTrigger = false;
    }
}
