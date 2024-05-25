using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject applePrefab; //об'Їкт €блука, €кий буде падать з €блун≥
    public float speed = 1f; //Ўвидк≥сть перем≥щенн€
    public float leftAndRightEdge = 10f; //Ћ≥ва та права межа перем≥щенн€
    public float chanceToChangeDirections = 0.1f; //≤мов≥рн≥сть зм≥ни напр€мку
    public float secondsBetweenAppleDrops = 1f; //„астота скиданн€ €блук

    //Use this to change the hierarchy of the GameObject siblings
    int m_IndexNumber;
    // Start is called before the first frame update
    void Start()
    {
        //2 секунду
        m_IndexNumber = 1;
        transform.SetSiblingIndex(m_IndexNumber);

        Invoke(nameof(DropApple), 2f);
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        //€блуко ставити на позиц≥ю €блун≥
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
