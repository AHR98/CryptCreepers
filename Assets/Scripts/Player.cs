using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    
    [SerializeField] Transform aim;
    [SerializeField] Camera cameraGame;
    [SerializeField] float fireRate = 1;
    [SerializeField] Transform bulletPrefab;
    [SerializeField] int health = 10;
    [SerializeField] SpriteRenderer spriteRenderPlayer;
    [SerializeField] float invulnerableTime = 3;
    public float speed = 5;
    Vector3 movePosition;
    Vector2 facingDirection;
    bool isLoaded = true;
    float horizontal;
    float vertical;
    int numOfBullets = 1;
    bool invulnerable;
    [SerializeField] Animator animPlayer;
    public int Health
    {
        get => health;
        set {
            health = value;
            UIManager.instance.updateUIHealth(health);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        // GameManager.instance.Dummy();

    }

    // Update is called once per frame
    void Update()
    {
  
        float angleOfCamera;
        Quaternion targetRotation;
        //Player movement
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        movePosition.x = horizontal;
        movePosition.y = vertical;
        transform.position += movePosition * Time.deltaTime * speed;
        
        //Aim movement
        facingDirection = cameraGame.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        aim.position = transform.position + (Vector3)facingDirection.normalized;

        animPlayer.SetFloat("Speed", movePosition.magnitude);

        //Bullets
        if (Input.GetMouseButton(0) && isLoaded && numOfBullets <= 5) //Left button of the mouse
        {
                     
            angleOfCamera = Mathf.Atan2(facingDirection.y, facingDirection.x) * Mathf.Rad2Deg;
            targetRotation = Quaternion.AngleAxis(angleOfCamera, Vector3.forward);
            Instantiate(bulletPrefab, transform.position, targetRotation);
            isLoaded = false;
            StartCoroutine(ReloadGun());
            numOfBullets ++;   
        }
        else if(numOfBullets >= 5)
        {
            StartCoroutine(reloadBullets());
           
        }
        if(aim.position.x > transform.position.x)
        {
            spriteRenderPlayer.flipX = true;
        }
        else if(aim.position.x < transform.position.x)  
        {
            spriteRenderPlayer.flipX = false;
        }
    }

    IEnumerator ReloadGun()
    {
        yield return new WaitForSeconds(2/fireRate);
        isLoaded = true;
        
    }
     
    IEnumerator reloadBullets()
    {
        
        yield return new WaitForSeconds(5);
        isLoaded = true;
        numOfBullets = 1;
    } 

    public void TakeDamage()
    {
        if(invulnerable)
        {
            return;
        }
        Health--;
        invulnerable = true;
        StartCoroutine(makeVulnerableAgain());
        if (Health <= 0)
        {
            //Game over
            GameManager.instance.isGameOver = true;
            UIManager.instance.showGameOverScreen();
        }
    
    }

    IEnumerator makeVulnerableAgain()
    {
        yield return new WaitForSeconds(invulnerableTime);
        invulnerable = false;
    }
}
