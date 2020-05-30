using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speedPc;
    public float speedAnd;
    public float rotSpeed;
    public Vector3 normal;
    public bool canJump;
    public float jumpForce;
    public Vector3 jumpDirection;
    public float gravity = 14.0f;

    public float timer1;//DashTimer
    public float dashForce;
    public bool IsDash;
    public GameObject[] DashTrail;
    public GameObject DashMonitor;//Avisa si no es posible realizar el dash o si debe detenerse inmediatamemnte

    public bool IsExternalForce;

    public Rigidbody rb;//Así referenciamos el componente que deseamos modificar
    public Animator anime;

    public static bool W;
    public static bool S;
    public static bool A;
    public static bool D;

    public Vector3 dir;
    public Vector3 dira;
    public Vector3 targ;

    public Transform RecM;
    public Transform TargetPc;

    //8 posibles TargetPc

    public Transform Norte;
    public Transform NorEste;
    public Transform Este;
    public Transform SurEste;
    public Transform Sur;
    public Transform SurOeste;
    public Transform Oeste;
    public Transform NorOeste;

    public float radiansa;
    public float radFaxa;

    public float unitario1;
    public float DeltaXa;
    public float DeltaZa;

    //comunicación Joystick
    public bool PcVersion = true;
    public float anga;
    public bool move;
    public float velMult;

    public float velUmbral;

    public float yOffset;

    public float xVel;
    public float yVel;
    public float zVel;

    public float xVela;
    public float yVela;
    public float zVela;

    public float axisTol;
    public float axisTolDown = -0.5f;
    public float axisTolPlane = 0.5f;

    public int contactos;
    public int contactosTol = 4;

    public static bool wolfTouch;// USAR SOLO EN ESTE PROYECTO
    public static bool dragonTouch;// USAR SOLO EN ESTE PROYECTO
    public GameObject contadore;// USAR SOLO EN ESTE PROYECTO
    public bool wolfMonitor;

    public bool notMove;
    public float timerMove = 1.5f;

    //Dash fix
    public GameObject dashCollider;
    public float DashFixTimer = 1.0f;
    public bool DashNoConsecutivo;
    //public int DashSend;
    //public int DashRec;
    public int DashTiming = 0;
    public int timing = 120;
    public float timeningDash = 0.1f;

    //Jump Fix
    public bool jumpNoConsecutivo;


    void Start()
    {
        dashCollider.SetActive(false);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wolf")
        {
            //print("SOLO DE ESTE PROYECTO");
            Gmanager.pisada = 1;
            if(other.gameObject.GetComponent<condSon>().atck == false)
            {
                wolfTouch = true;
                wolfMonitor = wolfTouch;
            }

        }
        if (other.gameObject.tag == "Dragon")
        {
            dragonTouch = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        //print("SOLO DE ESTE PROYECTO OTHIA");
        if (other.gameObject.tag == "Wolf")
        {
            wolfTouch = false;
            wolfMonitor = wolfTouch;
            if (canJump == true)
                Gmanager.pisada = 0;
        }
        if (other.gameObject.tag == "Dragon")
        {
            dragonTouch = false;
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "floor")
        {
            contactos++;
            //print("SOLO DE ESTE PROYECTO");
            if(wolfTouch == false)
            Gmanager.pisada = 0;
        }

        if (other.gameObject.tag == "floor" & yVel <= axisTol & canJump == false)
        {
            ResetJump();
            anime.SetBool("Jump", false);

        }

    }
    public void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "floor")
            contactos--;
    }
    public void OnCollisionStay(Collision other)//Evita bug de quedar saltando
    {
        if (other.gameObject.tag == "floor" & yVel <= axisTol & canJump == true)
        {
            anime.SetBool("Jump", false);
            jumpNoConsecutivo = false;//Evita bug de salto consecutivo

        }
    }


    public void EndDash()
    {
        //Stop Dash
        //if (IsDash & other.gameObject.tag == "floor" & contactos >= contactosTol)
        {
            //print("hi");
            {
                StopAllCoroutines();
                rb.useGravity = true;
                anime.SetBool("dash", false);
                IsDash = false;
                dashCollider.GetComponent<dashDetector>().choque = false;
                dashCollider.SetActive(false);
                
                foreach (GameObject item in DashTrail)
                {
                    item.SetActive(false);

                }
            }
        }
    }
    public void CanaMove()
    {
        StartCoroutine(CanMove());
    }

    public IEnumerator CanMove()
    {
        yield return new WaitForSeconds(timerMove);
        {
            notMove = false;
        }
    }
    public void ResetJump()//Impide bug visual entre las animaciones de saltar, que salte con la animación de aterrizar
    {
        canJump = true;


        //jumpNoConsecutivo = false;
    }


    public void spawnDash()
    {
        {
            print("fun");
            if (Input.GetMouseButtonDown(1) & DashMonitor.GetComponent<dashDetector>().choque == false & notMove == false & DashNoConsecutivo == false)//Impide el dash si ya existe una colison
            {
                print("execute");
                DashNoConsecutivo = true;
                //DashSend += 1;
                //StartCoroutine(DashFixer());
                DashTiming = timing;


                gameObject.GetComponent<SfxManager>().Play("dash");

                anime.Play("Dash");// Salta directo a la animación especificada
                foreach (GameObject item in DashTrail)
                {
                    item.SetActive(true);
                }


                anime.SetBool("dash", true);
                IsDash = true;
                StartCoroutine(Dash());
                move = true;
                rb.useGravity = false;

                contadore = GameObject.FindGameObjectWithTag("Manager");
                FindObjectOfType<contador>().dash++;
                //Debug.Log("usar solo en este proyecto");
            }
        }
    }

    void Update()
    {
        if (DashTiming > 0)
            DashTiming -= 1;
        else
            DashNoConsecutivo = false;

        //Dash
        if (Input.GetMouseButtonDown(1))
        {
            //Tapar con muros invisibles para tapar lugares dónde no quieres que se meta el personaje
            print("send");
            dashCollider.SetActive(true);
            spawnDash();
        }



        //ang = JoystickRight.angle;
        anga = MoveJoystick.angle;
        velMult = MoveJoystick.velPerc;

        //fire = JoystickRight.touch;
        if(IsDash == false)
        {
            move = MoveJoystick.touch;

            //Movimiento
            if (move)
            {
                if (PcVersion == true)
                {
                    anime.SetBool("run", true);
                }

                if (PcVersion == false)
                {
                    if (velMult > velUmbral)
                    {
                        anime.SetBool("walk", false);
                        anime.SetBool("run", true);
                    }

                    if (velMult <= velUmbral)
                    {
                        anime.SetBool("walk", true);
                        anime.SetBool("run", false);
                    }
                }

            }
            if (move == false)
            {
                anime.SetBool("walk", false);
                anime.SetBool("run", false);
            }


            //Version Pc
            if (PcVersion)
            {
                //Determinar el blanco según teclado

                if (anga == 0)
                    TargetPc = Este;
                if (anga == 45)
                    TargetPc = NorEste;
                if (anga == 90)
                    TargetPc = Norte;
                if (anga == 135)
                    TargetPc = NorOeste;
                if (anga == 180 | anga == -180)
                    TargetPc = Oeste;
                if (anga == -135)
                    TargetPc = SurOeste;
                if (anga == -90)
                    TargetPc = Sur;
                if (anga == -45)
                    TargetPc = SurEste;

                TargetPc.position = new Vector3(TargetPc.position.x, transform.position.y, TargetPc.position.z);


            }
        }

        if (notMove == true)//Bug no moverse y seguir con animación de movimiento
        {
            move = false;
            anime.SetBool("Jump", false);
            anime.SetBool("dash", false);
            anime.SetBool("run", false);
            anime.SetBool("walk", false);
        }


        //Jump

        xVel = rb.velocity.x;
        yVel = rb.velocity.y;
        zVel = rb.velocity.z;

        xVela = transform.InverseTransformDirection(rb.velocity).x;
        yVela = transform.InverseTransformDirection(rb.velocity).y;
        zVela = transform.InverseTransformDirection(rb.velocity).z;

        if(IsExternalForce == false)
        {

        //Bug de quedar rotando y deslizandoce sin rose por colisión
        if (xVel > axisTolPlane)
            rb.constraints = RigidbodyConstraints.FreezePosition;
        if (zVel > axisTolPlane)
            rb.constraints = RigidbodyConstraints.FreezePosition;

        if (xVel < -axisTolPlane)//Menor a valor negativo
            rb.constraints = RigidbodyConstraints.FreezePosition;
        if (zVel < -axisTolPlane)
            rb.constraints = RigidbodyConstraints.FreezePosition;

        if (xVel <= axisTolPlane & zVel <= axisTolPlane)
            rb.constraints = RigidbodyConstraints.None;
        }

        //arrastre indeseado al chocar con otra plataforma
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;

        //  GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX;
        //if (zVel > axisTol)
        //GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
        //if (xVel < axisTol)
        // GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        //GetComponent.< Rigidbody > ().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY;
        //rb.velocity = Vector3.zero;

        if (yVel > axisTol) //Bug de super salto
        {
            canJump = false;
            //anime.SetBool("Jump", true);
        }
        if (yVel < axisTolDown & canJump == true)//dejarse caer y quitar salto
        {
            canJump = false;
            if (anime.GetCurrentAnimatorStateInfo(0).IsName("Jumping"))//Si ya esta saltando, la resetea inmediatamente
                anime.Play("Jumping");
            else
                anime.SetBool("Jump", true);//Si no esta con la animacion de salto, activa el bool
        }

        if (yVel < axisTol & yVel > axisTolDown) //bug de caer y quedar saltando
        {
            canJump = true;

            //anime.SetBool("Jump", false);

        }


        if (Input.GetKeyDown(KeyCode.Space)) //Salto
        {
            if (canJump & notMove == false & IsDash == false & jumpNoConsecutivo == false)
            {
                jumpNoConsecutivo = true;
                //StartCoroutine(JumpFix());

                gameObject.GetComponent<SfxManager>().Play("jump");

                canJump = false;
                anime.SetBool("Jump", true);
                rb.AddForce(jumpDirection * jumpForce);

                if (anime.GetCurrentAnimatorStateInfo(0).IsName("ConsecutiveJump"))
                    {
                        anime.Play("ConsecutiveJump1");
                    }

                //if (anime.GetCurrentAnimatorStateInfo(0).IsName("Jump") | anime.GetCurrentAnimatorStateInfo(0).IsName("Jumping") | anime.GetCurrentAnimatorStateInfo(0).IsName("ConsecutiveJump"))

                {
                    anime.Play("ConsecutiveJump");
                }

                contadore = GameObject.FindGameObjectWithTag("Manager");
                FindObjectOfType<contador>().jump++;
                //Debug.Log("usar solo en este proyecto");
            }
        }
        //Is external force
        if(IsExternalForce)
            anime.Play("Damage");
    }
    //IEnumerator DashFixer()
    //{
        //print("fixDash");
        //yield return new WaitForSeconds(DashFixTimer);
        //{
          //  {
            //DashNoConsecutivo = false;
                //DashRec += 1;
                //print("reset");
        //    }
      //  }
    //}
        IEnumerator Dash()
    {

        yield return new WaitForSeconds(timer1);
        {
            if (IsDash)
            {

                rb.useGravity = true;
                anime.SetBool("dash", false);
                IsDash = false;
                dashCollider.SetActive(false);
                
                foreach (GameObject item in DashTrail)
                {
                    item.SetActive(false);
                }
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Bug reset dash no consecutivo
        //if (DashSend == DashRec)
        {
            //DashRec = +1;
            //DashNoConsecutivo = false;
        }
        //Fall speed
        if (canJump == false)//Permite una caida más pesada y agradable
        {
            rb.AddForce(-jumpDirection * gravity *Time.deltaTime);
            //rb.MovePosition(transform.position + ((jumpDirection - transform.position) * gravity * Time.deltaTime));
        }

        radiansa = anga * Mathf.Deg2Rad;
        radiansa += radFaxa;

        DeltaXa = Mathf.Cos(radiansa);
        DeltaZa = Mathf.Sin(radiansa);

        RecM.position = new Vector3((transform.position.x + DeltaXa * unitario1), transform.position.y, (transform.position.z + DeltaZa * unitario1));//debe compartir coordenada y, de otro modo habra desalineacion y saltos, ojo congelar rotaciones en X y Z.

        if(notMove == false)
        {
            if (move & PcVersion & IsExternalForce == false)//Desconecta mandos para dejar ejercer fuerza
            {
                //Rotación
                dir = TargetPc.position - transform.position;
                Quaternion rap = Quaternion.LookRotation(dir, Vector3.up);
                transform.rotation = Quaternion.Lerp(transform.rotation, rap, rotSpeed * Time.deltaTime);
                if (IsDash)
                {
                    targ = TargetPc.position;
                    dira = targ - transform.position;
                    normal = dira.normalized;
                    rb.MovePosition(transform.position + (dira * dashForce * Time.deltaTime));
                    //Genera vibración al avanzar y rotar la cámara
                    //transform.LookAt(new Vector3(TargetPc.position.x, transform.position.y, TargetPc.position.z));
                }
                else
                {
                    targ = TargetPc.position;
                    dira = targ - transform.position;
                    normal = dira.normalized;//Velocidad constante para cualquier index del teclado
                    rb.MovePosition(transform.position + (normal * speedPc * Time.deltaTime));
                    //Genera vibración al avanzar y rotar la cámara
                    //transform.LookAt(new Vector3(TargetPc.position.x, transform.position.y, TargetPc.position.z));
                }

            }
            if (move & PcVersion == false & IsExternalForce == false)
            {
                targ = RecM.position;
                dira = targ - transform.position;
                rb.MovePosition(transform.position + (dira * speedAnd * velMult * Time.deltaTime));
                transform.LookAt(new Vector3(RecM.position.x, transform.position.y, RecM.position.z));
            }
        }
        
    }
}
