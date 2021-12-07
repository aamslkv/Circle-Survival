using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerControl : MonoBehaviour
{
    public ControlType controlType;
    public Joystick joystick;

    public float speed;
    public int health;

    public enum ControlType { PC, Android}

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 moveVelocity;

    /***********************************************************/
    public Image hpBar;
    public Image expBar;

    public float experience;

    public int level = 1;
    public int skillPoint;

    public float fill;
    private float expDO;

    
   
    public GameObject textScoreCount;

    private Animator camAnim;
    public Animation _animTakeDamage;

    
    public int score;
    public int highScore;
    public GameObject coinCount;


    public Transform HpTarget;
    public GameObject slider;

    public bool game_over = false;

    public Sprite[] Skins;

    private SoundEffector soundEffector;
    public GameObject effect;

    void Awake()
    {
        if (PlayerPrefs.HasKey("SaveScore"))
        {
            highScore = PlayerPrefs.GetInt("SaveScore");
        }
    }

    void Start()
    {
        StaticCoins._Coins = PlayerPrefs.GetInt("_Coins", StaticCoins._Coins);
        soundEffector = FindObjectOfType<SoundEffector>();

        camAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
        _animTakeDamage = gameObject.GetComponent<Animation>();

        rb = GetComponent<Rigidbody2D>();
        if(controlType == ControlType.PC)
        {
            joystick.gameObject.SetActive(false);
        }

        SkinManager();
    }

    public void Update()
    {
       

        if (controlType == ControlType.PC)
        {
            moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        } else if (controlType == ControlType.Android)
        {
            moveInput = new Vector2(joystick.Horizontal, joystick.Vertical);
        }
        
        moveVelocity = moveInput.normalized * speed;

        if(health <= 0)
        {
            game_over = true;
            Instantiate(effect, this.transform.position, Quaternion.identity);
            soundEffector.Play_PlayerExplosionSound();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        hpBar.fillAmount = health / 100.0f;

        coinCount.GetComponent<Text>().text = StaticCoins._Coins.ToString();

        textScoreCount.GetComponent<Text>().text = "Score : " + score.ToString();

        if (level != 10) 
        { 
            expBar.fillAmount = experience / fill;

            if (expBar.fillAmount >= 1)
            {
                if (experience > fill)
                {
                    expDO = experience - fill;
                    experience = 0;
                    experience = experience + expDO;
                }
                else if (experience <= fill)
                {
                    experience = 0;
                }
                fill = fill + 50.0f;
                level += 1;
                skillPoint += 1;
            }
        }
        else if (level == 10)
        {
            experience = (int)fill;
        }

        

        slider.transform.position = HpTarget.position; // Camera.main.WorldToScreenPoint(HpTarget.transform.position); //screenPos; //  Vector3.MoveTowards(slider.transform.position, screenPos, 10f * Time.deltaTime);
        HighScore();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

    public void ChangeHealth (int healthValue)
    {
        camAnim.SetTrigger("shke");
        _animTakeDamage.Play();
        health += healthValue;
    }

    public void TakeExp(int exp)
    {
        experience += exp;   
        score += exp * 10;
    }

    private void SkinManager()
    {
        if (PlayerPrefs.GetString("_SkinManager", StaticCoins._SkinManager) == "default")
        {
            this.GetComponent<SpriteRenderer>().sprite = Skins[0];
        }
        else if (PlayerPrefs.GetString("_SkinManager", StaticCoins._SkinManager) == "swastika")
        {
            this.GetComponent<SpriteRenderer>().sprite = Skins[1];
        }
        else if (PlayerPrefs.GetString("_SkinManager", StaticCoins._SkinManager) == "chmo")
        {
            this.GetComponent<SpriteRenderer>().sprite = Skins[2];
        }
        else if (PlayerPrefs.GetString("_SkinManager", StaticCoins._SkinManager) == "neon")
        {
            this.GetComponent<SpriteRenderer>().sprite = Skins[3];
        }
        else if (PlayerPrefs.GetString("_SkinManager", StaticCoins._SkinManager) == "lolipop")
        {
            this.GetComponent<SpriteRenderer>().sprite = Skins[4];
        }
        else if (PlayerPrefs.GetString("_SkinManager", StaticCoins._SkinManager) == "arbuz")
        {
            this.GetComponent<SpriteRenderer>().sprite = Skins[5];
        }
    }

    public void HighScore()
    {
        if (score > highScore)
        {
            highScore = score;

            PlayerPrefs.SetInt("SaveScore", highScore);
        }
    }

}
