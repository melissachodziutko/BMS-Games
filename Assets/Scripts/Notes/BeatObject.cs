using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class BeatObject : MonoBehaviour
{
    public bool isHit;                      // checks if button was pressed
    PlayerControls controls;
    public GameObject noteCatcher;
    public int isAlive;
    public ButtonType buttonType;
    public Image buttonImg;
    //private int Xbox_One_Controller = 0;
    //private int PS4_Controller = 0;

    void Awake()
    {
        noteCatcher = GameObject.Find("Note Catcher");

        controls = new PlayerControls();

        isAlive = 1;

        controls.Gameplay.FaceButtons.performed += ctx => FaceButtonCheck();
        controls.Gameplay.DirectionalButtons.performed += ctx => DirectionalButtonCheck();
        controls.Gameplay.ShoulderButtons.performed += ctx => ShoulderButtonCheck();
        //controls.Gameplay.AnalogSticks.performed += ctx => AnalogStickCheck(ctx.ReadValue<Vector2>());
    }

    void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    void OnDisable()
    {
        controls.Gameplay.Disable();
    }

    void Start()
    {
        buttonImg = gameObject.GetComponent<Image>();

        buttonTypeCheck();
    }

    void Update()
    {
        keyboardCheck();
    }

    #region Button Checks
    void buttonTypeCheck()
    {
        //InputSystem.onDeviceChange += (device, change) =>
        //{
        //    switch (change)
        //    {
        //        case InputDeviceChange.Added:
        //            Debug.Log("Controller connected");
        //            break;
        //        case InputDeviceChange.Removed:
        //            Debug.Log("Keyboard defaulted");
        //            break;
        //    }
        //};


        //if (Input.GetJoystickNames().Length > 0)
        //{
        //    Debug.Log("Controller connected");
        //    switch (gameObject.tag)
        //    {
        //        case "FaceButton_X":
        //            buttonImg.sprite = buttonType.faceButton_X;
        //            break;
        //        case "FaceButton_O":
        //            buttonImg.sprite = buttonType.faceButton_O;
        //            break;
        //        case "FaceButton_Tri":
        //            buttonImg.sprite = buttonType.faceButton_Tri;
        //            break;
        //        case "FaceButton_Sq":
        //            buttonImg.sprite = buttonType.faceButton_Sq;
        //            break;
        //        case "FaceButton_Up":
        //            buttonImg.sprite = buttonType.faceButton_Up;
        //            break;
        //        case "FaceButton_Down":
        //            buttonImg.sprite = buttonType.faceButton_Down;
        //            break;
        //        case "FaceButton_Left":
        //            buttonImg.sprite = buttonType.faceButton_Left;
        //            break;
        //        case "FaceButton_Right":
        //            buttonImg.sprite = buttonType.faceButton_Right;
        //            break;
        //        case "FaceButton_LShoulder":
        //            buttonImg.sprite = buttonType.faceButton_LShoulder;
        //            break;
        //        case "FaceButton_RShoulder":
        //            buttonImg.sprite = buttonType.faceButton_RShoulder;
        //            break;
        //        case "FaceButton_LTrigger":
        //            buttonImg.sprite = buttonType.faceButton_LTrigger;
        //            break;
        //        case "FaceButton_RTrigger":
        //            buttonImg.sprite = buttonType.faceButton_RTrigger;
        //            break;
        //        case "FaceButton_LStick":
        //            buttonImg.sprite = buttonType.faceButton_LStick;
        //            break;
        //        case "FaceButton_RStick":
        //            buttonImg.sprite = buttonType.faceButton_RStick;
        //            break;
        //    }
        //} else
        //{
        // Debug.Log("Leyboard");
        switch (gameObject.tag)
        {
            case "FaceButton_X":
                buttonImg.sprite = buttonType.keyboardButton_I;
                break;
            case "FaceButton_O":
                buttonImg.sprite = buttonType.keyboardButton_K;
                break;
            case "FaceButton_Tri":
                buttonImg.sprite = buttonType.keyboardButton_J;
                break;
            case "FaceButton_Sq":
                buttonImg.sprite = buttonType.keyboardButton_L;
                break;
            case "FaceButton_Up":
                buttonImg.sprite = buttonType.keyboardButton_W;
                break;
            case "FaceButton_Down":
                buttonImg.sprite = buttonType.keyboardButton_S;
                break;
            case "FaceButton_Left":
                buttonImg.sprite = buttonType.keyboardButton_A;
                break;
            case "FaceButton_Right":
                buttonImg.sprite = buttonType.keyboardButton_D;
                break;
            case "FaceButton_LShoulder":
                buttonImg.sprite = buttonType.keyboardButton_T;
                break;
            case "FaceButton_RShoulder":
                buttonImg.sprite = buttonType.keyboardButton_G;
                break;
            case "FaceButton_LTrigger":
                buttonImg.sprite = buttonType.keyboardButton_F;
                break;
            case "FaceButton_RTrigger":
                buttonImg.sprite = buttonType.keyboardButton_H;
                break;
            case "FaceButton_LStick":
                buttonImg.sprite = buttonType.keyboardButton_LMouse;
                break;
            case "FaceButton_RStick":
                buttonImg.sprite = buttonType.keyboardButton_RMouse;
                break;
        }
        //}
    }

    void keyboardCheck()
    {
        /** Checks for arrow pad/WASD directionals and angle of beat object
         * if direction lines up with angle,
         * if it was hit
         * destroy object instance
        **/
        if ((Input.GetAxis("Horizontal") > 0))
        {
            IsHit();
        }
        else if ((Input.GetAxis("Horizontal") < 0))
        {
            IsHit();
        }
        else if ((Input.GetAxis("Vertical") > 0))
        {
            IsHit();
        }
        else if ((Input.GetAxis("Vertical") < 0))
        {
            IsHit();
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            IsHit();
        } else if (Input.GetKeyDown(KeyCode.K))
        {
            IsHit();
        } else if (Input.GetKeyDown(KeyCode.J))
        {
            IsHit();
        } else if (Input.GetKeyDown(KeyCode.L))
        {
            IsHit();
        }

        //if (Input.GetKeyDown(KeyCode.T))
        //{
        //    IsHit();
        //} else if (Input.GetKeyDown(KeyCode.G))
        //{
        //    IsHit();
        //} else if (Input.GetKeyDown(KeyCode.F))
        //{
        //    IsHit();
        //} else if (Input.GetKeyDown(KeyCode.H))
        //{
        //    IsHit();
        //}
    }

    void FaceButtonCheck()
    {
        if (controls.Gameplay.FaceButtons.ReadValue<Vector2>() == new Vector2(1, 0))
        {
            Debug.Log("O");
            IsHit();
        }
        if (controls.Gameplay.FaceButtons.ReadValue<Vector2>() == new Vector2(0, 1))
        {
            Debug.Log("Triangle");
            IsHit();
        }
        if (controls.Gameplay.FaceButtons.ReadValue<Vector2>() == new Vector2(-1, 0))
        {
            Debug.Log("Square");
            IsHit();
        }
        if (controls.Gameplay.FaceButtons.ReadValue<Vector2>() == new Vector2(0, -1))
        {
            Debug.Log("X");
            IsHit();
        }
    }

    void DirectionalButtonCheck()
    {
        if (controls.Gameplay.DirectionalButtons.ReadValue<Vector2>() == new Vector2(1, 0))
        {
            Debug.Log("Right");
            IsHit();
        }
        if (controls.Gameplay.DirectionalButtons.ReadValue<Vector2>() == new Vector2(0, 1))
        {
            Debug.Log("Up");
            IsHit();
        }
        if (controls.Gameplay.DirectionalButtons.ReadValue<Vector2>() == new Vector2(-1, 0))
        {
            Debug.Log("Left");
            IsHit();
        }
        if (controls.Gameplay.DirectionalButtons.ReadValue<Vector2>() == new Vector2(0, -1))
        {
            Debug.Log("Down");
            IsHit();
        }
    }

    void ShoulderButtonCheck()
    {
        if (controls.Gameplay.ShoulderButtons.ReadValue<Vector2>() == new Vector2(1, 0))
        {
            Debug.Log("Right shoulder");
            IsHit();
        }
        if (controls.Gameplay.ShoulderButtons.ReadValue<Vector2>() == new Vector2(0, 1))
        {
            Debug.Log("Left shoulder");
            IsHit();
        }
        if (controls.Gameplay.ShoulderButtons.ReadValue<Vector2>() == new Vector2(-1, 0))
        {
            Debug.Log("Right trigger");
            IsHit();
        }
        if (controls.Gameplay.ShoulderButtons.ReadValue<Vector2>() == new Vector2(0, -1))
        {
            Debug.Log("Left trigger");
            IsHit();
        }
    }

    void AnalogStickCheck(Vector2 dir)
    {
        Debug.Log(dir);
        IsHit();
    }
    #endregion

    #region Beat Checks
    private void IsHit()
    {
        if (isHit)
        {
            BeatCheck();
            isAlive = 0;
            Destroy(gameObject);
        }
    }

    private void BeatCheck()
    {
        if (transform.position.x > noteCatcher.transform.position.x + 15 || transform.position.x < noteCatcher.transform.position.x - 15)
        {
            BeatCounter.instance.OkHit();
        }
        else if (transform.position.x > noteCatcher.transform.position.x + 5 || transform.position.x < noteCatcher.transform.position.x - 5)
        {
            BeatCounter.instance.GreatHit();
        }
        else
        {
            BeatCounter.instance.PerfectHit();
        }
    }
    #endregion

    #region Beat Collisions
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Activator")
        {
            isHit = true;
        }
    }

    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Activator" && isAlive == 1)
        {
            isHit = false;
            BeatCounter.instance.BeatMiss();
        }
    }
    #endregion
}
