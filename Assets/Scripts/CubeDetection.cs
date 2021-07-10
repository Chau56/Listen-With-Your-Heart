using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class CubeDetection : MonoBehaviour
{
    public event Action OnHitEndline;
    
    // Start is called before the first frame update
    private void Start()
    {
        RegisterSelfEvents();
    }

    private void RegisterSelfEvents()
    {
        OnHitEndline += () => { };
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"{collision.tag} hit end line");
        OnHitEndline();
    }
}