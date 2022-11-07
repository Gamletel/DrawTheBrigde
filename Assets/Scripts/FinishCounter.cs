using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishCounter : MonoBehaviour
{
    public delegate void Finished();
    public static event Finished finished;

    public static bool isFifnished;
    [SerializeField] private WinPanelCoinsHandler winPanel;
    private static int _finishAmount;
    private static int _curFinished;
    


    private void Awake()
    {
        _finishAmount = GameObject.FindGameObjectsWithTag("Finish").Length;
        isFifnished = false; 
    }

    private void OnEnable()
    {
        finished += winPanel.EnablePanel;
    }

    private void OnDisable()
    {
        finished -= winPanel.EnablePanel;
    }

    //���������� ��� ���������� ������
    public static void OnFinished()
    {
        _curFinished++;
        //���� ���������� ��� ������, ����� ���������� ������� �����������
        if (_curFinished == _finishAmount)
        {
            isFifnished = true;
            finished?.Invoke();
            if (PlayerPrefs.GetInt("bestLvl") <= SceneManager.GetActiveScene().buildIndex)
                SaveLvl();
            CoinSaver.SaveCoins();
        }
    }
    
    public static void SaveLvl()
    { 
        PlayerPrefs.SetInt("bestLvl", SceneManager.GetActiveScene().buildIndex + 1);
    }

    public static void ResetFinishes()
    {
        _curFinished = 0;
    }
}
