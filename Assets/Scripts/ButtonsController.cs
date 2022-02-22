using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsController : MonoBehaviour
{
    private Button _btn;
    private Image _buttonImg;
    public GameObject furniturePrefab;
    private Color selectedColor = new Color(1, 1, 1, 0.4f);
    private Color deselectedColor = new Color(1, 1, 1, 0);

    // Start is called before the first frame update
    void Start()
    {
        _btn = GetComponent<Button>();
        _btn.onClick.AddListener(ChooseObject);
        _buttonImg = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        _buttonImg.color = HandleActiveItem.Instance.activeFurniture == furniturePrefab ? selectedColor : deselectedColor;
    }

    void ChooseObject()
    {
        HandleActiveItem.Instance.activeFurniture = furniturePrefab;
    }

}
