using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuScript : MonoBehaviour
{
    public TMP_InputField txtEmail,txtPassword;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public async void Login()
    {
        var username = txtEmail.text;
        var password = txtPassword.text;

        string url = "https://fpoly-hcm.herokuapp.com/api/auth/login";
        WWWForm form = new WWWForm();
        form.AddField("email", username);
        form.AddField("password", password);

        var httpClient = new HttpPortal(new Serialization());
        var result = await httpClient.Post<Response>(url, form);
        if (result != null)

        {
            Storage storage = Storage.Instance;
            storage.token = result.data.token;
            SceneManager.LoadScene("MainScene");
        }

        Debug.Log(result);
    }
}
