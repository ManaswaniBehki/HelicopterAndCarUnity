using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class helicopterscript : MonoBehaviour {
    private Rigidbody rigidbody;
    [SerializeField] private float responsive = 500f;
    [SerializeField] private float throttleamt = 25f;

    private float throttle;

    private float _roll;
    private float _pitch;
    private float _yaw;
    
    [SerializeField] private float rotormodifier  = 10f;
    [SerializeField] private Transform rotortransform;


    private void Awake() {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update() {
        HandleInputs();

        rotortransform.Rotate(Vector3.up*throttle*rotormodifier);
    }

    private void FixedUpdate() {
         // Apply forward, left, and right movement forces based on _pitch and _yaw.
    Vector3 forwardForce = transform.forward * _pitch * responsive;
    Vector3 lateralForce = transform.right * _yaw * responsive;

    rigidbody.AddForce(forwardForce);
    rigidbody.AddForce(lateralForce);

    // Apply torque for rolling.
    rigidbody.AddTorque(transform.forward * _roll * responsive);

    // Apply upward force for throttle.
    rigidbody.AddForce(transform.up * throttle, ForceMode.Impulse);
    
    }

    private void HandleInputs() {
        _roll = Input.GetAxis("roll");
        _pitch = Input.GetAxis("pitch");
        _yaw = Input.GetAxis("yaw");

        if (Input.GetKey(KeyCode.Space)) {
            throttle += Time.deltaTime * throttleamt;
        } else if (Input.GetKey(KeyCode.LeftShift)) {
            throttle -= Time.deltaTime * throttleamt;
        }
        else {
        // Apply a downward force to counteract upward motion (simulating gravity).
        // You can adjust the magnitude of this force based on your requirements.
        float gravityForce = 9.81f * rigidbody.mass; // You can adjust the value 9.81f as needed.

        // Apply the downward force to counteract upward motion.
        rigidbody.AddForce(Vector3.down * gravityForce, ForceMode.Force);
    }

        throttle = Mathf.Clamp(throttle, 0f, 100f);
    }
}
