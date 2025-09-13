using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

// Title: How to Pick Up and Drop Objects in Unity
// Author: Hayes, A
// Date: 09/08/2025
// Avalability: DIGA2001A Lecture Slides
public class PickUpController : MonoBehaviour
{
    [Header("Hold Settings")]
    public Transform holdPos;
    public string holdLayerName = "holdLayer";

    private GameObject heldObject;
    private Rigidbody heldObjectRb;
    private GameObject playerRef;
    private int holdLayer;

    void Start()
    {
        holdLayer = LayerMask.NameToLayer(holdLayerName);
    }

    void Update()
    {
        if (heldObject != null)
        {
            MoveObject();
            StopClipping();
        }
    }

    public bool IsHolding => heldObject != null;

    public void TryPickUp(GameObject target, Transform holdPointTransform, GameObject player)
    {
        if (target == null || heldObject != null) return; // if no target or already holding an object, return
        if (!target.CompareTag("canPickUp")) return;

        if (!target.TryGetComponent<Rigidbody>(out Rigidbody Rb)) return; // if no rigidbody, return
        if (!target.TryGetComponent<Collider>(out Collider objcol)) return; // if no collider, return
        if (!player.TryGetComponent<Collider>(out Collider playercol)) return; // if no collider, return

        playerRef = player;
        heldObject = target; // set the held object
        heldObjectRb = Rb; // set the rigidbody

        if (holdPos == null) holdPos = holdPointTransform; // if no hold position, use the provided one
        else holdPos = holdPointTransform;

        heldObjectRb.isKinematic = true; // make the object kinematic
        heldObject.transform.SetParent(holdPos); // set the parent to the hold position
        heldObject.transform.localPosition = Vector3.zero; // reset local position
        heldObject.transform.localRotation = Quaternion.identity; // reset local rotation

        if (holdLayer >= 0) heldObject.layer = holdLayer; // change layer to hold layer
        Physics.IgnoreCollision(objcol, playercol, true); // ignore collision with player
    }

    public void Drop()
    {
        if (heldObject == null) return; // if no object is held, return

        var objCollider = heldObject.GetComponent<Collider>();
        var playerCollider = playerRef != null ? playerRef.GetComponent<Collider>() : null;
        if (objCollider != null && playerCollider != null)
        {
            Physics.IgnoreCollision(objCollider, playerCollider, false); // re-enable collision with player
        }

        heldObject.layer = 0;
        heldObjectRb.isKinematic = false; // make the object non-kinematic
        heldObject.transform.SetParent(null); // remove parent

        heldObject = null; // clear the held object
        heldObjectRb = null;
        playerRef = null;
    }

    private void MoveObject()
    {
        heldObject.transform.position = holdPos.transform.position; // move the object to the hold position
    }

    private void StopClipping()
    {
        float clipRange = Vector3.Distance(heldObject.transform.position, transform.position);
        RaycastHit[] hits = Physics.RaycastAll(transform.position, transform.TransformDirection(Vector3.forward), clipRange);

        if (hits.Length > 1)
        {
            heldObject.transform.position = transform.position + new Vector3(0f, -0.5f, 0f); // move the object to the hold position
        }
    }

}
