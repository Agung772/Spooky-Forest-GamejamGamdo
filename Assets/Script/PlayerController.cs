using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public bool antiMati, iniTanah;
    public Transform playerDesign;
    //Move ------------------------
    public float speedWalkingPlayer, speedRunPlayer, jumpForce, speedLadder, energy, flashLight;
    public float energyRegen, speedPlayer, flashLightRegen;
    public bool useEnergy, useFlashLight;
    public bool PlayerOperation, useParticleAbu, useGravity, nonGravityDanPergerakan;
    float vertical, positionZ;
    public float horizontalInput;
    Vector3 direction;

    public float gravity = -9.81f;
    private float directionY;
    CharacterController characterController;


    public Vector3 posisiPlayer;

    //UI ----------------------------
    public Image energyUI, backEnergyUI, flashlightUI;
    //Animasi -----------------------
    public Animator animator;
    //Particle
    public ParticleSystem abuParticle, abuParticle2;
    public GameObject senterIdle, senterWalking, senterLadder;
    public GameObject flashLightAll;
    int conditionSenter;
    //Refrens
    public NpcController npcController;
    public SensorGroundPlayer SensorGroundPlayer;

    //-----------------------------------------------------------------------------------
    bool cooldownSfxWalking;
    //-----------------------------------------------------------------------------------
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        PlayerOperation = true;
        directionY = 0;
    }
    void Start()
    {
        
        useGravity = true;
        speedPlayer = speedWalkingPlayer;
        energyRegen = energy;
        flashLightRegen = flashLight;

        posisiPlayer = transform.position;
        positionZ = transform.position.z;

        animator.SetBool("Idle", true);
    }


    void Update()
    {
        if (PlayerOperation)
        {
            MovePlayer();
            FreezePosition();
            Energy();
            FlashLight();
        }
        else
        {
            GravityPlayer();
        }
        if (nonGravityDanPergerakan) NonGravityDanPergerakan();


    }

    //------------------------------------------------------------------------------------
    void NonGravityDanPergerakan()
    {
        speedPlayer = 0;
    }
    void GravityPlayer()
    {
        directionY += gravity * Time.deltaTime;
        if (useGravity) direction.y = directionY;

        direction.x = 0;
        characterController.Move(direction * speedPlayer * Time.deltaTime);
    }
    void MovePlayer()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        direction = new Vector3(horizontalInput, vertical, 0);

        //Jump ---------------------------------------------------------------------------
        if (characterController.isGrounded)
        {
            directionY = 0;




        }
        if (SensorGroundPlayer.Ground)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                directionY = jumpForce;
                if (horizontalInput != 0)
                {
                    animator.SetTrigger("Jump");
                }
                else if (horizontalInput == 0)
                {
                    animator.SetTrigger("IdleJump");
                }

                SensorGroundPlayer.Ground = false;

                //Particle
                abuParticle.Stop();

                //Audio
                if (iniTanah)
                {
                    AudioManager.instance.SfxJumpTanah();
                }
                else if (!iniTanah)
                {
                    AudioManager.instance.SfxJumpRumah();
                }
            }
        }


        directionY += gravity * Time.deltaTime;
        if (useGravity) direction.y = directionY;


        characterController.Move(direction * speedPlayer * Time.deltaTime);

        //Animasi -------------------------------------------------------------------------
        if (horizontalInput != 0)
        {
            animator.SetBool("Walking", true);
            animator.SetBool("Idle", false);

            //Particle
            if (useParticleAbu)
            {
                abuParticle.Play();
                useParticleAbu = false;
            }
            //Senter
            if (conditionSenter == 1)
            {
                senterIdle.SetActive(false);
                senterWalking.SetActive(true);
                senterLadder.SetActive(false);

                conditionSenter = 0;
            }



            //NPC
            if (npcController != null)
            {
                npcController.TrailOff();
            }

            //Audio

            

        }
        else
        {
            animator.SetBool("Walking", false);
            animator.SetBool("Idle", true);

            //Particle
            if (!useParticleAbu)
            {
                abuParticle.Stop();
                useParticleAbu = true;
            }
            //Senter
            if (conditionSenter == 0)
            {
                senterIdle.SetActive(true);
                senterWalking.SetActive(false);
                senterLadder.SetActive(false);

                conditionSenter = 1;
            }


            //NPC
            if (npcController != null)
            {
                npcController.TrailOn();
            }


        }
        //Flip --------------------------------------------------------------------------
        if (horizontalInput < 0)
        {
            playerDesign.localEulerAngles = new Vector3 (0, 180, 0);
            //NPC
            if (npcController != null)
            {
                npcController.FlipNPCRight();
            }
            //UI
            energyUI.rectTransform.localPosition = new Vector3(315, energyUI.rectTransform.localPosition.y, energyUI.rectTransform.localPosition.z);
            backEnergyUI.rectTransform.localPosition = new Vector3(315, backEnergyUI.rectTransform.localPosition.y, backEnergyUI.rectTransform.localPosition.z);
            //Senter
            senterIdle.transform.localEulerAngles = new Vector3(senterIdle.transform.localEulerAngles.x, -160, senterIdle.transform.localEulerAngles.z);
            senterWalking.transform.localPosition = new Vector3(-1.9f, senterWalking.transform.localPosition.y, senterWalking.transform.localPosition.z);
            senterWalking.transform.localEulerAngles = new Vector3(senterWalking.transform.localEulerAngles.x, -90, senterWalking.transform.localEulerAngles.z);
        }
        else if (horizontalInput > 0)
        {
            playerDesign.localEulerAngles = Vector3.zero;
            //NPC
            if (npcController != null)
            {
                npcController.FlipNPCLeft();
            }
            //UI
            energyUI.rectTransform.localPosition = new Vector3(-315, energyUI.rectTransform.localPosition.y, energyUI.rectTransform.localPosition.z);
            backEnergyUI.rectTransform.localPosition = new Vector3(-315, backEnergyUI.rectTransform.localPosition.y, backEnergyUI.rectTransform.localPosition.z);
            //Senter
            senterIdle.transform.localEulerAngles = new Vector3(senterIdle.transform.localEulerAngles.x, 160, senterIdle.transform.localEulerAngles.z);
            senterWalking.transform.localPosition = new Vector3(1.9f, senterWalking.transform.localPosition.y, senterWalking.transform.localPosition.z);
            senterWalking.transform.localEulerAngles = new Vector3(senterWalking.transform.localEulerAngles.x, 90, senterWalking.transform.localEulerAngles.z);
        }
        //Run ---------------------------------------------------------------------------
        if (energyRegen >= 0 && horizontalInput != 0 && SensorGroundPlayer.Ground)
        {     
            if (Input.GetKeyDown(KeyCode.LeftShift) && energyRegen >= energy / 3)
            {
                speedPlayer = speedRunPlayer;
                animator.SetBool("Run", true);
                useEnergy = true;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                speedPlayer = speedWalkingPlayer;
                animator.SetBool("Run", false);
                useEnergy = false;
            }
        }
        else if (energyRegen <= 0 || horizontalInput == 0 || !SensorGroundPlayer.Ground)
        {
            speedPlayer = speedWalkingPlayer;
            animator.SetBool("Run", false);
            useEnergy = false;
        }

    }
    void Energy()
    {
        energyRegen = Mathf.Clamp(energyRegen, 0, energy);
        if (useEnergy)
        {
            energyRegen -= Time.deltaTime * 2;
        }
        else if (!useEnergy)
        {
            energyRegen += Time.deltaTime / 3;
        }
        energyUI.fillAmount = energyRegen / energy;

    }

    void FlashLight()
    {
        flashLightRegen = Mathf.Clamp(flashLightRegen, 0, flashLight);
        if (Input.GetKeyDown(KeyCode.G) && !useFlashLight && flashLightRegen > 0)
        {
            useFlashLight = true;
        }
        else if (Input.GetKeyDown(KeyCode.G) && useFlashLight || flashLightRegen <= 0)
        {
            useFlashLight = false;
        }

        if (useFlashLight)
        {
            flashLightRegen -= Time.deltaTime / 4;
            flashLightAll.SetActive(true);
        }
        else if (!useFlashLight)
        {
            flashLightAll.SetActive(false);
        }
        flashlightUI.fillAmount = flashLightRegen / flashLight;
    }

    void FreezePosition()
    {   
        transform.position = new Vector3(transform.position.x, transform.position.y, positionZ);
    }

    public void RefrensNpcController()
    {
        npcController = GameObject.FindGameObjectWithTag("NPC").GetComponent<NpcController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {

            //Particle
            abuParticle2.Play();
            useParticleAbu = true;
        }
    }
    bool cooldownNotif;
    private void OnTriggerEnter(Collider other)
    {
        if (!antiMati)
        {
            if (other.CompareTag("Obstacle") || other.CompareTag("Kunti"))
            {
                if (!cooldownNotif)
                {
                    cooldownNotif = true;
                    GameManager.instance.PlayerDeath();
                    NotifikasiManager.instance.SpawnDeath();
                    AudioManager.instance.SfxDeath();
                }


            }
        }

    }
    private void OnTriggerStay(Collider other)
    {
        vertical = Input.GetAxisRaw("Vertical");

        if (other.CompareTag("Ladder") && vertical > 0)
        {
            gravity = 0;
            useGravity = false;


        }
        else if (other.CompareTag("Ladder") && vertical < 0)
        {
            gravity = 0;
            useGravity = false;

        }

        //Animasi
        if (other.CompareTag("Ladder") && vertical != 0)
        {
            animator.SetBool("Ladder", true);
            animator.SetBool("IdleLadder", true);

            //Senter
            if (conditionSenter == 0 || conditionSenter == 1)
            {
                senterIdle.SetActive(false);
                senterWalking.SetActive(false);
                senterLadder.SetActive(true);

                conditionSenter = 2;
            }

        }
        else if (other.CompareTag("Ladder") && vertical == 0)
        {
            animator.SetBool("Ladder", false);
        }

        //Senter tuas
        if (other.CompareTag("Tuas") && Input.GetKeyDown(KeyCode.F))
        {
            //Senter
            if (conditionSenter == 0 || conditionSenter == 1)
            {
                senterIdle.SetActive(false);
                senterWalking.SetActive(false);
                senterLadder.SetActive(true);

                conditionSenter = 2;
            }
        }



    }
    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Ladder"))
        {
            gravity = -9.81f;
            useGravity = true;
            //Animasi
            animator.SetBool("IdleLadder", false);
            animator.SetBool("Ladder", false);

            conditionSenter = 1;
        }

        //Senter tuas
        if (other.CompareTag("Tuas"))
        {
            conditionSenter = 1;
        }

    }

    //Reset Posisi Kunti
    KuntiSensor[] kuntiSensor;
    private void OnDisable()
    {
        GameObject[] kunti;
        kunti = GameObject.FindGameObjectsWithTag("KuntiSensor");
        kuntiSensor = new KuntiSensor[kunti.Length];
        for (int i = 0; i < kunti.Length; i++)
        {

            kuntiSensor[i] = kunti[i].GetComponent<KuntiSensor>();
            kuntiSensor[i].BackSpawn();
        }
    }
    private void OnEnable()
    {
        cooldownNotif = false;
    }

}
