using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    Rigidbody rb;
    const float G = 0.006674f;
    public static List<Gravity> gravitylist;

    //โคจร
    [SerializeField]bool planet = false;
    [SerializeField]int orbetspeed = 1000;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (gravitylist == null)
        {
            gravitylist = new List<Gravity>();
        }

        gravitylist.Add(this);

        //orbit
        if (planet = false)
        {
           rb.AddForce(Vector3.left * orbetspeed);
        }
    }


    private void FixedUpdate()
    {
        foreach (var obj in gravitylist)
        {
            if (obj != this)
            {
                Attract(obj);
            }
        }

    }








    void Attract(Gravity orther)
    {
        Rigidbody ortherRb = orther.rb;
        
        //หาระยะทางระหว่าง ตัวหลัก และ อันอื่น
        Vector3 direction = rb.position - ortherRb.position; 
        float distance = direction.magnitude;

        //                        ใช้ Mass ตัวหลัก คูณ กับของตัวอื่น        หารด้วยระยะทางของทั้ง 2 อัน แล้วก็ยกกำลัง2
        float forceMagnitude = G * ((rb.mass * ortherRb.mass)) / Mathf.Pow(distance,2);

        Vector3 finaleForce = forceMagnitude * direction.normalized;

        
        ortherRb.AddForce(finaleForce);
    }
}
