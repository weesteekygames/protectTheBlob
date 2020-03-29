using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_cloud_alpha : MonoBehaviour
{
    private float cloud_speed = 1.0f;
    private Vector2 starting_pos;
    private Vector2 target_pos;
    private float start_time;
    // Start is called before the first frame update
    void Start()
    {
        Color tmp = GetComponent<SpriteRenderer>().color;
        tmp.a = Random.Range(25.0f,50.0f)/100;
        GetComponent<SpriteRenderer>().color = tmp;
        starting_pos = transform.position;
        target_pos = new Vector2(10.0f, transform.position.y);
        start_time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float coveredDist = (Time.time - start_time) * cloud_speed;
        float len_journey = target_pos.x - starting_pos.x;
        float frac_journey = coveredDist/len_journey;

        if(transform.position.x < target_pos.x){
            transform.position = Vector3.Lerp(starting_pos, target_pos, frac_journey);
        }
        else{
            Destroy(this.gameObject);
        }
    }
}
