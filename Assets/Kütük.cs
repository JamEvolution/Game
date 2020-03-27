using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kütük : MonoBehaviour
{
    public float[] hızlar;
    public float[] süreler;
    WheelJoint2D kütükwheel;
    JointMotor2D motorum;
    public int index;

    // Start is called before the first frame update
    void Start()
    {
        kütükwheel = GetComponent<WheelJoint2D>();
        motorum = new JointMotor2D();
        StartCoroutine("dönüşişlemi"); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator dönüşişlemi()
    {
        index = 0;
        while (true)
        {
            kütükwheel.motor = motorum;
            motorum.maxMotorTorque = 1000;
            motorum.motorSpeed = hızlar[index];
            yield return new WaitForSecondsRealtime(süreler[index]);
            index++;
            if (index == hızlar.Length)
            {
                index = 0;
            }
        }
    }
         
}
