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
        // Application.LoadScene  ---> ���̻� ������� �ʴ´�
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex/*���弼���� ��ȣ�� �����Ѵ�*/);
    }
}
