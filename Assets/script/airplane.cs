using UnityEngine;

public class airplane : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float enginepower = 20f;
    [SerializeField] float liftboosted = 0.5f;
    [SerializeField] float drag = 0.001f;
    [SerializeField] float angularDrag = 0.001f;

    [SerializeField] float yawpower = 50f;
    [SerializeField] float pitchpower = 50f;
    [SerializeField] float rollpower = 30f;

    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce (transform.forward * enginepower);
            
        }
        Vector3 lift = Vector3.Project(rb.linearVelocity, transform.forward);
        rb.AddForce(transform.up * lift.magnitude * liftboosted);
        rb.linearDamping = rb.linearVelocity.magnitude * drag;
        rb.angularDamping = rb.linearVelocity.magnitude * angularDrag;

        float yaw = Input.GetAxis("Horizontal") * yawpower;
        float pitch = Input.GetAxis ("Vertical") * pitchpower;
        float roll = Input.GetAxis("Roll") * rollpower;

        rb.AddTorque(transform.up * yaw);
        rb.AddTorque(transform.right * pitch);
        rb.AddTorque(transform.forward * roll);
    }

    void Update()
    {
        
    }
}
