using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class GameController : MonoBehaviour {
	public static int score; 

	Text scoreText;
	Text finalScoreText;

    PlayerHealthController playerHealth;
    GameObject player;
    GameObject platformController;
    GameObject startPlaneObject; 
	GameObject problemSolverObject; 	
    TestSpawner testSpawner;
    public bool gameended = false;
    public bool gamestarted = false;
    bool loading = false;
    bool startingPlay = true; 

    float restartTimer;
	float restartDelay = 3f;
    float beginningTimer;
    float beginningDelay = 2f;

    Animator startAnim; 

	// Use this for initialization
	void Start () {
        player.GetComponent<FirstPersonCharacter>().enabled = false;

    }

    void Awake ()
	{

		// Set up the reference.
		GameObject stui = GameObject.Find ("ScoreTextUI");
		scoreText = stui.GetComponent<Text>();
        platformController = GameObject.Find("PlatformController");
        testSpawner = platformController.GetComponent<TestSpawner>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealthController>();

		problemSolverObject = GameObject.Find ("ProblemSolver"); 



		// Reset the score.
        score = 0;
        GameObject canvas = GameObject.Find("Canvas");
        startAnim = canvas.GetComponent<Animator>();

		GameObject edui = GameObject.Find("FinalScoreText");
		finalScoreText = edui.GetComponent<Text>();
		
	}
	
	
	void Update ()
	{
		if(startingPlay){
			if(Input.GetKeyUp(KeyCode.Return)){
				StartGame();
			}
		}

        if (loading)
        {
            // ... tell the animator the game is over.
            startAnim.SetTrigger("StartGame");

            // .. increment a timer to count up to restarting.
            beginningTimer += Time.deltaTime;

            // .. if it reaches the restart delay...
            if (beginningTimer >= beginningDelay)
            {
                Debug.Log("TriggeringStart");
                loading = false;
                StartGame();
            }
        }
		// Set the displayed text to be the word "Score" followed by the score value.
		scoreText.text = "Score: " + score;
		finalScoreText.text = scoreText.text;

        if (playerHealth.currentHealth <= 0)
            InitializeEndGame();

		if (Input.GetKeyUp(KeyCode.Backspace) && !gameended)
			RestartGame();
		
		if (gameended)
		{
			restartTimer += Time.deltaTime;
			
			// .. if it reaches the restart delay...
			if (restartTimer >= restartDelay)
			{
				// .. then reload the currently loaded level.
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}
	
	void InitializeEndGame()
	{
		startAnim.SetTrigger("EndGame");
		player.GetComponent<FirstPersonCharacter>().enabled = false;
		player.GetComponent<Rigidbody>().useGravity = false;

		//Destroy all platforms
		testSpawner.StopMovement();
		problemSolverObject.SetActive(false); 
		
}
	
public void RestartGame(){
	gameended = true;	
}


public void EndGame(){
	gameended = true;
	Debug.Log("gameended");
	if (PlayerHealthController.instantDeath)
	{
		EndGameInstantly();
        }
        else
        {
            restartTimer += Time.deltaTime;

            // .. if it reaches the restart delay...
            if (restartTimer >= restartDelay)
            {
                // .. then reload the currently loaded level.
                Application.LoadLevel(Application.loadedLevel);
            }

            player.GetComponent<FirstPersonCharacter>().enabled = false;
            player.GetComponent<Rigidbody>().useGravity = false;
            //player.GetComponent<Shoot>().enabled = false; 

            //Destroy all platforms
            testSpawner.StopMovement();


        }


    }

    void EndGameInstantly()
    {
        restartTimer += Time.deltaTime;

        // .. if it reaches the restart delay...
        if (restartTimer >= restartDelay)
        {
            // .. then reload the currently loaded level.
            Application.LoadLevel(Application.loadedLevel);
        }

        player.GetComponent<FirstPersonCharacter>().enabled = false;
        //player.rigidbody.useGravity = false;

        //Destroy all platforms
        testSpawner.StopMovement();
    }

    public void StartGame()
    {
        //Start Animation


        if (startingPlay)
        {
            if (!gamestarted && !loading)
            {
                gamestarted = true;
                loading = true;
            }
            else
            {
                //loading false start true
                Debug.Log("Spawning and Enabling Player");
                player.GetComponent<FirstPersonCharacter>().enabled = true;
                testSpawner.StartGeneration();
                startingPlay = false;
            }
        }

    }
}
