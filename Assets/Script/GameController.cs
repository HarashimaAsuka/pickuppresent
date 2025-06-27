using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameController : MonoBehaviour
{
    public Text scoreLabel;
    public Text itemsRemainingLabel; // 残りのアイテム数を表示するテキスト
    public GameObject winnerLabelObject;
    public GameObject gameOverLabelObject;
    public GameObject targetLocation;
    public Text gameOverLabel;
    public Text gameClearLabel;
    public Text timerLabel;
    public GameObject[] objectsToDisable;
    public Image allItemsCollectedText;
    public float timeLimit = 300.0f;
    public string collectibleTag = "CollectibleItem";
    public GameObject[] hearts;
    public Text countdownLabel;

    private int score = 0;
    private int dangerWallHits = 0;
    public int totalItems;
    private bool gameClear = false;
    private float remainingTime;
    private bool gameStarted = false;
    
    void Start()
    {
        InitializeGame();
    }

    void InitializeGame()
    {
        // フィールドの null チェック
        if (scoreLabel == null || itemsRemainingLabel == null || winnerLabelObject == null || gameOverLabelObject == null || targetLocation == null || gameOverLabel == null || gameClearLabel == null || allItemsCollectedText == null || countdownLabel == null)
        {
            Debug.LogError("One or more fields are not set in the Inspector.");
            return;
        }

        winnerLabelObject.SetActive(false);
        gameOverLabelObject.SetActive(false);
        gameOverLabel.gameObject.SetActive(false);
        gameClearLabel.gameObject.SetActive(false);
        allItemsCollectedText.gameObject.SetActive(false);
        countdownLabel.gameObject.SetActive(true);

        foreach(GameObject heart in hearts){
            heart.SetActive(true);
        }

        score = 0;
        dangerWallHits = 0;
        gameClear = false;
        gameStarted = false;

        StartCoroutine(UpdateItemCount());
        StartCoroutine(StartCountdown());
    }

    IEnumerator StartCountdown()
    {
        int countdown = 3;
        while (countdown > 0)
        {
            countdownLabel.text = countdown.ToString();
            yield return new WaitForSeconds(1.0f);
            countdown--;
        }

        countdownLabel.text = "Go!";
        yield return new WaitForSeconds(1.0f);
        countdownLabel.gameObject.SetActive(false);
        gameStarted = true;
        remainingTime = timeLimit;
    }

    public bool GameStarted()
    {
        return gameStarted;
    }

    IEnumerator UpdateItemCount()
    {
        yield return new WaitForSeconds(0.1f);
        totalItems = GameObject.FindGameObjectsWithTag("Item").Length;
        Debug.Log("Total items:" + totalItems);
        UpdateScoreLabel();
        UpdateItemsRemainingLabel();
    }

    void Update()
    {
        if (gameStarted && !gameClear)
        {
            remainingTime -= Time.deltaTime;
            UpdateTimerLabel();
  
            if (remainingTime <= 0)
            {
                remainingTime = 0;
                GameOver();
            }
            else if (totalItems == 0)
            {
                CheckGameClear();
            }
        }
    }

    void UpdateScoreLabel()
    {
        scoreLabel.text = "Score: " + score.ToString();
    }

    void UpdateItemsRemainingLabel()
    {
        itemsRemainingLabel.text = "Items Remaining: " + totalItems.ToString();
    }

    void UpdateTimerLabel()
    {
        timerLabel.text = "Time: " + Mathf.CeilToInt(remainingTime).ToString();
    }

    public void CollectItem()
    {
        if (!gameStarted) return;

        score += 10; // アイテムごとのポイントを10と仮定
        totalItems--;

        UpdateScoreLabel();
        UpdateItemsRemainingLabel(); // アイテム取得後に更新

        if (!gameClear && totalItems == 0)
        {
            ShowAllItemsCollectedText();
            Disableobjects();
            CheckGameClear();
        }
    }

    public void HitDangerWall()
    {
        if (!gameStarted) return;

        score -= 5; // ペナルティポイントを5と仮定
        dangerWallHits++;

        UpdateScoreLabel();
        UpdateHeartIcons();

        if (dangerWallHits >= 3)
        {
            GameOver();
        }
    }

    void UpdateHeartIcons()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].SetActive(i < hearts.Length - dangerWallHits);
        }
    }

    void GameOver()
    {
        gameOverLabelObject.SetActive(true);
        gameOverLabel.gameObject.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void CheckGameClear()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null && Vector3.Distance(player.transform.position, targetLocation.transform.position) < 1.0f)
        {
            GameClear();
        }
    }

    void ShowAllItemsCollectedText()
    {
        allItemsCollectedText.gameObject.SetActive(true);
    }

    void Disableobjects()
    {
        foreach (GameObject obj in objectsToDisable)
        {
            obj.SetActive(false);
        }
    }

    void GameClear()
    {
        gameClear = true;
        winnerLabelObject.SetActive(true);
        gameClearLabel.gameObject.SetActive(true);
        Time.timeScale = 0.0f;
    }
}
























// using UnityEngine;
// using UnityEngine.UI;
// using UnityEngine.SceneManagement;
// using System.Collections;

// public class GameController : MonoBehaviour
// {
//     public Text scoreLabel;
//     public Text itemsRemainingLabel;
//     public GameObject winnerLabelObject;
//     public GameObject gameOverLabelObject;
//     public GameObject targetLocation;
//     public Text gameOverLabel;
//     public Text gameClearLabel;
//     public Text timerLabel;
//     public GameObject[] objectsToDisable;
//     public Text allItemsCollectedText;
//     public float timeLimit = 300.0f;
//     public string collectibleTag = "CollectibleItem";
//     public GameObject[] hearts;
//     public Text countdownLabel;

//     private int score = 0;
//     private int dangerWallHits = 0;
//     private int totalItems;
//     private bool gameClear = false;
//     private float remainingTime;
//     private bool gameStarted = false;
    
//     void Start()
//     {
//         InitializeGame();
//     }

//     void OnEnable()
//     {
//         SceneManager.sceneLoaded += OnSceneLoaded;
//     }

//     void OnDisable()
//     {
//         SceneManager.sceneLoaded -= OnSceneLoaded;
//     }

//     private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
//     {
//         InitializeGame();
//     }

//     void InitializeGame()
//     {
//         // reset = FindObjectOfType<Reset>();
//         // フィールドの null チェック
//         if (scoreLabel == null || itemsRemainingLabel == null || winnerLabelObject == null || gameOverLabelObject == null || targetLocation == null || gameOverLabel == null || gameClearLabel == null || allItemsCollectedText == null || countdownLabel == null)
//         {
//             Debug.LogError("One or more fields are not set in the Inspector.");
//             return;
//         }

//         winnerLabelObject.SetActive(false);
//         gameOverLabelObject.SetActive(false);
//         gameOverLabel.gameObject.SetActive(false);
//         gameClearLabel.gameObject.SetActive(false);
//         allItemsCollectedText.gameObject.SetActive(false);
//         countdownLabel.gameObject.SetActive(true);

//         foreach (GameObject heart in hearts)
//         {
//             heart.SetActive(true);
//         }

//         score = 0;
//         dangerWallHits = 0;
//         totalItems = 0;
//         gameClear = false;
//         remainingTime = timeLimit;
//         gameStarted = false;

//         StartCoroutine(UpdateItemCount());
//         StartCoroutine(StartCountdown());
//     }

//     IEnumerator StartCountdown()
//     {
//         int countdown = 3;
//         while (countdown > 0)
//         {
//             countdownLabel.text = countdown.ToString();
//             yield return new WaitForSeconds(1.0f);
//             countdown--;
//         }

//         countdownLabel.text = "Go!";
//         yield return new WaitForSeconds(1.0f);
//         countdownLabel.gameObject.SetActive(false);
//         gameStarted = true;
//         remainingTime = timeLimit;
//     }

//     public bool GameStarted()
//     {
//         return gameStarted;
//     }

//     IEnumerator UpdateItemCount()
//     {
//         yield return new WaitForSeconds(0.1f);
//         totalItems = GameObject.FindGameObjectsWithTag("Item").Length;
//         Debug.Log("Total items:" + totalItems);
//         UpdateScoreLabel();
//         UpdateItemsRemainingLabel();
//     }

//     void Update()
//     {
//         if (gameStarted && !gameClear)
//         {
//             remainingTime -= Time.deltaTime;
//             UpdateTimerLabel();

//             if (remainingTime <= 0)
//             {
//                 remainingTime = 0;
//                 GameOver();
//             }
//             else if (totalItems == 0)
//             {
//                 CheckGameClear();
//             }
//         }
//     }

//     void UpdateScoreLabel()
//     {
//         scoreLabel.text = "Score: " + score.ToString();
//         Debug.Log("Score updated:" + score);
//     }

//     void UpdateItemsRemainingLabel()
//     {
//         itemsRemainingLabel.text = "Items Remaining: " + totalItems.ToString();
//         Debug.Log("Items remaining updated:" + totalItems);
//     }

//     void UpdateTimerLabel()
//     {
//         timerLabel.text = "Time:" + Mathf.CeilToInt(remainingTime).ToString();
//     }

//     public void CollectItem()
//     {
//         if (!gameStarted) return;

//         score += 10; // アイテムごとのポイントを10と仮定
//         totalItems--;

//         UpdateScoreLabel();
//         UpdateItemsRemainingLabel();

//         if (!gameClear && totalItems == 0)
//         {
//             ShowAllItemsCollectedText();
//             Disableobjects();
//             CheckGameClear();
//         }
//     }

//     public void HitDangerWall()
//     {
//         if (!gameStarted) return;

//         score -= 5; // ペナルティポイントを5と仮定
//         dangerWallHits++;
//         Debug.Log("Danger wall hit. Score:" + score + ", Danger wall hits:" + dangerWallHits);

//         UpdateScoreLabel();
//         UpdateHeartIcons();

//         if (dangerWallHits >= 3)
//         {
//             GameOver();
//         }
//     }

//     void UpdateHeartIcons()
//     {
//         for (int i = 0; i < hearts.Length; i++)
//         {
//             hearts[i].SetActive(i < hearts.Length - dangerWallHits);
//         }
//     }

//     void GameOver()
//     {
//         gameOverLabelObject.SetActive(true);
//         gameOverLabel.gameObject.SetActive(true);
//         Debug.Log("Game over");
//         Time.timeScale = 0.0f; // これを設定することでゲームが再開できる
//     }

//     public void CheckGameClear()
//     {
//         // 全てのアイテムを回収した後、特定の場所に到達したかチェック
//         GameObject player = GameObject.FindWithTag("Player");
//         if (player != null && Vector3.Distance(player.transform.position, targetLocation.transform.position) < 1.0f)
//         {
//             Debug.Log("Player reached the target location");
//             GameClear();
//         }
//     }

//     void ShowAllItemsCollectedText()
//     {
//         allItemsCollectedText.gameObject.SetActive(true);
//         Debug.Log("ShowAll");
//     }

//     void Disableobjects()
//     {
//         foreach (GameObject obj in objectsToDisable)
//         {
//             obj.SetActive(false);
//             Debug.Log("Disableobjects");
//         }
//     }

//     void GameClear()
//     {
//         gameClear = true;
//         winnerLabelObject.SetActive(true);
//         gameClearLabel.gameObject.SetActive(true);
//         Debug.Log("Game cleared");
//         Time.timeScale = 0.0f; // これを設定することでゲームが再開できる
//     }

//     public void RestartGame(){
//         Time.timeScale = 1.0f;
//         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
//     }
// }
