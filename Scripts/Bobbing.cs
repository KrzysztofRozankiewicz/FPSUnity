using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bobbing : MonoBehaviour
{

    public float speed = 0.3f;
    public float height = 0.2f;
    public float mid = 0.8f;
    public bool bobbing = true;

    float timer = 0f;

    void Update()
    {
        float slice = 0f;
        float horizont = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        Vector3 conv = transform.localPosition;

        if (Mathf.Abs(horizont) == 0 && Mathf.Abs(vert) == 0)
        {
            timer = 0f;
        }
        else
        {
            slice = Mathf.Sin(timer);
            timer += speed;
            if (timer > Mathf.PI * 2)
            {
                timer -= Mathf.PI * 2;
            }
        }

        if (slice != 0)
        {
            float change = slice * height;
            float total = Mathf.Abs(horizont) + Mathf.Abs(vert);
            total = Mathf.Clamp(total, 0f, 1f);
            change *= total;
            if (bobbing == true)
            {
                conv.y = mid + change;
            }
            else if (bobbing == false)
            {
                conv.x += change;
            }

        }
        else
        {
            if (bobbing == true)
            {
                conv.y = mid;
            }
            else if (bobbing == false)
            {
                conv.x = 0;
            }
        }
        transform.localPosition = conv;
    }
}
