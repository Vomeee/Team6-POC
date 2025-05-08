using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public int scene;
    
    Button button;



    void Start()
    {
        button =GetComponent<Button>();
        button.onClick.AddListener(Load);   
    }


    public void Load()
    {
        SceneManager.LoadScene(scene);
    }

}
