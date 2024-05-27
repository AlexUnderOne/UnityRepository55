using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScriptTwo : MonoBehaviour
{
    [SerializeField] float playerSpeed = 10f;
    [SerializeField] int playerHealth;
    int maxHealth;

    [SerializeField] GameObject bullet;
    [SerializeField] Transform shootPosition;
    [SerializeField] float timeBetweenShoot;
    float shootTimer;
    Rigidbody2D rigidBodyPlayer;

    SpriteRenderer spritePlayerScale;

    Animator animationOne;


    [SerializeField] GameObject hitEffect;
    public static ScriptTwo instance;
    [SerializeField] Sprite[] spriteGunFlash;
    [SerializeField] SpriteRenderer SPRspriteGunFlash;
    Vector2 movePlayer;
    Vector2 moveVelocity;

    [SerializeField] Slider healthSlider;
    [SerializeField] Slider dashSlider;

    [SerializeField] ParticleSystem footParticle;
    [SerializeField] GameObject deathPanel;

    [SerializeField] float dashSpeed = 10f, dashCooldown = 2f, dashDuration = 0.25f;
    bool isDashing;
    bool canDash;
    bool canDamage;

    [SerializeField] TextMeshProUGUI coinText;
    [SerializeField] public int currentMoney = 1000;

    private void Awake()
    {
        instance = this;
    }
    public void Start()
    {
        animationOne = GetComponent<Animator>();
        rigidBodyPlayer = GetComponent<Rigidbody2D>();
        shootTimer = timeBetweenShoot;
        maxHealth = playerHealth;
        spritePlayerScale = GetComponent<SpriteRenderer>();
        canDash = true;
        canDamage = true;
        updateHealthUI();
        
    }

    void Update()
    {
        if (isDashing == true)
        {
            return;
        }
        methodMovePlayer();
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }

        shootTimer += Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && shootTimer >= timeBetweenShoot)
        {

            gunShoot();
            shootTimer = 0;
        }

        
        if (timeBetweenShoot - shootTimer < 0) return;

    }



    private void FixedUpdate()
    {
        if (isDashing == true)
        {
            return;
        }
        dashSlider.value = System.Convert.ToSingle(canDash);
        //dashSlider.value =  dashDuration / dashCooldown;


    }



    public void methodMovePlayer()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        movePlayer = new Vector2(moveX, moveY).normalized;
        if (movePlayer != Vector2.zero)
        {
            animationOne.SetBool("run", true);
            CreateTrail();
            //footParticle.Pause();
            //footParticle.Play();
            //var emission = footParticle.emission;
            //emission.rateOverTime = 10;
        }
        else
        {
            animationOne.SetBool("run", false);
           
            //var emission = footParticle.emission;
            //emission.rateOverTime = 0;


        }

        ScalePlayer(movePlayer.x);
        rigidBodyPlayer.velocity = new Vector2 ( movePlayer.x * playerSpeed , movePlayer.y * playerSpeed);

       // rigidBodyPlayer.MovePosition(rigidBodyPlayer.position + moveVelocity * Time.fixedDeltaTime);
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        canDamage = false;
        rigidBodyPlayer.velocity = new Vector2(movePlayer.x * dashSpeed, movePlayer.y * dashSpeed);
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;

        yield return new WaitForSeconds(dashCooldown);
        canDamage = true;
        canDash = true;
        
    }





    void ScalePlayer(float x)
    {
        if (x == 1)
        {
            spritePlayerScale.flipX = false;
        }
        else if (x == -1)
            spritePlayerScale.flipX = true;



    }
    void gunShoot()
    {
        Instantiate(bullet, shootPosition.position, shootPosition.rotation);
        StartCoroutine(nameof(flashGun));
    }

    IEnumerator flashGun()
    {
        SPRspriteGunFlash.enabled = true;


        yield return new WaitForSeconds(0.1f);
        SPRspriteGunFlash.enabled = false;
    }
    public void Damage(int damage)
    {
        if (canDamage == false)
        {
            return;
        }
        playerHealth -= damage;

        Instantiate(hitEffect, transform.position, Quaternion.identity);
        CameraFollow.instance.cameraShake();

        updateHealthUI();
        if (playerHealth <= 0)
        {
            Destroy(gameObject);
            deathPanel.SetActive(true);
        }
            
    }

    void updateHealthUI()
    {
        healthSlider.value = (float)playerHealth / maxHealth;
    }

    void CreateTrail()
    {
        footParticle.Play();
    }
    
     public void AddMoney(int value)
    {
        currentMoney += value;
        coinText.text = " монеты: " + currentMoney.ToString() ;
    }
}


