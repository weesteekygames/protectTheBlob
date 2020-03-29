using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LevelConstants;

public class scr_enemy_base : MonoBehaviour
{
    private float enemy_speed = 1.1f;
    private bool hasReached = false;
    enum State  {MOVING = 0, ATTACKING =1, REACHED = 2};
    private State currentState = State.MOVING;
    private float start_time;
    private Vector2 starting_pos;
    // Start is called before the first frame update
    void Start()
    {
        start_time = Time.time;   
        starting_pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float current_time, coveredDist, len_journey, frac_journey;
        switch(currentState){
            case State.MOVING:
                if(transform.position.x <= TestLevelData.E_TARGET_L){
                    currentState = State.REACHED;
                }
                else {
                    Vector2 target_pos = new Vector2(TestLevelData.E_TARGET_L,transform.position.y);

                    current_time = Time.time;
                    coveredDist = (current_time - start_time) * enemy_speed;

                    len_journey = (target_pos.x - starting_pos.x);
                    frac_journey = coveredDist/len_journey;
                    
                    transform.position = Vector3.Lerp(starting_pos, target_pos, -frac_journey);
                }
                break;
            case State.ATTACKING:
                break;
            case State.REACHED:
                if (this.gameObject != null){
                    Destroy(this.gameObject);
                }
                break;
        }
    }
}
