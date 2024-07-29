using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get => instance; }  
    [SerializeField] Text scoreTx;
    public int score = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("co 2 GameManager");
        }
    }

    private void Start()
    {
        Score();
    }
    public virtual void SetScore()
    {
        score++;
    }  
    
    public virtual void Score()
    {
        scoreTx.text = score.ToString();
    }

    private void Update()
    {
        Score();
    }

}
