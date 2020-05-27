using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wukongScript : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;//Así referenciamos el componente que deseamos modificar
    public float rotSpeed;

    public Vector3 dir;
    public Vector3 dira;
    public Vector3 targ;

    public static bool W;
    public static bool S;
    public static bool A;
    public static bool D;

    public Animator anime;
    public Transform saqChild;

    public bool fire;
    public bool isFire;
    public float eyp;
    public float eypa;
    public float fixEyp;
    public float fixEypa;
    public float delta;
    public float deltaa;
    public float deltaAng;
    public float ang;
    public float anga;
    public float clampDelta;
    public bool toNeg;
    public bool EulerLock;
    public float deltaInf;
    public float deltaSup;

    public float radiOffset;
    public float radiOffset1;

    public float Bforce;
    public float Bforce1;
    public Vector3 obj;
    public float DeltaY1;
    public float DeltaY;
    public float DeltaX;
    public float DeltaZ;
    public float DeltaXa;
    public float DeltaZa;
    public float DeltaXb;
    public float DeltaZb;
    public float DeltaXc;
    public float DeltaZc;
    public float DeltaXd;
    public float DeltaZd;
    public Transform Target;
    public Transform Rec1;
    public Transform Rec2;
    public Transform RecM;
    public float unitario1 = 2.6f;
    public float unitario2 = 3.0f;
    public float unitario3;

    public float radians;
    public float radiansis;
    public float radianseis;
    public float radFax;
    public float radFax1 = -1.31f;
    public float radFax2;
    public float radiansa;
    public float radFaxa;
    public float deltaRad;
    public float deltaRadFaxa;

    public float deltaMult = 1.5f;

    public bool move;

    public bool PcVersion = true;
    public Transform TargetPc;
    public Transform TargetPcFixed;
    public Transform Rec1Pc;
    public Transform Rec2Pc;
    public float angFix;
    public Vector2 offset;
    public Vector3 dist;
    public float distOffset;
    public Transform AlwaysRot;
    public Transform Auxi;
    public Rigidbody rBull;

    void Start()
    {
        //saqChild = this.gameObject.transform.GetChild(0);//obtiene primer hijo
        //anime = saqChild.GetComponent<Animator>();
    }

    public void Shesen()
    {
        Rigidbody rigmod;
        if (PcVersion == false)
        {
            rigmod = Instantiate(rBull, Rec1.position, Rec1.rotation) as Rigidbody;
            obj = Rec2.position - Rec1.position;
            obj.Normalize();
            rigmod.AddForce(obj * Bforce);
            rigmod.name = "bala lanzada";
            isFire = false;
        }
        if (PcVersion)
        {
            dist = TargetPc.position - transform.position;
            rigmod = Instantiate(rBull, Rec1Pc.position, AlwaysRot.rotation) as Rigidbody;
            if (dist.magnitude > distOffset)
            {
                obj = TargetPc.position - Rec1Pc.position;//Ajustado para el puntero
                obj = new Vector3(obj.x, 0, obj.z);//Diferencia es igual a 0 para corregir pequeña elevación
                obj.Normalize();
                rigmod.AddForce(obj * Bforce);
            }
            else
            {
                obj = Rec2Pc.position - Rec1Pc.position;//Ajustado para el puntero
                obj.Normalize();
                rigmod.AddForce(obj * Bforce);
            }
            rigmod.name = "bala lanzada";
            isFire = false;
        }
    }

    void Update()
    {
        //Activar, desavtivar
        if (Input.GetKey(KeyCode.P))
        {
            if (PcVersion == true)
                PcVersion = false;
            else
                PcVersion = true;
        }

        //ang = JoystickRight.angle;
        //anga = JoystickLeft.angle;

        //fire = JoystickRight.touch;
        //move = JoystickLeft.touch;

        if (PcVersion)
        {
            offset.x = TargetPc.position.x - transform.position.x;
            offset.y = TargetPc.position.z - transform.position.z;
            offset.Normalize();
            ang = Mathf.Atan2(offset.y, offset.x) + angFix;
            ang *= Mathf.Rad2Deg;

            if (ang > 180)
            {
                ang -= 180 * 2;
            }
        }

        //Fuego
        if (fire && isFire == false)
        {
            isFire = true;

            Invoke("Shesen", 0.1f);
        }
        //Movimiento


        if (move)
            anime.SetBool("walk", true);
        if (move == false)
            anime.SetBool("walk", false);

        //Mouse


        eyp = transform.rotation.eulerAngles.y;

        if (eyp >= 0)
        {
            fixEyp = 180 - eyp;
        }
        if (eyp < 0)
        {
            fixEyp = -180 - eyp;
        }

        delta = ang - fixEyp;

        if ((fixEyp > 90 && fixEyp <= 180) && (ang >= -180 && ang <= -90))
        {
            delta += 180 * 2;
        }

        if ((fixEyp < -90 && fixEyp >= -180) && (ang >= 90 && ang <= 180))
        {
            delta -= 180 * 2;
        }

        clampDelta = delta / 180;


        anime.SetFloat("Euler", clampDelta);
        //Animación
        deltaAng = ang - anga;

        if (fire)
        {
            anime.SetBool("Shoot", true);
        }

        if (fire == false)
        {
            anime.SetBool("Shoot", false);
        }
    }


    void FixedUpdate()
    {


        radians = ang * Mathf.Deg2Rad;
        radians += radFax;
        DeltaX = Mathf.Cos(radians);
        DeltaZ = Mathf.Sin(radians);

        radiansa = anga * Mathf.Deg2Rad;
        radiansa += radFaxa;
        DeltaXa = Mathf.Cos(radiansa);
        DeltaZa = Mathf.Sin(radiansa);

        deltaRad = deltaAng * Mathf.Deg2Rad;
        deltaRad += deltaRadFaxa;
        DeltaXb = Mathf.Cos(deltaRad);
        DeltaZb = Mathf.Sin(deltaRad);

        radiansis = ang * Mathf.Deg2Rad;
        radiansis += radFax1;
        DeltaXc = Mathf.Cos(radiansis);
        DeltaZc = Mathf.Sin(radiansis);

        radianseis = ang * Mathf.Deg2Rad;
        radianseis += radFax2;
        DeltaXd = Mathf.Cos(radianseis);
        DeltaZd = Mathf.Sin(radianseis);

        anime.SetFloat("Deltx", DeltaXb);
        anime.SetFloat("Delty", DeltaZb);


        //Objetos de posición

        Auxi.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        if (fire == false)
            Auxi.rotation = transform.rotation;

        if (PcVersion == false)
        {
            Rec1.position = new Vector3((transform.position.x + DeltaX * unitario1), (transform.position.y - DeltaY), (transform.position.z + DeltaZ * unitario1));
            Rec2.position = new Vector3((transform.position.x + DeltaXc * unitario2), (transform.position.y - DeltaY), (transform.position.z + DeltaZc * unitario2));
            Target.position = new Vector3((transform.position.x + DeltaXc * unitario2), transform.position.y, (transform.position.z + DeltaZc * unitario2));
            Rec1.LookAt(Rec2);
        }

        if (PcVersion == true)
        {
            TargetPcFixed.position = new Vector3(TargetPc.position.x, transform.position.y, TargetPc.position.z);
            Rec1Pc.position = new Vector3((transform.position.x + DeltaX * unitario1), (transform.position.y - DeltaY), (transform.position.z + DeltaZ * unitario1));
            Rec2Pc.position = new Vector3((transform.position.x + DeltaXd * unitario2), (transform.position.y - DeltaY), (transform.position.z + DeltaZd * unitario2));
            AlwaysRot.position = transform.position;
            AlwaysRot.LookAt(TargetPcFixed);
        }

        RecM.position = new Vector3((transform.position.x + DeltaXa * unitario1), transform.position.y, (transform.position.z + DeltaZa * unitario1));


        if (move)
        {
            targ = RecM.position;
            dira = targ - transform.position;
            rb.MovePosition(transform.position + (dira * speed * Time.deltaTime));

            if (fire == false)
                transform.LookAt(new Vector3(RecM.position.x, transform.position.y, RecM.position.z));
        }

        //Disparar quieto
        if (move == false && fire == true)
        {
            if (PcVersion == false)
            {
                if (delta < deltaInf | delta > deltaSup)
                {
                    dir = Target.position - transform.position;
                    Quaternion rip = Quaternion.LookRotation(dir, Vector3.up);
                    transform.rotation = Quaternion.Lerp(transform.rotation, rip, rotSpeed * Time.deltaTime);
                }
                if (delta < deltaInf * deltaMult | delta > deltaSup * deltaMult)
                {
                    transform.LookAt(Target);
                }
            }
            if (PcVersion)
            {
                if (delta < deltaInf | delta > deltaSup)
                {
                    dir = TargetPcFixed.position - transform.position;
                    Quaternion rip = Quaternion.LookRotation(dir, Vector3.up);
                    transform.rotation = Quaternion.Lerp(transform.rotation, rip, rotSpeed * Time.deltaTime);
                }
                if (delta < deltaInf * deltaMult | delta > deltaSup * deltaMult)
                {
                    transform.LookAt(TargetPcFixed);
                }
            }

        }

        //Disparar en movimiento

        if (move == true && fire)
        {
            if (PcVersion == false)
                transform.LookAt(Target);
            if (PcVersion)
                transform.LookAt(TargetPcFixed);

        }
    }

}
