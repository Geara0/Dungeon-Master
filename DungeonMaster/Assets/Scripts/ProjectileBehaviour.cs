using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public float Speed = 16f;

    private void Update()
    {
        /*var mousePosMain = Input.mousePosition;
        mousePosMain.z = Camera.main.transform.position.z; 
        var lookPos = Camera.main.ScreenToWorldPoint(mousePosMain);
        lookPos = lookPos - transform.position;
        var angle  = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
        zRotate.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.eulerAngles = angle;*/
        /*var mousePosMain = Input.mousePosition;
        mousePosMain.z = Camera.main.transform.position.z; 
        var lookPos = Camera.main.ScreenToWorldPoint(mousePosMain);
        if (lookPos.x > transform.position.x)
            transform.position += transform.right * Time.deltaTime * Speed;
        else
            transform.position += -transform.right * Time.deltaTime * Speed;*/
        var _move = Input.GetAxis("Horizontal");
        transform.position = transform.position + new Vector3(_move * Speed * Time.deltaTime, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.collider.GetComponent<EnemyBehaviour>();
        if (enemy)
            enemy.UpdateHit(1);
            
        Destroy(gameObject);
    }
}