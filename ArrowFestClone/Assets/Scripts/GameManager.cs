using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject arrowStack;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GameOverCheck();
    }

    private void GameOverCheck()
    {
        if (arrowStack.transform.childCount <= 0)
        {
            Debug.Log("Game must be over");
            GameOver();
        }
    }

    public void GameOver()
    {
        //TODO MAKE GAME OVER SEQUENCE BETTER
        SceneManager.LoadScene(0);
    }
}