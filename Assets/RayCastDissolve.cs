using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class RayCastDissolve : MonoBehaviour
{
    public LayerMask mask;
    public int interactionRange;
    public Camera interactorCamera;
    public Material material;
    public float speed;
    private float elapsed;


    private void Start()
    {
        material = GetComponent<Renderer>().material;
    }
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(interactorCamera.ScreenPointToRay(Input.mousePosition), out hit,1000f, mask))
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                elapsed += Time.deltaTime;
                float Complete = elapsed/speed;
                material.SetFloat("_CutOff", Mathf.Lerp(8, -1, Complete));       
                Debug.Log(Complete);
                if(Complete >= 0.9)
                {
                    elapsed = 0;
                    material.SetFloat("_CutOff", 8);
                }
            }

        }
        else
        {
            Debug.Log("NoHit");
        }
    }
}
