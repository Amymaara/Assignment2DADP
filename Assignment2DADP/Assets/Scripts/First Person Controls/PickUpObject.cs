using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    private Rigidbody rb;
    private Collider objCollider;
    private Transform holdPos;        
    private GameObject player;
    private bool isHeld = false;
    private int holdLayer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        objCollider = GetComponent<Collider>();
        holdLayer = LayerMask.NameToLayer("holdLayer");
    }

    private void Update()
    {
        if (isHeld && holdPos != null)
        {
            MoveObject();
        }
    }


    public void PickUp(Transform holdPoint, GameObject playerObj = null)
    {
        holdPos = holdPoint;
        player = playerObj;
        isHeld = true;

        rb.isKinematic = true;
        transform.SetParent(holdPos, true);
        gameObject.layer = holdLayer;

        if (player != null)
        {
            Collider playerCol = player.GetComponent<Collider>();
            if (playerCol != null)
            {
                Physics.IgnoreCollision(objCollider, playerCol, true);
            }
        }
    }

    public void Drop()
    {
        if (!isHeld) return;

        if (player != null)
        {
            Collider playerCol = player.GetComponent<Collider>();
            if (playerCol != null)
            {
                Physics.IgnoreCollision(objCollider, playerCol, false);
            }
        }

        gameObject.layer = 0;
        rb.isKinematic = false;
        transform.SetParent(null, true);

        isHeld = false;
        holdPos = null;
        player = null;
    }

    private void MoveObject()
    {
        transform.position = holdPos.position;
        transform.rotation = holdPos.rotation;
    }
}
