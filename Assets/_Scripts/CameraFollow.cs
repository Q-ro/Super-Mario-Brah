/*
    
Author : Andres Mrad
Date : Tuesday 16/March/2021 @ 08:33:07 
Description : stuff
    
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    #region Name

    [SerializeField] GameObject objectToFollow; // Objeto a seguir

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        if (objectToFollow == null)
            Debug.LogError("Missing component !");
    }

    // Update is called once per frame
    void Update()
    {
        if (objectToFollow != null)
            this.transform.position = new Vector3(
                objectToFollow.transform.position.x,
                this.transform.position.y,
                this.transform.position.z
                );
    }
}
