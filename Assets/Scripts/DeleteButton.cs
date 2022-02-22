using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteButton : MonoBehaviour
{
    private Button _btn;

    void Start()
    {
        _btn = GetComponent<Button>();
        _btn.onClick.AddListener(DeleteObject);
    }

    static void DeleteObject()
    {
        if (CurrentlySelectedObject.Instance.activeObject != default)
        {
            // CurrentlySelectedObject.Instance.activeObject.SetActive(false);
            Destroy(CurrentlySelectedObject.Instance.activeObject);
        }
            
    }
}
