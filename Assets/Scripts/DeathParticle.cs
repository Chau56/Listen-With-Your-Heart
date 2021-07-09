using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DeathLogic))]
public class DeathParticle : MonoBehaviour
{
    private DeathLogic Logic;
    public GameObject dieParticle;

    void Start()
    {
        Logic = GetComponent<DeathLogic>();
        Logic.OnDied += particle;
    }
    
    void Update()
    {
        
    }

    private void particle()
    {
        Instantiate(dieParticle, transform.position, new Quaternion());
    }
}
