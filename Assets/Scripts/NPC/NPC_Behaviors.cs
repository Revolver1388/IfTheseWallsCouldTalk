using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Behaviors : MonoBehaviour
{
    [SerializeField] public TennantSelector myStats;
    public int meanIncome;
    [SerializeField]
    Room_Class temp;
    bool clean = false;
    bool fix = false;
    [SerializeField] ParticleSystem[] ps;
    [SerializeField] Sprite[] gender;
    #region movement Stuff
    [SerializeField] Transform myRoom;
    [SerializeField] Transform[] FirstFloorAOI;
    [SerializeField] Transform[] SecondFloorAOI;
    int currentLocation = 0;
    SpriteRenderer sprite;
    [SerializeField] float speed = 1;
    [SerializeField] public Room_Class[] stairs;
    bool stairTravel = false;
    [SerializeField] bool bathroom = false;
    [SerializeField] Animator bathroomDoor;
    [SerializeField] SpriteRenderer happyMetre;
    [SerializeField] Sprite[] happy;
    [SerializeField] Animator anim;
    [SerializeField] Animator anim_Metre;
    [SerializeField] public bool[] hasDisplayed = { false, false, false, false };// 1 = likes, 2 = dislikes, 3 = Happyness, 4= 
    bool isHappy = false;
    bool isStairs = false;
    bool happySad;
    bool moving = true;
    #endregion
    int i = 0;

    void Start()
    {
        happyMetre.gameObject.SetActive(false);
        sprite = GetComponentInChildren<SpriteRenderer>();
        ps = GetComponentsInChildren<ParticleSystem>();
    }
    private void OnEnable()
    {        
        meanIncome = Random.Range(myStats.incomeMax, myStats.incomeMin);
        sprite.sprite = myStats.gender ? gender[1] : gender[0];
        anim.SetBool("New Bool", moving);
        anim.SetBool("male", myStats.gender);
    }
    // Update is called once per frame
    void Update()
    {
        bathroomDoor.SetBool("Bool", bathroom);
        if (clean)
        {
            moving = false;
            if (myStats.cleanliness >= 6 && myStats.cleanliness < 8) StartCoroutine(Cleanning(10, temp));
            else if (myStats.cleanliness >= 8 && myStats.cleanliness <= 10) StartCoroutine(Cleanning(7, temp));
            else if (myStats.cleanliness >= 6 && myStats.like == "Cleanning") StartCoroutine(Cleanning(10, temp));
        }
        else if (fix)
        {
            moving = false;
            if (myStats.handyness >= 6 && myStats.handyness < 8) StartCoroutine(Fixing(10, temp));
            else if (myStats.handyness >= 8 && myStats.handyness <= 10) StartCoroutine(Fixing(7, temp));
            else if (myStats.cleanliness >= 6 && myStats.like == "Fixing Things") StartCoroutine(Fixing(10, temp));
        }

    }
    //  "Cooking" "TV" "Fixing Things" "Quiet" "Drinking" "Gardening" "Working Out" "Cosmetics" "Cleanning"}

    public void ManageHappiness(float y)
    {
        if (this.gameObject.activeSelf && !isHappy)
        {
            isHappy = true;
            myStats.happiness += y;
            if (isHappy) { StartCoroutine(HappySign()); }

            if (y > 0) { happyMetre.sprite = happy[0]; happySad = true; }
            else if (y < 0) { happyMetre.sprite = happy[1]; happySad = false; }
            anim_Metre.SetBool("isHappy", happySad);
        }
        else
            return;
    }

    IEnumerator HappySign()
    {
       
        happyMetre.gameObject.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        happyMetre.gameObject.SetActive(false);
        isHappy = false;
    }

    IEnumerator Cleanning(float t, Room_Class x)
    {
        clean = false;
        print("cleanning");
        yield return new WaitForSeconds(t);
        x.roomState = Room_Class.RoomState.Fixed_Clean;
        moving = true;
    }

    IEnumerator Fixing(float t, Room_Class x)
    {
        StartCoroutine(MovingAround(ps[0], t));
        fix = false;
        yield return new WaitForSeconds(t);
        ps[1].Play();
        x.roomState = Room_Class.RoomState.Fixed_Clean;
        moving = true;
    }

    IEnumerator MovingAround(ParticleSystem p, float t)
    {
        yield return new WaitForSeconds(0.2f);
        p.Play();
        yield return new WaitForSeconds(t);
        p.Stop();
    }

    IEnumerator Wait()
    {
        moving = false;
        yield return new WaitForSeconds(3);
        currentLocation = Random.Range(0, FirstFloorAOI.Length);
        moving = true;
        Move();
    }
    IEnumerator StairCooldown()
    {
        isStairs = true;
        yield return new WaitForSeconds(2);
        isStairs = false;
    }
    private void Move()
    {
        if (transform.position.x != FirstFloorAOI[currentLocation].transform.position.x)
        {
          transform.position = Vector3.MoveTowards(transform.position, new Vector3(FirstFloorAOI[currentLocation].transform.position.x, transform.position.y, transform.position.z), speed * Time.deltaTime);
          moving = true;
        }
        if (transform.position.x == FirstFloorAOI[currentLocation].transform.position.x) StartCoroutine(Wait());
        if (FirstFloorAOI[currentLocation].transform.position.x > transform.position.x) FlipSprite(true);
        else FlipSprite(false);
    }

    void FlipSprite(bool M)
    {
        sprite.flipX = M;
    }

    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject != null && c.gameObject.tag != "Movement") { temp = c.gameObject.GetComponent<Room_Class>(); CheckHappiness(); }
        if (!temp) return;
    }

    private void OnTriggerStay2D(Collider2D c)
    {
        if (c.gameObject.tag == "Movement" && !clean && !fix) Move();    
    }


    void CheckHappiness()
    {
        if (temp.roomType != Room_Class.RoomType.Stairwell)
        {
            if (myStats.happiness >= 0.5f)
            {
                if (temp.roomState == Room_Class.RoomState.Fixed_Dirty)
                {
                    if (myStats.cleanliness >= Random.Range(6, 10))
                    {

                        if (myStats.cleanliness >= 6 && myStats.like.Contains("Cleanning")) { ManageHappiness(0.1f); print(":D Cleaning the " + temp.roomType); clean = true; }
                        else if (myStats.dislikes.Contains("Cleanning")) { ManageHappiness(-0.2f); print(":O GROSS!! Im not cleaning that up"); }
                        else { ManageHappiness(-0.1f); print(":( Cleanning the " + temp.roomType); clean = true; }
                    }
                    else print(":| This " + temp.GetComponent<Room_Class>().roomType + " is a mess");
                    return;
                }            
                if (temp.roomState == Room_Class.RoomState.Broken && temp.roomType != Room_Class.RoomType.Stairwell)
                {
                    if (myStats.handyness >= Random.Range(6, 10))
                    {
                        if (myStats.handyness >= 6 && myStats.like.Contains("Fixing Things")) { ManageHappiness(0.1f); print(":D Fixing the " + temp.roomType); fix = true; }
                        else if (myStats.dislikes.Contains("Fixing Things")) { ManageHappiness(-0.2f); print(":O GROSS!! Im not fixing that up"); }
                        else { ManageHappiness(-0.1f); print(":( Fixxing the " + temp.roomType); fix = true; }
                    }
                    else print(":| This " + temp.roomType + " is wrecked");
                    return;
                }
                else
                    return;
            }
            //else if (myStats.happiness <= 0.4f) return;
        }
        if (temp.roomType == Room_Class.RoomType.Stairwell && !isStairs)
        {
            int randomChance = Random.Range(0, 100);
            if (randomChance >= 51)
            {
                if (temp.gameObject == stairs[0].gameObject && temp.roomState == Room_Class.RoomState.Fixed_Clean) transform.position = SecondFloorAOI[0].transform.position;
                else if (temp.gameObject == stairs[1].gameObject && stairs[0].roomState == Room_Class.RoomState.Fixed_Clean) transform.position = FirstFloorAOI[3].transform.position;
                StartCoroutine(StairCooldown());
            }
        }
    }
}
    public class NamedBoolean
    {
        [SerializeField] string name;
        [SerializeField] bool boolean;
    }
