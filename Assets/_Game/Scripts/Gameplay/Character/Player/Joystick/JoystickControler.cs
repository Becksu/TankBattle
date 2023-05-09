using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickControler : MonoBehaviour
{
    public Vector3 direction;
    private Vector3 screen;
    private Vector3 startPos;
    private Vector3 updatePos;
    private Vector3 mousePosition => Input.mousePosition - screen / 2;
    public float magnitude;
    public GameObject panel;
    public RectTransform joystickBG;
    public RectTransform joystickControler;

    private void Start()
    {
        screen.x = Screen.width;
        screen.y = Screen.height;
        direction = Vector3.zero;
        panel.gameObject.SetActive(false);    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            startPos = mousePosition;
            joystickBG.anchoredPosition = startPos;
            panel.gameObject.SetActive(true);
        }
        if (Input.GetMouseButton(0))
        {
            updatePos = mousePosition;
            joystickControler.anchoredPosition = Vector3.ClampMagnitude(updatePos - startPos, magnitude) + startPos;
            direction = updatePos - startPos;
            direction.z = direction.y;
            direction.y = 0;
        }
        if (Input.GetMouseButtonUp(0))
        {
            direction = Vector3.zero;
            panel.gameObject.SetActive(false);
        }
    }
    private void OnDisable()
    {
        direction = Vector3.zero;
    }

}
