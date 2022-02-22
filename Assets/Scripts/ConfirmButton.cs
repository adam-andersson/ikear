using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmButton : MonoBehaviour
{
    private Button _btn;

    void Start()
    {
        _btn = GetComponent<Button>();
        _btn.onClick.AddListener(ConfirmObject);
    }

    static void ConfirmObject()
    {
        CurrentlySelectedObject.Instance.activeObject.GetComponent<ToggleHitbox>().hitboxOn = false;
        CurrentlySelectedObject.Instance.activeObject = default;
    }
}
