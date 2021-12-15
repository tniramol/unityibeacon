using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scan_main : MonoBehaviour
{
    public static scan_main Instance;
    public Web Web;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        Web = GetComponent<Web>();
    }
}
