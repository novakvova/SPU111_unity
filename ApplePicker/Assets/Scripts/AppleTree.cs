using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject applePrefab; //��'��� ������, ���� ���� ������ � ������
    public float speed = 1f; //�������� ����������
    public float leftAndRightEdge = 10f; //˳�� �� ����� ���� ����������
    public float chanceToChangeDirections = 0.1f; //���������� ���� ��������
    public float secondsBetweenAppleDrops = 1f; //������� �������� �����

    //Use this to change the hierarchy of the GameObject siblings
    int m_IndexNumber;
    // Start is called before the first frame update
    void Start()
    {
        //2 �������
        m_IndexNumber = 1;
        transform.SetSiblingIndex(m_IndexNumber);

        Invoke(nameof(DropApple), 2f);
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        //������ ������� �� ������� ������
        apple.transform.position = this.transform.position;
        Invoke(nameof(DropApple), secondsBetweenAppleDrops);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        if(pos.x<-leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        }
        else if(pos.x>leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }
    }

    private void FixedUpdate()
    {
        if(Random.value < chanceToChangeDirections)
        {
            speed *= -1;
        }
    }
}
