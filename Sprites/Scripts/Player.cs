using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int move_method;

    public float speed; //소수를 포함한 숫자를 저장
    public Vector2 speed_vec;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) //트리거가 활성화되었을 때 실행하는 함수
    {
        if(collision.CompareTag("Item"))  //태그가 Item이면 ture를 반환한다.
        {
        Debug.Log("아이템을 먹었다!");
        Destroy(collision.gameObject);
        }
        else if(collision.CompareTag("Enemy"))
        {
            Dead();
        }
    }

    public void Dead()
    {
        Destroy(gameObject); //오브젝트를 파괴한다.(플레이어가 사라진다.)
    }
    // Update is called once per frame
    void Update()
    {
        if(move_method == 0)
        {
          speed_vec = Vector2.zero;

          if(Input.GetKey(KeyCode.RightArrow))  //input.getkey는 특정 키가 눌렸는지아닌지 알려준다.
          {
              speed_vec.x += speed;  //오른쪽키가 눌리면 speed변수 x부분에 speed를 더한다.
          }
           if(Input.GetKey(KeyCode.LeftArrow))  
          {
              speed_vec.x -= speed;  
          }
           if(Input.GetKey(KeyCode.UpArrow))  
          {
              speed_vec.y += speed;  
          }
         if(Input.GetKey(KeyCode.DownArrow))  
          {
              speed_vec.y -= speed;  
          }

          transform.Translate(speed_vec); 
        }
        else if(move_method == 1)  //위쪽에서 movemethod가 0인지 확인하는데 아니면 이곳으로 내려와 1인지 확인
        { 
          speed_vec.x=Input.GetAxis("Horizontal") * speed; //좌우 눌림 인식
          speed_vec.y=Input.GetAxis("Vertical") * speed; //상하 눌림 인식

          transform.Translate(speed_vec);
        }
        else if(move_method==2)
        {
             speed_vec = Vector2.zero;

          if(Input.GetKey(KeyCode.RightArrow))  //input.getkey는 특정 키가 눌렸는지아닌지 알려준다.
          {
              speed_vec.x += speed;  //오른쪽키가 눌리면 speed변수 x부분에 speed를 더한다.
          }
           if(Input.GetKey(KeyCode.LeftArrow))  
          {
              speed_vec.x -= speed;  
          }
           if(Input.GetKey(KeyCode.UpArrow))  
          {
              speed_vec.y += speed;  
          }
         if(Input.GetKey(KeyCode.DownArrow))  
          {
              speed_vec.y -= speed;  
          }

          GetComponent<Rigidbody2D>().velocity=speed_vec; //velocity는 물리엔진에 들어있는 물체속도
        }
    }
}
