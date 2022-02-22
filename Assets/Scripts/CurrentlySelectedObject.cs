using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentlySelectedObject : MonoBehaviour
{
    public GameObject activeObject = default;
    private static CurrentlySelectedObject _instance;

    public static CurrentlySelectedObject Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<CurrentlySelectedObject>();
            }

            return _instance;
        }
    }
}
