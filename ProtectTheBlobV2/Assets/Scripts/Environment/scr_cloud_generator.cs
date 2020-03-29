using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_cloud_generator : MonoBehaviour
{
    public GameObject cloud; 
    private float timer; 
    private Vector2 starting_pos;
    private bool isCreating = false;

    // Start is called before the first frame update
    void Start()
    {
        starting_pos = transform.position;
        float new_y = 2 * Camera.main.orthographicSize;
        starting_pos.x = -5;
        starting_pos.y = Random.Range(0.0f,new_y);
    }

    // Update is called once per frame
    void Update()
    {
        if(!isCreating){
            timer = Random.Range(5.0f,10.0f);
            isCreating = true;
        }
        
        if(isCreating){
            if(timer < 0) {
                isCreating = false;
                float new_y = 2 * Camera.main.orthographicSize;
                starting_pos.y = Random.Range(0.0f,new_y);
                Instantiate(cloud,starting_pos, transform.rotation);
            }
            else {
                timer -= Time.deltaTime;
            }
        }
    }
}
