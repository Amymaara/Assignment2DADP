using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class EtoInteract : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] TMP_Text promptText;
    [SerializeField] float range = 3f;
    [SerializeField] private LayerMask layer;
    [SerializeField] private InputActionReference interactAction;




    private void Update()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);



        if (Physics.Raycast(ray, out RaycastHit hit, range, layer))
        {
            string objName = hit.collider.gameObject.name;
            string interactKey = interactAction.action.GetBindingDisplayString();

            promptText.gameObject.SetActive(true);
            promptText.text = $"{interactKey} to interact with {objName}";


            if (interactAction.action.triggered)
            {
                Debug.Log("Interacted with cat");
            }

        }


        else
        {
            promptText.gameObject.SetActive(false);
        }

    }
}