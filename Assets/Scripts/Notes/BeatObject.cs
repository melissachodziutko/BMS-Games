using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BeatObject : MonoBehaviour
{
    public bool isHit;                      // checks if button was pressed

    PlayerControls controls;

    public GameObject noteCatcher;

    void Awake()
    {
        noteCatcher = GameObject.Find("Note Catcher");
        Debug.Log(noteCatcher.transform.position.x);

        controls = new PlayerControls();

        controls.Gameplay.FaceButtons.performed += ctx => FaceButtonCheck();
        controls.Gameplay.DirectionalButtons.performed += ctx => DirectionalButtonCheck();
        controls.Gameplay.ShoulderButtons.performed += ctx => ShoulderButtonCheck();
        controls.Gameplay.AnalogSticks.performed += ctx => AnalogStickCheck(ctx.ReadValue<Vector2>());
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
        
    }

    void Update()
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
    }

    private void IsHit()
    {
        if (isHit)
        {
            BeatCheck();
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

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Activator")
        {
            isHit = true;
        }
    }

    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Activator")
        {
            isHit = false;
            BeatCounter.instance.BeatMiss();
        }
    }
}
