using UnityEngine;

public class PullUp : MonoBehaviour
{
    // T = mg + ma = m(g + a)
    public float tension;
    public float mass;
    public float accel;

    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        mass = _rb.mass;
    }

    void FixedUpdate()
    {
        // T = mg + ma = m(g + a)
        tension = mass * (-Physics.gravity.y + accel);
        _rb.AddForce(Vector3.up * tension);
    }
}