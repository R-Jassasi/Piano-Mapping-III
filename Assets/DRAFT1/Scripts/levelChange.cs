using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class levelChange : MonoBehaviour
{

    public Animator animator;
    private string levelToLoad;

    //start the fade animation with a trigger condition
    public void FadeToLevel (string levelName){
        levelToLoad = levelName;
        animator.SetTrigger("FadeOut");
    }
     
     //on trigger enter change to light scene
    public void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")){

            FadeToLevel("Light_1");
            Debug.Log("Level Change2");
            OnFadeComplete();
            //SceneManager.LoadScene(1);
        }
    }

    void Update(){
        //change to light scene
        if (Input.GetKeyDown(KeyCode.C)){
            FadeToLevel("Light_1");
            Debug.Log("Level Change2");
            //SceneManager.LoadScene("Light_1");
        }

        //change to hut scene
         if (Input.GetKeyDown(KeyCode.V)){
            FadeToLevel("Hut_3");
            Debug.Log("Level Change1");
            //SceneManager.LoadScene("Hut_2");
        }

    }

    //after the fade is complete it transitions into the next scene
    public void OnFadeComplete(){
        SceneManager.LoadScene(levelToLoad);
    }
}
