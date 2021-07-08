using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameActionDistribute : MonoBehaviour
{
    private CubeAction inputs;
    [SerializeField]
    [Tooltip("第一个玩家。")]
    private GameObject player1;
    [SerializeField]
    [Tooltip("第二个玩家。")]
    private GameObject player2;

    private void MapJump1()
    {
        if(player1.TryGetComponent<PlayerJumpController>(out var jump1))
        inputs.Cube.Jump1.performed += _ =>
        {
            jump1.Jump();
            Debug.Log($"{nameof(jump1)}");
        };
        else Debug.LogWarning($"{nameof(player1)}'s {nameof(PlayerJumpController)} is null.");
    }
    private void MapJump2()
    {
        if(player2.TryGetComponent<PlayerJumpController>(out var jump2))
        inputs.Cube.Jump2.performed += _ =>
        {
            jump2.Jump();
            Debug.Log($"{nameof(jump2)}");
        };
        else Debug.LogWarning($"{nameof(player2)}'s {nameof(PlayerJumpController)} is null.");
    }

    private void MapCheat1()
    {
        if (player1.TryGetComponent<AutoMovement>(out var cheat1))
        {
            var cheat = inputs.Cheat;
            cheat.Pause1.performed += _ =>
            {
                cheat1.Pause();
                Debug.Log($"{nameof(cheat.Pause1)}");
            };
            cheat.Impulse1.performed += _ =>
            {
                cheat1.Impulse();
                Debug.Log($"{nameof(cheat.Impulse1)}");
            };
        }
        else Debug.LogWarning($"{nameof(player1)}'s {nameof(AutoMovement)} is null.");
    }
    private void MapCheat2()
    {
        if (player2.TryGetComponent<AutoMovement>(out var cheat2))
        {
            var cheat = inputs.Cheat;
            cheat.Pause2.performed += _ =>
            {
                cheat2.Pause();
                Debug.Log($"{nameof(cheat.Pause2)}");
            };
            cheat.Impulse2.performed += _ =>
            {
                cheat2.Impulse();
                Debug.Log($"{nameof(cheat.Impulse2)}");
            };
        }
        else Debug.LogWarning($"{nameof(player2)}'s {nameof(AutoMovement)} is null.");
    }

    // Start is called before the first frame update
    private void Awake()
    {
        inputs = new CubeAction();
        inputs.Enable();
        MapJump1();
        MapJump2();
        MapCheat1();
        MapCheat2();

    }
}
