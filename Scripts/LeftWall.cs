using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftWall : MonoBehaviour
{

    private bool contacted;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && !contacted)
        {
            ScoreManager.score++;
            contacted = true;
            Debug.Log("Score:" + ScoreManager.score);
        }
    }
}
