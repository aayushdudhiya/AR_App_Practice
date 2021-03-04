using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARObjectPlacement : MonoBehaviour
{

    public ARSessionOrigin origin;
    public List<ARRaycastHit> raycasthits = new List<ARRaycastHit>();
    public GameObject cube;
    GameObject instantiatedCube;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Detect touch
        // project raycast
        // instantiate a virtual cube


        if (Input.GetMouseButton(0))
        {
            bool collision = origin.GetComponent<ARRaycastManager>().Raycast(Input.mousePosition, raycasthits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon);
            
            if(collision)
            {
                if(instantiatedCube == null)
                {
                    instantiatedCube = Instantiate(cube);
                }

                instantiatedCube.transform.position = raycasthits[0].pose.position;
            }
        }

       
    }
}
