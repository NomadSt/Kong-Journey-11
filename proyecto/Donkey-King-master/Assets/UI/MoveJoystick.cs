using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveJoystick : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public Vector3 m_StartPos;
    public Vector2 pointA;
    public Vector2 pointB;
    public Vector2 offset;
    public Vector2 direction;
    public static bool touch;
    public float radio = 1.0f;
    public float mag;
    public static float angle;
    public float ang;
    public static Vector2 sharedDirR;
    public static float velPerc;
    public float velocityPer;

    public bool kei;
    public string[] CtrlOrder;
    public int curPos;//posicion actual de contador
    public bool W = false;
    public bool A = false;
    public bool S = false;
    public bool D = false;
    public int ax;
    public Vector2 oldOffset;
    public Vector2 newOffset;
    public Vector2 newDir;
    public Vector2 angProm;

    public GameObject pej;

    public void Start()
    {
        m_StartPos = transform.localPosition;
        pej = GameObject.FindGameObjectWithTag("Wukong");
    }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.W) | Input.GetKeyUp(KeyCode.A) | Input.GetKeyUp(KeyCode.S) | Input.GetKeyUp(KeyCode.D))
        {
            //Ordenar orden de teclas en arreglo
            kei = false;
            touch = false;
            transform.localPosition = m_StartPos;

            pointB = pointA;
            offset = new Vector2(0, 0);
            direction = new Vector2(0, 0);
            sharedDirR = direction;
            mag = direction.magnitude;
        }

        if(pej.GetComponent<Player>().notMove == false)//Solo si es que puede moverse
        {
            if (Input.GetKey(KeyCode.W))
                W = true;
            if (Input.GetKey(KeyCode.A))
                A = true;
            if (Input.GetKey(KeyCode.S))
                S = true;
            if (Input.GetKey(KeyCode.D))
                D = true;
        }



        if (Input.GetKeyDown(KeyCode.W))
        {
            CtrlOrder[curPos] = "W";
            curPos += 1;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            CtrlOrder[curPos] = "A";
            curPos += 1;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            CtrlOrder[curPos] = "S";
            curPos += 1;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            CtrlOrder[curPos] = "D";
            curPos += 1;
        }


        if (Input.GetKeyUp(KeyCode.W))
        {
            W = false;
            curPos -= 1;

            for (int i = 0; i < 4; i++)
            {
                if (CtrlOrder[i] == "W")
                    CtrlOrder[i] = "";
            }
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            A = false;
            curPos -= 1;
            for (int i = 0; i < 4; i++)
            {
                if (CtrlOrder[i] == "A")
                    CtrlOrder[i] = "";
            }
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            S = false;
            curPos -= 1;
            for (int i = 0; i < 4; i++)
            {
                if (CtrlOrder[i] == "S")
                    CtrlOrder[i] = "";
            }
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            D = false;
            curPos -= 1;
            for (int i = 0; i < 4; i++)
            {
                if (CtrlOrder[i] == "D")
                    CtrlOrder[i] = "";
            }
        }

        //BUG AVANCE EN DIAGONAL CON 1 TECLA
        if (curPos < 0)
            curPos = 0;

        for (int ii = 0; ii < 4; ii++)
        {
            for (int k = 0; k < 4; k++)
            {
                if (CtrlOrder[k] == "")
                    CtrlOrder[k] = CtrlOrder[k + 1];

            }
            for (int j = 0; j < 4; j++)
            {
                if (CtrlOrder[j] == CtrlOrder[j + 1])
                    CtrlOrder[j + 1] = "";
            }
        }
    }

    public void FixedUpdate()
    {


        if (curPos <= 1) //toma este valor al tener pulsada solo 1 tecla
        {
            ax = 0;
            if (CtrlOrder[ax] == "W")
            {
                kei = true;
                touch = true;
                transform.localPosition = new Vector2(m_StartPos.x, m_StartPos.y + radio);

                direction = new Vector2(0.0f, radio);
                sharedDirR = direction;

                angle = 90;
                ang = angle;
            }

            if (CtrlOrder[ax] == "A")
            {
                kei = true;
                touch = true;
                transform.localPosition = new Vector2(m_StartPos.x - radio, m_StartPos.y);

                direction = new Vector2(radio, 0.0f);
                sharedDirR = direction;

                angle = 180;
                ang = angle;
            }

            if (CtrlOrder[ax] == "S")
            {
                kei = true;
                touch = true;
                transform.localPosition = new Vector2(m_StartPos.x, m_StartPos.y - radio);

                direction = new Vector2(0.0f, -radio);
                sharedDirR = direction;

                angle = -90;
                ang = angle;
            }

            if (CtrlOrder[ax] == "D")
            {
                kei = true;
                touch = true;
                transform.localPosition = new Vector2(m_StartPos.x + radio, m_StartPos.y);

                direction = new Vector2(-radio, 0.0f);
                sharedDirR = direction;

                angle = 0;
                ang = angle;
            }
        }

        if (curPos >= 2) //toma ese valor al pulsarse una segunda tecla

        {
            ax = curPos - 1;
            kei = true;
            touch = true;

            newOffset = new Vector2(m_StartPos.x, m_StartPos.y);
            angle = 0;
            newDir = new Vector2(0.0f, 0.0f);
            angProm = new Vector2(0.0f, 0.0f);

            if (CtrlOrder[ax] == "W" | CtrlOrder[ax - 1] == "W")
            {
                newOffset += new Vector2(0, radio);
                newDir += new Vector2(0.0f, radio);
                if (angProm[0] == 0)
                    angProm[0] = 90;
                else
                    angProm[1] = 90;
            }

            if (CtrlOrder[ax] == "A" | CtrlOrder[ax - 1] == "A")
            {
                newOffset += new Vector2(-radio, 0);
                newDir += new Vector2(radio, 0.0f);
                if (angProm[0] == 0)
                    angProm[0] = 180;
                else
                    angProm[1] = 180;
            }

            if (CtrlOrder[ax] == "S" | CtrlOrder[ax - 1] == "S")
            {
                newOffset += new Vector2(0, -radio);
                newDir += new Vector2(0.0f, -radio);
                if (angProm[0] == 0)
                    angProm[0] = -90;
                else
                    angProm[1] = -90;
            }

            if (CtrlOrder[ax] == "D" | CtrlOrder[ax - 1] == "D")
            {
                newOffset += new Vector2(radio, 0);
                newDir += new Vector2(-radio, 0.0f);
                if (angProm[0] == 0)
                    angProm[0] = 0;
                else
                    angProm[1] = 0;
            }

            transform.localPosition = newOffset;
            direction = newDir;

            sharedDirR = direction;
            angle = (angProm[0] + angProm[1]) / 2;//compartir ángulo

            if ((CtrlOrder[ax] == "S" && CtrlOrder[ax - 1] == "A") | (CtrlOrder[ax] == "A" && CtrlOrder[ax - 1] == "S"))//magnitud incorrecta
            {
                angle = -135;
            }

            if (CtrlOrder[ax] == "W" && CtrlOrder[ax - 1] == "S")//eliminar teclas opuestas
            {
                transform.localPosition = new Vector2(m_StartPos.x, m_StartPos.y + radio);
                direction = new Vector2(0.0f, radio);
                angle = 90;
            }
            if (CtrlOrder[ax] == "S" && CtrlOrder[ax - 1] == "W")//eliminar teclas opuestas
            {
                transform.localPosition = new Vector2(m_StartPos.x, m_StartPos.y - radio);
                direction = new Vector2(0.0f, -radio);
                angle = -90;
            }
            if (CtrlOrder[ax] == "A" && CtrlOrder[ax - 1] == "D")//eliminar teclas opuestas
            {
                transform.localPosition = new Vector2(m_StartPos.x - radio, m_StartPos.y);
                direction = new Vector2(radio, 0.0f);
                angle = 180;
            }
            if (CtrlOrder[ax] == "D" && CtrlOrder[ax - 1] == "A")//eliminar teclas opuestas
            {
                transform.localPosition = new Vector2(m_StartPos.x + radio, m_StartPos.y);
                direction = new Vector2(-radio, 0.0f);
                angle = 0;
            }
            ang = angle;
        }



        if (Input.GetMouseButtonDown(0) && kei == false)
        {
            pointA = Input.mousePosition;
        }
        if (Input.GetMouseButton(0) && touch && kei == false)
        {
            pointB = Input.mousePosition;
            offset = pointB - pointA;
            direction = Vector2.ClampMagnitude(offset, radio);

            sharedDirR = direction;

            mag = direction.magnitude;
            angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
            ang = angle;
            velPerc = direction.magnitude / radio;//Nuevo, determina multiplicador de velocidad total
            velocityPer = velPerc;
        }

        //Bug seguir moviendose al hacer click fuera de la pantalla
        if(W == false & A == false & S == false & D == false)
        {
            kei = false;
            touch = false;
            ax = 0;
            curPos = 0;
        }

        if (pej.GetComponent<Player>().notMove == true)
        {
            touch = false;
            //BUG AVANCE EN DIAGONAL CON 1 TECLA
            curPos = 0;

            W = false;
            A = false;
            S = false;
            D = false;

            for (int i = 0; i < 4; i++)
            {
                CtrlOrder[i] = "";
            }
        }

    }

    public void OnDrag(PointerEventData eventData)
    {
        //transform.position = Input.mousePosition;
        touch = true;
        transform.localPosition = new Vector2(m_StartPos.x + direction.x, m_StartPos.y + direction.y);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        touch = false;
        transform.localPosition = m_StartPos;

        pointB = pointA;
        offset = new Vector2(0, 0);
        direction = new Vector2(0, 0);
        sharedDirR = direction;
        mag = direction.magnitude;
    }

}
