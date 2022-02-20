using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Logo : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        Invoke("FirstLevelLoad", 10f);
    }

    void FirstLevelLoad()
    {
        SceneManager.LoadScene(1);
    }
}
