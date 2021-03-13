using UnityEngine;

public class Painting : MonoBehaviour
{
    public Rigidbody rb;
    private void OnMouseDown()
    {
        rb.useGravity = true;
        rb.isKinematic = false;
        Debug.Log("dsa");
    }
}
