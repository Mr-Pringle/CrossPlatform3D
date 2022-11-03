using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : Singleton<GameManager>
{

    Player playerInput;
    PlayerController controller;
    protected override void Awake()
    {
        base.Awake();
        playerInput = new Player();
    }



    // Start is called before the first frame update
    void Start()
    {
        playerInput.Actions.Escape.performed += ctx => OnButtonPress(ctx);
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    public void OnButtonPress (InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (SceneManager.GetActiveScene().name == "Level")
            {
                SceneManager.LoadScene("MainMenu");
            }
            else
            {
                SceneManager.LoadScene("Level");
            }
        }
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        if (!controller && SceneManager.GetActiveScene().name == "Level")
        {
            AddPlayerInput();
            return;
        }
    }

    void AddPlayerInput()
    {
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        if (controller == null)
        {
            return;
        }

        playerInput.Actions.Move.performed += ctx => controller.MovePlayer(ctx);
        playerInput.Actions.Move.canceled += ctx => controller.MovePlayer(ctx);

        playerInput.Actions.Look.performed += ctx => controller.Look(ctx);
        playerInput.Actions.Fire.performed += ctx => controller.Fire(ctx);


    }

    public void EndGame()
    {
        SceneManager.LoadScene("Victory");
    }
}
