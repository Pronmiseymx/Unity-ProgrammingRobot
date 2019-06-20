using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recerver : MonoBehaviour {
    
    //CharacterController charactercontroller;
    Vector3 moveDir = Vector3.zero;
    Animator anim;

    public float speed = 3.0f;

	void Start () {
        //charactercontroller = GetComponent<CharacterController>();
        anim = this.gameObject.transform.GetComponent<Animator>();
    }
	
    public void MoveUp()
    {
        moveDir = Vector3.forward;
        anim.SetInteger("isRun", 1);
        transform.forward = moveDir;
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        //charactercontroller.gameObject.transform.forward = moveDir;
        //charactercontroller.Move(moveDir * Time.deltaTime * speed);
    }

    public void MoveDown()
    {
        moveDir = Vector3.back;
        anim.SetInteger("isRun", 1);
        transform.forward = moveDir;
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        //charactercontroller.gameObject.transform.forward = moveDir;
        //charactercontroller.Move(moveDir * Time.deltaTime * speed);
    }

    public void MoveLeft()
    {
        moveDir = Vector3.left;
        anim.SetInteger("isRun", 1);
        transform.forward = moveDir;
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        //charactercontroller.gameObject.transform.forward = moveDir;
        //charactercontroller.Move(moveDir * Time.deltaTime * speed);
    }

    public void MoveRight()
    {
        moveDir = Vector3.right;
        anim.SetInteger("isRun", 1);
        transform.forward = moveDir;
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        //charactercontroller.gameObject.transform.forward = moveDir;
        //charactercontroller.Move(moveDir * Time.deltaTime * speed);
    }

    public void UseRedKey()
    {
        anim.SetInteger("isTk", 1);
        tools.useTools(1);
    }

    public void UseYellowKey()
    {
        anim.SetInteger("isTk", 1);
        tools.useTools(2);
    }

    public void UseAxe()
    {
        anim.SetInteger("isTk", 1);
        tools.useTools(3);
    }

    public void UseHammer()
    {
        anim.SetInteger("isTk", 1);
        tools.useTools(4);
    }

    public void UseBoard()
    {
        anim.SetInteger("isTk", 1);
        tools.useTools(5);
    }
}
