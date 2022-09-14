using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    Vector2 movePos = new Vector2(1, -1);
    // Start is called before the first frame update
    void Start()
    { 
        Destroy(gameObject, 3.5f);
        
    }

    private void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * 7f);
    }
}
