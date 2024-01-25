using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pip : MonoBehaviour
{
    Ray ray;
    RaycastHit hitData;
    private GameObject selectedObject;
    private Vector3 mousePosition;
    private Vector3 initialObjectPosition;

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hitData, 1000) && Input.GetMouseButton(0))
        {
            if (selectedObject == null && hitData.transform.gameObject.tag == "pip")
            {
                selectedObject = hitData.transform.gameObject;
            }
            mousePosition = hitData.point;
            if (selectedObject)
            {
                movePip(selectedObject, mousePosition);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            selectedObject = null;
        }
    }

    private void movePip(GameObject selectedObject, Vector3 mousePosition)
    {
        // Update the object's position based on the mouse movement
        selectedObject.transform.position = Vector3.MoveTowards(selectedObject.transform.position, new Vector3(mousePosition.x, selectedObject.transform.position.y, mousePosition.z), 500f * Time.deltaTime);
    }
}
