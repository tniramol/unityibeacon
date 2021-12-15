using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class calc_dist : MonoBehaviour
{
    public Text textout;
    public InputField pointA;
    public InputField pointB;
    public Button checkButton;
    public string mac_address = "AA-00-04-00-XX-YY";
    public string username = "testuser";
    // Start is called before the first frame update
    void Start()
    {
        checkButton.onClick.AddListener(() => {
            string text_result = calculation(pointA.text, pointB.text);
            textout.text = text_result;
            StartCoroutine(scan_main.Instance.Web.UploadScan(username, text_result, mac_address));
        });
    }
    private int nextUpdate=1;
     
     void Update(){
     

         if(Time.time>=nextUpdate){
             Debug.Log(Time.time+">="+nextUpdate);
             nextUpdate=Mathf.FloorToInt(Time.time)+30;

             UpdateEverySecond();
         }
     
     }
     
     // Update is called once per second
     void UpdateEverySecond()
     {
         string text_result = calculation(pointA.text, pointB.text);
         textout.text = text_result;
     }

    private string calculation(string pointA, string pointB){
         float A = float.TryParse(pointA, out var val1) ? val1 : 1; 
         float B = float.TryParse(pointB, out var val2) ? val2 : 1;
         float C = 7;
         float result = 0;
         result = Mathf.Acos((A*A + B*B - C*C)/(2*A*B))*180/Mathf.PI;
         string text_result = result.ToString("n5");
         return text_result;
     }
    
 
}
