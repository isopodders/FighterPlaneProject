using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTwo : MonoBehaviour
{
    //declaring variables used in changing direction of EnemyTwo
    public float movePlease = 3f;
    public float originalPosition = 0f;


    // Start is called before the first frame update
    void Start()
    {
                originalPosition = transform.position.x;

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(transform.position.x);

        transform.Translate(new Vector3(movePlease, -0.8f, 0) * Time.deltaTime * 3f);
        if (originalPosition + transform.position.x > originalPosition + 7f)
        {
            movePlease = -4f;
            //Debug.Log(transform.position.x);

        }
        if (originalPosition + transform.position.x < originalPosition - 7f)
        {
            movePlease = 4f;
        }
        if (transform.position.y < -6.5f)
        {
            Destroy(this.gameObject);
        }
    }

}
