using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{

    public int leftScore = 0;
    public int rightScore = 0;
    public int maxScore = 5;

    [SerializeField] private TextMeshPro leftScoreText;
    [SerializeField] private TextMeshPro rightScoreText;

    [SerializeField] private GameObject puck;

    public void GoalScored(bool leftGoal)
    {
        if(leftGoal)
        {
            rightScore++;
            rightScoreText.text = rightScore.ToString();
        }
        else
        {
            leftScore++;
            leftScoreText.text = leftScore.ToString();
        }
        CheckForWin();
        StartCoroutine(ResetPuck());
    }

    IEnumerator ResetPuck()
    {
        yield return new WaitForSeconds(0.5f);
        puck.transform.position = new Vector3(0, 1, 0);
        puck.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
    
    void CheckForWin()
    {
        if (leftScore >= maxScore)
        {
            Debug.Log("Left player wins!");
            ResetGame();
        }
        else if (rightScore >= maxScore)
        {
            Debug.Log("Right player wins!");
            ResetGame(); 
        }
    }
    private void ResetGame()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
