using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    float speed = 0.001f;
    float stamina = 10000;
    float recoverStaminaRate = 1; // 1 por frame sem movimento
    float spendStaminaRate = 1; // 1 por frame com movimento
    public GameObject staminaSlider; 
    Slider ss;
    void Start()
    {
        ss = staminaSlider.GetComponent<Slider >();
        ss.maxValue = stamina;
        ss.value = stamina;
    }

    // Update is called once per frame
    void Update()
    {   
        speed = 0001f * (stamina/100); 

        var pos = transform.position;
   	    var h = Input.GetAxis("Horizontal");     
   	    var v = Input.GetAxis("Vertical");
        transform.position += speed*(h*Vector3.right + v*Vector3.forward);
        
        if (pos != transform.position) {
            stamina -= spendStaminaRate;
            if (stamina < 0) {stamina=0;} 
        }
        else {
            stamina += recoverStaminaRate;
            if (stamina > 10000) {stamina=10000;}
        }
        ss.value = stamina;

    }
}

