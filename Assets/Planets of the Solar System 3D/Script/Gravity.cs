using UnityEngine;

public class Gravity : MonoBehaviour
{
    Rigidbody rb;
    const float G = 0.00674f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
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
