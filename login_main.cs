using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class login_main : MonoBehaviour
{
    public static login_main Instance;
    public Web Web;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        Web = GetComponent<Web>();
    }
}
