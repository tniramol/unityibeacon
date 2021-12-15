using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Web : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(GetText());
        //StartCoroutine(Login("", ""));
        //StartCoroutine(register("testuser2", "123456"));
    }

    IEnumerator GetText() 
    {
        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost/UnityBackend/getdate.php"))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                byte[] results = www.downloadHandler.data;
            }
        }    
    }

    public IEnumerator Login(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);

        using (UnityWebRequest www = UnityWebRequest.Post("https://rp.enderice.com/test_server/login.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                if((www.downloadHandler.text).Contains("Login Success!"))
                {
                    SceneManager.LoadScene("Home");
                }
            }
        }
    }

    public IEnumerator Register(string username, string password, string phone, int type)
    {
        WWWForm form = new WWWForm();
        form.AddField("reg_username", username);
        form.AddField("reg_password", password);
        form.AddField("reg_phone", phone);
        form.AddField("reg_type", type);


        using (UnityWebRequest www = UnityWebRequest.Post("https://rp.enderice.com/test_server/registerUser.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }

    public IEnumerator UploadScan(string username, string distance, string mac_address)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("distance", distance);
        form.AddField("mac_address", mac_address);

        using (UnityWebRequest www = UnityWebRequest.Post("https://rp.enderice.com/test_server/scan.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }
    
}
