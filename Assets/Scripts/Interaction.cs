using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TiltFive;
using UnityEngine.InputSystem;

public class Interaction : MonoBehaviour
{
    private GameObject mallet;
    private bool triggered;
    private Rigidbody rb;
    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distCovered = (Time.time - startTime);
        if(TiltFive.Wand.TryGetWandDevice(TiltFive.PlayerIndex.One, TiltFive.ControllerIndex.Right, out TiltFive.WandDevice wandDevice))
        {
            if(wandDevice.Trigger.IsPressed())
            {
                Vector3 tempPos =  rb.transform.position;
                Vector3 newPos = new Vector3(this.rb.transform.position.x, 1, this.rb.transform.position.z);
                rb.transform.position = Vector3.Lerp(tempPos,  newPos, distCovered );
            }
        }
    }
    private void OnTriggerEnter(Collider other) {
        mallet = other.gameObject;
        rb = other.GetComponent<Rigidbody>();
        triggered = true;
}
}
