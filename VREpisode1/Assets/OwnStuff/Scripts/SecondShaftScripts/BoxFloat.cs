﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.GrabAttachMechanics;

public class BoxFloat : MonoBehaviour
{
    //goal, make the box float with physics and get up to the water level if pushed down by objects
    private bool startMoving;
    private bool notTouched;
    public int whatSideofTheBoxDown;

    float rotationSpeed;

    float totalRotationsX;
    float totalRotationsY;
    float totalRotationsZ;
    //Animator FloatAnim;
    //private Collider BoxFloatUpsideMarker1;
    //private Collider BoxFloatUpsideMarker2;
    //private Collider BoxFloatUpsideMarker3;
    //private Collider BoxFloatUpsideMarker4;
    //private Collider BoxFloatUpsideMarker5;
    //private Collider BoxFloatUpsideMarker6;

    Transform x0y0z0;

    Transform x90;
    Transform y90;
    Transform z90;
    Transform x90Neg;
    Transform y90Neg;
    Transform z90Neg;

    Transform x90y90;
    Transform x90z90;
    Transform x90y90Neg;
    Transform x90z90Neg;

    Transform y90x90;
    Transform y90z90;
    Transform y90x90Neg;
    Transform y90z90Neg;

    Transform z90x90;
    Transform z90y90;
    Transform z90x90Neg;
    Transform z90y90Neg;

    Transform x90y90z90;
    Transform x90z90y90;
    Transform x90y90z90Neg;
    Transform x90z90y90Neg;

    Transform y90x90z90;
    Transform y90z90x90;
    Transform y90x90z90Neg;
    Transform y90z90x90Neg;

    Transform z90x90y90;
    Transform z90y90x90;
    Transform z90x90y90Neg;
    Transform z90y90x90Neg;

    int futureXRotation;
    int futureYRotation;
    int futureZRotation;

    private void Start()
    {
        whatSideofTheBoxDown = 0;
        startMoving = false;
        notTouched = true;
        rotationSpeed = 20f;
        totalRotationsX = 0;
        totalRotationsY = 0;
        totalRotationsZ = 0;
        //FloatAnim = transform.parent.GetComponent<Animator>();
        //BoxFloatUpsideMarker1 = transform.Find("FloatingBox/BoxFloatUpsideMarker1").GetComponent<Collider>();
        //BoxFloatUpsideMarker1 = transform.Find("FloatingBox/BoxFloatUpsideMarker2").GetComponent<Collider>();
        //BoxFloatUpsideMarker1 = transform.Find("FloatingBox/BoxFloatUpsideMarker3").GetComponent<Collider>();
        //BoxFloatUpsideMarker1 = transform.Find("FloatingBox/BoxFloatUpsideMarker4").GetComponent<Collider>();
        //BoxFloatUpsideMarker1 = transform.Find("FloatingBox/BoxFloatUpsideMarker5").GetComponent<Collider>();
        //BoxFloatUpsideMarker1 = transform.Find("FloatingBox/BoxFloatUpsideMarker6").GetComponent<Collider>();

        //Marker1Rotation = BoxFloatUpsideMarker1.transform.rotation.eulerAngles;
        //Marker2Rotation = BoxFloatUpsideMarker2.transform.rotation.eulerAngles;
        //Marker3Rotation = BoxFloatUpsideMarker3.transform.rotation.eulerAngles;
        //Marker4Rotation = BoxFloatUpsideMarker4.transform.rotation.eulerAngles;
        //Marker5Rotation = BoxFloatUpsideMarker5.transform.rotation.eulerAngles;
        //Marker6Rotation = BoxFloatUpsideMarker6.transform.rotation.eulerAngles;
        x0y0z0 = transform.Find("x0y0z0");

        x90 = transform.Find("x90");
        y90 = transform.Find("y90");
        z90 = transform.Find("z90");
        x90Neg = transform.Find("x90Neg");
        y90Neg = transform.Find("y90Neg");
        z90Neg = transform.Find("z90Neg");

        x90y90 = transform.Find("x90y90");
        x90z90 = transform.Find("x90z90");
        x90y90Neg = transform.Find("x90y90Neg");
        x90z90Neg = transform.Find("x90z90Neg");

        y90x90 = transform.Find("y90x90");
        y90z90 = transform.Find("y90z90");
        y90x90Neg = transform.Find("y90x90Neg");
        y90z90Neg = transform.Find("y90z90Neg");

        z90x90 = transform.Find("z90x90");
        z90y90 = transform.Find("z90y90");
        z90x90Neg = transform.Find("z90x90Neg");
        z90y90Neg = transform.Find("z90y90Neg");

        x90y90z90 = transform.Find("x90y90z90");
        x90z90y90 = transform.Find("x90z90y90");
        x90y90z90Neg = transform.Find("x90y90z90Neg");
        x90z90y90Neg = transform.Find("x90z90y90Neg");

        y90x90z90 = transform.Find("y90x90z90");
        y90z90x90 = transform.Find("y90z90x90");
        y90x90z90Neg = transform.Find("y90x90z90Neg");
        y90z90x90Neg = transform.Find("y90z90x90Neg");

        z90x90y90 = transform.Find("z90x90y90");
        z90y90x90 = transform.Find("z90y90x90");
        z90x90y90Neg = transform.Find("z90x90y90Neg");
        z90y90x90Neg = transform.Find("z90y90x90Neg");

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "GrabbableWater" && notTouched)
        {
            notTouched = false;
            StartCoroutine("WaitForRealism");
        }
        if (other.name == "WaterSlower")
        {
            startMoving = false;
        }
    }

    IEnumerator WaitForRealism()
    {
        yield return new WaitForSeconds(1.5f);
        startMoving = true;
    }

    void FixedUpdate()
    {
        RotationFixer();

        if (startMoving)
        {
            MovementStart();

        }
    }
    public void MovementStart()
    {
        if (startMoving)
        {
            GetComponent<Rigidbody>().useGravity = false;
            //FloatAnim.SetBool("Float", true);
            GetComponent<VRTK_InteractableObject>().grabAttachMechanicScript = GetComponent<VRTK_ClimbableGrabAttach>();
            //GetComponent<VRTK_InteractableObject>().isGrabbable = false;
            GetComponent<Rigidbody>().freezeRotation = true;
            GetComponent<Rigidbody>().isKinematic = true;
            //if (whatSideofTheBoxDown == 0)
            //{
            transform.Translate(Vector3.up * 0.2f * Time.deltaTime, Space.World);
        }
    }
    //check whether any axis rotation is not "straight" and fixes it
    public void RotationFixer()
    {
        var step = rotationSpeed * Time.deltaTime;
        //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        if (transform.rotation.eulerAngles.x % 90 != 0 && transform.rotation.eulerAngles.x != 0)
        {
            totalRotationsX = Mathf.FloorToInt(transform.rotation.eulerAngles.x / 90);
            float realRotationX = transform.rotation.eulerAngles.x - totalRotationsX;

            if (realRotationX >= 0)
            {
                if (realRotationX >= 45f)
                {
                    futureXRotation = 90;
                    //transform.Rotate(90 - realRotation, 0, 0, Space.World);
                }
                else
                {
                    futureXRotation = 0;
                    //transform.Rotate(0 + realRotation, 0, 0, Space.World);
                }
            }
            else
            {
                if (realRotationX <= -45f)
                {
                    futureXRotation = -90;
                    //transform.Rotate(90 - realRotation, 0, 0, Space.World);
                }
                else
                {
                    futureXRotation = 0;
                    //transform.Rotate(0 + realRotation, 0, 0, Space.World);
                }
            }
        }
        else
        {
            futureXRotation = Mathf.FloorToInt(transform.rotation.eulerAngles.x);
        }
        //YYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYY
        if (transform.rotation.eulerAngles.y % 90 != 0 && transform.rotation.eulerAngles.y != 0)
        {
            totalRotationsY = Mathf.FloorToInt(transform.rotation.eulerAngles.y / 90);
            float realRotationY = transform.rotation.eulerAngles.y - totalRotationsY;

            if (realRotationY >= 0)
            {
                if (realRotationY >= 45f)
                {
                    futureYRotation = 90;
                    //transform.Rotate(90 - realRotation, 0, 0, Space.World);
                }
                else
                {
                    futureYRotation = 0;
                    //transform.Rotate(0 + realRotation, 0, 0, Space.World);
                }
            }
            else
            {
                if (realRotationY <= -45f)
                {
                    futureYRotation = -90;
                    //transform.Rotate(90 - realRotation, 0, 0, Space.World);
                }
                else
                {
                    futureYRotation = 0;
                    //transform.Rotate(0 + realRotation, 0, 0, Space.World);
                }
            }
        }
        //ZZZZZZZZZZZZZZZZZZZZZZZZZZZZ
        if (transform.rotation.eulerAngles.z % 90 != 0 && transform.rotation.eulerAngles.z != 0)
        {
            totalRotationsZ = Mathf.FloorToInt(transform.rotation.eulerAngles.z / 90);
            float realRotationZ = transform.rotation.eulerAngles.z - totalRotationsZ;

            if (realRotationZ >= 0)
            {
                if (realRotationZ >= 45f)
                {
                    futureZRotation = 90;
                    //transform.Rotate(90 - realRotation, 0, 0, Space.World);
                }
                else
                {
                    futureZRotation = 0;
                    //transform.Rotate(0 + realRotation, 0, 0, Space.World);
                }
            }
            else
            {
                if (realRotationZ <= -45f)
                {
                    futureZRotation = -90;
                    //transform.Rotate(90 - realRotation, 0, 0, Space.World);
                }
                else
                {
                    futureZRotation = 0;
                    //transform.Rotate(0 + realRotation, 0, 0, Space.World);
                }
            }
        }
        //FUTURE

        //Xstart
        if (futureXRotation == 90)
        {
            if (futureYRotation == 0)
            {
                if (futureZRotation == 0)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, x90.localRotation, step);
                }
                else if (futureZRotation == 90)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, x90z90.localRotation, step);
                }
                else
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, x90z90Neg.localRotation, step);
                }
            }
            else if (futureYRotation == 90)
            {
                if (futureZRotation == 0)
                {

                }
                else if (futureZRotation == 90)
                {

                }
                else
                {

                }
            }
            else
            {
                if (futureZRotation == 0)
                {

                }
                else if (futureZRotation == 90)
                {

                }
                else
                {

                }
            }
        }
        if (futureXRotation == -90)
        {
            if (futureYRotation == 0)
            {
                if (futureZRotation == 0)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, x90Neg.localRotation, step);
                }
                else if (futureZRotation == 90)
                {

                }
                else
                {

                }
            }
            else if (futureYRotation == 90)
            {
                if (futureZRotation == 0)
                {

                }
                else if (futureZRotation == 90)
                {

                }
                else
                {

                }
            }
            else
            {
                if (futureZRotation == 0)
                {

                }
                else if (futureZRotation == 90)
                {

                }
                else
                {

                }
            }
        }
        if (futureXRotation == 0)
        {
            if (futureYRotation == 0)
            {
                if (futureZRotation == 0)
                {
                    //no need to move
                    Debug.Log("futureRotation zero");
                }
                else if (futureZRotation == 90)
                {

                }
                else
                {

                }
            }
            else if (futureYRotation == 90)
            {
                if (futureZRotation == 0)
                {

                }
                else if (futureZRotation == 90)
                {

                }
                else
                {

                }
            }
            else
            {
                if (futureZRotation == 0)
                {

                }
                else if (futureZRotation == 90)
                {

                }
                else
                {

                }
            }
        }
        //YStart
        if (futureYRotation == 90)
        {
            if (futureXRotation == 0)
            {
                if (futureZRotation == 0)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, y90.localRotation, step);
                }
                else if (futureZRotation == 90)
                {

                }
                else
                {

                }
            }
            else if (futureXRotation == 90)
            {
                if (futureZRotation == 0)
                {

                }
                else if (futureZRotation == 90)
                {

                }
                else
                {

                }
            }
            //if futureXRotation is -90
            else
            {
                if (futureZRotation == 0)
                {

                }
                else if (futureZRotation == 90)
                {

                }
                else
                {

                }
            }
            if (futureYRotation == -90)
            {
                if (futureXRotation == 0)
                {
                    if (futureZRotation == 0)
                    {
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, y90Neg.localRotation, step);
                    }
                    else if (futureZRotation == 90)
                    {

                    }
                    else
                    {

                    }
                }
                else if (futureXRotation == 90)
                {
                    if (futureZRotation == 0)
                    {

                    }
                    else if (futureZRotation == 90)
                    {

                    }
                    else
                    {

                    }
                }
                //if futureXRotation is -90
                else
                {
                    if (futureZRotation == 0)
                    {

                    }
                    else if (futureZRotation == 90)
                    {

                    }
                    else
                    {

                    }
                }
                if (futureYRotation == 0)
                {
                    if (futureXRotation == 0)
                    {
                        if (futureZRotation == 0)
                        {
                            //no need to move
                            Debug.Log("futureRotation zero y");
                        }
                        else if (futureZRotation == 90)
                        {

                        }
                        else
                        {

                        }
                    }
                    else if (futureXRotation == 90)
                    {
                        if (futureZRotation == 0)
                        {

                        }
                        else if (futureZRotation == 90)
                        {

                        }
                        else
                        {

                        }
                    }
                    //if futureXRotation is -90
                    else
                    {
                        if (futureZRotation == 0)
                        {

                        }
                        else if (futureZRotation == 90)
                        {

                        }
                        else
                        {

                        }
                    }
                }

                //Zstart
                if (futureZRotation == 90)
                {
                    if (futureYRotation == 0)
                    {
                        if (futureXRotation == 0)
                        {
                            transform.rotation = Quaternion.RotateTowards(transform.rotation, z90.localRotation, step);
                        }
                        else if (futureXRotation == 90)
                        {

                        }
                        else
                        {

                        }
                    }
                    else if (futureYRotation == 90)
                    {
                        if (futureXRotation == 0)
                        {

                        }
                        else if (futureXRotation == 90)
                        {

                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        if (futureZRotation == 0)
                        {

                        }
                        else if (futureZRotation == 90)
                        {

                        }
                        else
                        {

                        }
                    }
                }
                if (futureZRotation == -90)
                {
                    if (futureYRotation == 0)
                    {
                        if (futureXRotation == 0)
                        {
                            transform.rotation = Quaternion.RotateTowards(transform.rotation, z90Neg.localRotation, step);
                        }
                        else if (futureXRotation == 90)
                        {

                        }
                        else
                        {

                        }
                    }
                    else if (futureYRotation == 90)
                    {
                        if (futureXRotation == 0)
                        {

                        }
                        else if (futureXRotation == 90)
                        {

                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        if (futureZRotation == 0)
                        {

                        }
                        else if (futureZRotation == 90)
                        {

                        }
                        else
                        {

                        }
                    }
                }
                if (futureZRotation == 0)
                {
                    if (futureYRotation == 0)
                    {
                        if (futureXRotation == 0)
                        {
                            //no need to move
                        }
                        else if (futureXRotation == 90)
                        {

                        }
                        else
                        {

                        }
                    }
                    else if (futureYRotation == 90)
                    {
                        if (futureXRotation == 0)
                        {

                        }
                        else if (futureXRotation == 90)
                        {

                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        if (futureZRotation == 0)
                        {

                        }
                        else if (futureZRotation == 90)
                        {

                        }
                        else
                        {

                        }
                    }
                }
            }
        }
    }
}

