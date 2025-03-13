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
        
        //�����зҧ�����ҧ �����ѡ ��� �ѹ���
        Vector3 direction = rb.position - ortherRb.position; 
        float distance = direction.magnitude;

        //                        �� Mass �����ѡ �ٳ �Ѻ�ͧ������        ��ô������зҧ�ͧ��� 2 �ѹ ���ǡ�¡���ѧ2
        float forceMagnitude = G * ((rb.mass * ortherRb.mass)) / Mathf.Pow(distance,2);

        Vector3 finaleForce = forceMagnitude * direction.normalized;


        ortherRb.AddForce(finaleForce);
    }
}
