using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadingScene()
    {
        SceneManager.LoadScene("X-Ray Room");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
