using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleHitbox : MonoBehaviour
{
    public bool hitboxOn;

    // Update is called once per frame
    void Update()
    {
        GetComponent<Toggle>().isOn = hitboxOn;
    }
}
