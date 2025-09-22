using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class InteractUI : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] TMP_Text promptText;
    [SerializeField] float range = 3f;
    [SerializeField] private LayerMask layer;
    [SerializeField] private InputActionReference pickupAction;
  



    private void Update()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        


        if (Physics.Raycast(ray, out RaycastHit hit, range, layer))
        {
            string objName = hit.collider.gameObject.name.Replace("(Clone)", "").Trim(); 
            string Key = pickupAction.action.GetBindingDisplayString();

            promptText.gameObject.SetActive(true);
            promptText.text = $"{Key} to interact with {objName}";


            if (pickupAction.action.triggered)
            {
                Debug.Log("Interacted with item");
            }

        }

       
        else
        {
            promptText.gameObject.SetActive(false);
        }
           
    }

}
