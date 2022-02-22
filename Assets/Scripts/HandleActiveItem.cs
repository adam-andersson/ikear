using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleActiveItem : MonoBehaviour
{
    public GameObject activeFurniture = default;
    private static HandleActiveItem _instance;

    public static HandleActiveItem Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<HandleActiveItem>();
            }

            return _instance;
        }
    }
}
