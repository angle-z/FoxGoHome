using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogControl : MonoBehaviour
{
    public GameObject Dialog;
    // Start is called before the first frame update
    private bool enter;
    void Start()
    {
        enter = false;   
    }

    // Update is called once per frame
    void Update()
    {
        if (enter)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Dialog.SetActive(true);
            enter = true;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag.Equals("Player"))
        {
            Dialog.SetActive(false);
            enter = false;
        }
    }
}
