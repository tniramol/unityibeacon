using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class register_main : MonoBehaviour
{
    public static register_main Instance;
    public Web Web;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        Web = GetComponent<Web>();
    }
}
