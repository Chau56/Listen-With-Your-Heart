using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameActionDistribute : MonoBehaviour
{
    private CubeAction inputs;
    [SerializeField]
    [Tooltip("第一个玩家。")]
    private PlayerJumpController player1;
    [SerializeField]
    [Tooltip("第二个玩家。")]
    private PlayerJumpController player2;

    // Start is called before the first frame update
    private void Awake()
    {
        inputs = new CubeAction();
        var cube = inputs.Cube;
        cube.Jump1.performed += player1.Jump;
        cube.Jump1.performed += _ => Debug.Log("jump1 performed.");
        cube.Jump2.performed += player2.Jump;
        cube.Jump2.performed += _ => Debug.Log("jump2 performed.");
        inputs.Enable();
    }
}
