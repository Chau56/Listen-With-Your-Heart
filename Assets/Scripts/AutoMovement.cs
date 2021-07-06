using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMovement : MonoBehaviour
{
    [SerializeField] public static float speed = 5f;      //�����ƶ��ٶ�

    // Update is called once per frame
    void Update()
    {
        //������������ȡ�����壨����A��B��
        foreach (Transform tran in transform)           //tran��Background���µ�����������
        {
            //��ȡ�������λ��
            Vector3 pos = tran.position;

            //�����ٶ����Ҳ��ƶ�
            pos.x += speed * Time.deltaTime;

            //λ�ø���������
            tran.position = pos;
        }
    }
}
