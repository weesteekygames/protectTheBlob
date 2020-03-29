using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_cursor_alpha_change : MonoBehaviour
{
    float[] alphas = {0.8f,0.6f,0.45f,0.3f};
    const float TIME_DELAY = 0.15f;
    private float timer;
    private int currentIndex; 
    const float ROTATION_SPEED = 60.0f;
    // Start is called before the first frame update
    void Start()
    {
        timer = TIME_DELAY;
        currentIndex = 0; 
    }

    void changeAlpha(int arrayIndex) {
        Color tmp = GetComponent<SpriteRenderer>().color;
        tmp.a = alphas[arrayIndex];
        GetComponent<SpriteRenderer>().color = tmp;
        currentIndex ++;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * ROTATION_SPEED * Time.deltaTime);
        if(timer <= 0){
            if(currentIndex < alphas.Length){
                changeAlpha(currentIndex);
                timer = TIME_DELAY;
            }
            else{
                Destroy(this.gameObject);
            }
        }
        else {
            timer -= Time.deltaTime;
        }
    }
}
