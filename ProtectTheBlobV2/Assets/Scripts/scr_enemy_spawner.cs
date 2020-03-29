using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LevelConstants;

public class scr_enemy_spawner : MonoBehaviour
{
    public GameObject enemy_level_1;
    private float timer; 
    private Vector2 starting_pos;
    private bool isCreating = false;
    // Start is called before the first frame update
    void Start()
    {
        starting_pos = transform.position;
        float new_y = 2 * Camera.main.orthographicSize;
        starting_pos.x = 5.0f;
        starting_pos.y = Random.Range(TestLevelData.Y_LIMIT_U,TestLevelData.Y_LIMIT_D);
    }

    // Update is called once per frame
    void Update()
    {
        if(!isCreating){
            timer = Random.Range(1.0f,3.0f);
            isCreating = true;
        }
        
        if(isCreating){
            if(timer < 0) {
                isCreating = false;
                float new_y = 2 * Camera.main.orthographicSize;
                starting_pos.y = Random.Range(TestLevelData.Y_LIMIT_U,TestLevelData.Y_LIMIT_D);
                Instantiate(enemy_level_1,starting_pos, transform.rotation);
            }
            else {
                timer -= Time.deltaTime;
            }
        }
    }
}
