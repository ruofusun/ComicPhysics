using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDamage : MonoBehaviour
{
    private ShadowController _shadowController;
    // Start is called before the first frame update
    void Start()
    {
        _shadowController = FindObjectOfType<ShadowController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            _shadowController.IncreaseShadow();
           Debug.Log("should hurt player");
           _shadowController.Timer = 0;
        }
    }
}
