using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PluginScript : MonoBehaviour
{
    const string pluginName = "com.cwgtech.unity.myPlugin";
    static AndroidJavaClass _pluginClass;
    static AndroidJavaObject _pluginInstance;
    
    public Button onsw;
    public Button offsw;
    public Text BT_Status;


    public static AndroidJavaClass PluginClass
    {
        get {
            if (_pluginClass==null)
            {
                _pluginClass = new AndroidJavaClass(pluginName);
            }
            return _pluginClass;
        }
    }
    
    public static AndroidJavaObject PluginInstance
    {
        get {
            if (_pluginInstance==null)
            {
                _pluginInstance = PluginClass.CallStatic<AndroidJavaObject>("getInstance");
            }
            return _pluginInstance;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Elapsed Time: " + getElapsedTime());
        //Debug.Log("I DID!");
        onsw.onClick.AddListener(() => {
            BT_Status.text = (PluginInstance.Call<string>("turn_on"));
            Debug.Log("I DID!");
        });
        offsw.onClick.AddListener(() => {
            BT_Status.text = (PluginInstance.Call<string>("turn_off"));
            Debug.Log("I DID!");
        });
    }

    float elapsedTime = 0;

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= 5)
        {
            elapsedTime -=5;
            Debug.Log("Tick: " + getElapsedTime());
        }
    }

    double getElapsedTime()
    {
        if (Application.platform == RuntimePlatform.Android)
            return PluginInstance.Call<double>("getElapsedTime");
        Debug.LogWarning("Wrong platform");
        return 0;
    }
}
