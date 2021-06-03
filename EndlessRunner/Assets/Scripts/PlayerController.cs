using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public static GameObject player;
    public static GameObject currentPlatform;
    public GameObject homeButton;
    bool canTurn = false;
    public Rigidbody rb;
    Vector3 startPosition;
    public static bool isDead = false;
    private Vector3 playerPos;

    private SkinnedMeshRenderer skinmesh;
    public Material[] skinMaterials;

    public float speed = 0.1f;

    public static AudioSource[] sfx;

    
    public GameObject magicSpell;
    public Transform magicSpellStartPosition;
    Rigidbody magicRb;

    int livesLeft;
    [Header("Icons")]
    public Texture aliveIcon;
    public Texture deadIcon;
    public RawImage[] icons;

    [Header("Panels")]
    public GameObject gameOverPanel;
    public GameObject movementPanel;
    public GameObject jumpPanel;
    [Header("Text")]
    public Text highscoreText;

    bool falling = false;

    private Vector3 inputVector;
    private float leftPos = 1f;
    private float rightPos = -1f;
    private float centerPos = 0f;

    [Header("Starting platform number")]
    public int runDummyAmount;

    bool isgrounded = true;
    private Vector2 startTouchPosition, endTouchPosition;
    private float verticalVector, horizontalVector;

    [Header("Buttons")]
    public Button moveLeft;
    public Button moveRight;
    public Button jump;

    [Header("Collider")]
    public Collider playerCollider;

    //App store IDs
    string googlePLayId = "3961981";
    string appleId = "3961980";
    //Ads in test mode
    //bool testMode = true;

    [Header("Particle Prefab")]
    public GameObject heartEffect;
    //reload the scene when player dies

    private float xMoveSpeed = 0.5f;
    void RestartGame()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    private void OnEnable()
    {
        playerCollider.enabled = playerCollider.enabled;
    }

    private void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.tag == "Ground")
        {
            isgrounded = true;
            animator.SetBool("IsJumping", false);
        }

        if ((falling || collision.gameObject.tag == "Fire" || collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Train") && !isDead)
        {
            if (falling)
            {
                animator.SetTrigger("isFalling");
            }
            else
            {
                animator.SetTrigger("isDead");
            }
                isDead = true;
                sfx[6].Play();
                livesLeft--;
                PlayerPrefs.SetInt("lives", livesLeft);


            if(livesLeft > 0)
            {
                Invoke("RestartGame", 2);
            }
            else
            {
                icons[0].texture = deadIcon;
                homeButton.SetActive(true);
                gameOverPanel.SetActive(true);
                movementPanel.SetActive(false);
                jumpPanel.SetActive(false);
                

                PlayerPrefs.SetInt("lastscore", PlayerPrefs.GetInt("score"));
                if (PlayerPrefs.HasKey("highscore"))
                {
                    int highscore = PlayerPrefs.GetInt("highscore");
                    if(highscore < PlayerPrefs.GetInt("score"))
                    {
                        PlayerPrefs.SetInt("highscore", PlayerPrefs.GetInt("score"));
                    }
                }
                else
                {
                    PlayerPrefs.SetInt("highscore", PlayerPrefs.GetInt("score"));
                }
                Advertisement.Show();
            }
            
        }
        else
        {
            currentPlatform = collision.gameObject;
        }

        if (collision.gameObject.tag == "Tree")
        {
            Vector3 newPos = (rb.position - playerPos).normalized * 0.3f;
            this.transform.Translate(newPos);

        }

    }
    private void Awake()
    {
        //Initialise ads
        InitialiseAds();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("PlayerGameSpeed"))
        {
            Time.timeScale = PlayerPrefs.GetFloat("PlayerGameSpeed");
        }
        else
        {
            Time.timeScale = 1f;
        }


        animator = this.GetComponent<Animator>();
        player = this.gameObject;
        //rb = GetComponent<Rigidbody>();
        magicRb = magicSpell.GetComponent<Rigidbody>();
        //skinmesh
        skinmesh = GetComponentInChildren<SkinnedMeshRenderer>();
        int skinNumber = PlayerPrefs.GetInt("CharSkins");
        skinmesh.material = skinMaterials[skinNumber];
        //skinmesh end
        sfx = GameObject.FindWithTag("GameData").GetComponentsInChildren<AudioSource>();

        startPosition = player.transform.position;

        //Start World generation
        for (int i = 1; i <= runDummyAmount; i++)
        {
            GenerateWorld.RunDummy();
        }


        

        isDead = false;
        //Gets the max number of lives at the start of the game
        livesLeft = PlayerPrefs.GetInt("lives");

        //changing icons when the player lives has changed
        for(int i = 0; i < icons.Length; i++)
        {
            if(i >= livesLeft)
            {
                icons[i].texture = deadIcon;
            }
        }

        if (PlayerPrefs.HasKey("highscore"))
        {
            //highscoreText.text = "High score: " + PlayerPrefs.GetInt("highscore");
            highscoreText.text = "" + PlayerPrefs.GetInt("highscore");
        }
        else
        {
            //highscoreText.text = "High score: 0";
            highscoreText.text = "0";
        }
    }

    void InitialiseAds()
    {
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            Advertisement.Initialize(appleId);
        }else if(Application.platform == RuntimePlatform.Android)
        {
            Advertisement.Initialize(googlePLayId);
        }
        else if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            Advertisement.Initialize(appleId);
        }
    }

    private void FixedUpdate()
    {
        playerPos = rb.position;
    }
    void CastMagic()
    {
        magicSpell.transform.position = magicSpellStartPosition.position;
        magicSpell.SetActive(true);
        magicRb.AddForce(this.transform.forward * 4000);
        Invoke("KillMagic", 1);
    }

    void PlayMagicSound()
    {
        sfx[7].Play();
    }

    void KillMagic()
    {
        magicSpell.SetActive(false);
    }

    public void Footstep1()
    {
        sfx[4].Play();
    }

    public void Footstep2()
    {
        sfx[3].Play();
    }


    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.tag == "Heart")
        {
            RestoreLife();
            GameObject heartParticle = Instantiate(heartEffect, this.transform.position, Quaternion.identity);
            Destroy(heartParticle, 2f);
        }

        if(other.gameObject.tag == "Barrier" || other.gameObject.tag == "Crate")
        {

        animator.SetTrigger("isDead");
        isDead = true;
        sfx[6].Play();
        livesLeft--;
        PlayerPrefs.SetInt("lives", livesLeft);
            if (livesLeft > 0)
            {
                Invoke("RestartGame", 2);
            }
            else
            {
                icons[0].texture = deadIcon;
                homeButton.SetActive(true);
                gameOverPanel.SetActive(true);
                movementPanel.SetActive(false);
                jumpPanel.SetActive(false);
                
                

                PlayerPrefs.SetInt("lastscore", PlayerPrefs.GetInt("score"));
                if (PlayerPrefs.HasKey("highscore"))
                {
                    int highscore = PlayerPrefs.GetInt("highscore");
                    if (highscore < PlayerPrefs.GetInt("score"))
                    {
                        PlayerPrefs.SetInt("highscore", PlayerPrefs.GetInt("score"));
                    }
                }
                else
                {
                    PlayerPrefs.SetInt("highscore", PlayerPrefs.GetInt("score"));
                }
                Advertisement.Show();
            }
        }

        if(other is BoxCollider && GenerateWorld.lastPlatform.tag != "platformTSection")
        {
            GenerateWorld.RunDummy();
        }
        
        if(other is SphereCollider)
        {
            canTurn = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other is SphereCollider)
        {
            canTurn = false;
        }
    }

    // Update is called once per frame

    void Update()
    {
        if (isDead) return;

        if (currentPlatform != null)
        {
            if (this.transform.position.y < (currentPlatform.transform.position.y - 5))
            {
                falling = true;
                OnCollisionEnter(null);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && animator.GetBool("isMagic") == false)
        {
            if (isgrounded)
            {
                animator.SetBool("IsJumping", true);
                rb.AddForce(Vector3.up * 400);
                sfx[2].Play();
                isgrounded = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.M) && animator.GetBool("isJumping") == false)
        {
            animator.SetBool("IsMagic", true);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && canTurn)
        {
            this.transform.Rotate(Vector3.up * 90);
            GenerateWorld.dummyTraveller.transform.forward = -this.transform.forward;
            GenerateWorld.RunDummy();
            if (GenerateWorld.lastPlatform.tag != "platformTSection")
            {
                GenerateWorld.RunDummy();
            }
            this.transform.position = new Vector3(startPosition.x, this.transform.position.y, startPosition.z);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && canTurn)
        {
            this.transform.Rotate(Vector3.up * -90);
            GenerateWorld.dummyTraveller.transform.forward = -this.transform.forward;
            GenerateWorld.RunDummy();
            if (GenerateWorld.lastPlatform.tag != "platformTSection")
            {
                GenerateWorld.RunDummy();
            }
            this.transform.position = new Vector3(startPosition.x, this.transform.position.y, startPosition.z);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            //this.transform.Translate(-1f, 0, 0);

            //inputVector = new Vector3(Input.GetAxisRaw("Horizontal") * -5f, 0, Input.GetAxisRaw("Vertical"));
            //rb.velocity = inputVector;

            MoveLeft();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            MoveRight();
        }
        //else if (Input.GetButtonDown("moveLeft"))
        //{
        //    MoveLeft();
        //}
        //else if (Input.GetButtonDown("moveRight"))
        //{
        //    MoveRight();
        //}
        //else if (Input.GetButtonDown("jump"))
        //{
        //    Jump();
        //}
        if(PauseMenu.GameIsPaused == false)
        {
            //Need a horizontal & vertical vector for swipes
            //If vertical vector is > horizontal vector then jump
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                startTouchPosition = Input.GetTouch(0).position;
            }
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                endTouchPosition = Input.GetTouch(0).position;

                verticalVector = startTouchPosition.y - endTouchPosition.y;
                horizontalVector = startTouchPosition.x - endTouchPosition.x;
                
                if(Mathf.Abs(horizontalVector) > Mathf.Abs(verticalVector))
                {
                    if(horizontalVector > 0)
                    {
                        MoveLeft();
                    }
                    else
                    {
                        MoveRight();
                    }
                }
                else
                {
                    if(verticalVector < 0)
                    {
                        Jump();
                    }
                }
            }
        }

    }
    public void Jump()
    {
        if (isgrounded)
        {
            animator.SetBool("IsJumping", true);
            rb.AddForce(Vector3.up * 400);
            sfx[2].Play();
            isgrounded = false;
        }
    }

    public void MoveLeft()
    {
        if(this.transform.position.x != leftPos)
        {
            this.transform.Translate(-1f, 0, 0);
            
            //if(this.transform.position.x == centerPos)
            //{
            //    LeanTween.moveX(this.gameObject, leftPos, xMoveSpeed);
            //}else if(this.transform.position.x == rightPos)
            //{
            //    LeanTween.moveX(this.gameObject, centerPos, xMoveSpeed);
            //}
        }
    }

    public void MoveRight()
    {
        if(this.transform.position.x != rightPos)
        {
            this.transform.Translate(1f, 0, 0);
            //if(this.transform.position.x == centerPos)
            //{
            //    LeanTween.moveX(this.gameObject, rightPos, xMoveSpeed);
            //}else if(this.transform.position.x == leftPos)
            //{
            //    LeanTween.moveX(this.gameObject, centerPos, xMoveSpeed);
            //}
        }
    }

    void StopJumpingAnimation()
    {
        animator.SetBool("IsJumping", false);
    }

    void StopMagicUse()
    {
        animator.SetBool("IsMagic", false);
    }

    public void RestoreLife()
    {
        if (livesLeft == 3) return;
        if(livesLeft == 1)
        {
            icons[1].texture = aliveIcon;
            livesLeft++;
            PlayerPrefs.SetInt("lives", livesLeft);
        }else if(livesLeft == 2)
        {
            icons[2].texture = aliveIcon;
            livesLeft++;
            PlayerPrefs.SetInt("lives", livesLeft);
        }

    }

}
