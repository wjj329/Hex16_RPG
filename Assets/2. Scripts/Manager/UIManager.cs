using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverUI;

    void Start()
    {
        gameOverUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GameOver()
    {
        gameOverUI.SetActive(true);
        
    }
    public void RestartGame()
    {
        // Application.LoadScene  ---> 더이상 사용하지 않는다
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex/*빌드세팅의 번호로 실행한다*/);
    }
}
