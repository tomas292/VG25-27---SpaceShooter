
using UnityEngine;

public class Player : Damageable
{
    [SerializeField] float speed = 5;
    Vector3 destination;
    [SerializeField] private Bullet bullet;

    [SerializeField] float pewpewRate = 3;
    [SerializeField] private int playerDamage = 1;
   
   void Start()
    {
        InvokeRepeating("PewPew", 0, pewpewRate); 
    }
    void Update()
    {
        Movement();
    }

    void FixedUpdate()
    {
        Vector3 positionInBetween = Vector3.Lerp(transform.position, destination, speed*Time.fixedDeltaTime);
        transform.position = positionInBetween;
    }


        void PewPew()
    {
        Bullet newbullet = Instantiate(bullet, transform.position, Quaternion.identity);
        newbullet.SetDamage(playerDamage);
    }

    public void Increment(StatType stat)
    {
        if(stat == StatType.Damage)
        {
            playerDamage++;
        }
        if(stat == StatType.Speed)
        {
            
        }
    }

    void Movement()

    {
        Camera cam = Camera.main;


        if(Input.touchSupported && Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector3 pos = cam.ScreenToWorldPoint(new Vector3(touch.position.x,touch.position.y,cam.nearClipPlane));

            pos.z = transform.position.z;

            destination = pos;
        }

        else if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.nearClipPlane));

            mousePos.z = transform.position.z;

            destination = mousePos;
        }
       
    }

}
