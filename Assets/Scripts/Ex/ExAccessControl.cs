using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExAccessControl : MonoBehaviour
{
    //public���� ����� ������ �ٸ� ��ũ��Ʈ���� ���� ���� ����
    public int publicValue;

    //private���� ����� ������ ���� Ŭ���� �������� ���� ����
    private int privateValue;

    //protected�� ����� ������ ���� Ŭ���� �� �Ļ� Ŭ�������� ���� ����
    protected int protectValue;

    //internal�� ����� ������ ���� �������(������Ʈ �� �ٸ� ��ũ��Ʈ) ������ ���� ����
    internal  int internaValue;
}

public class ParentClass
{
    protected int protectedValueParent;
}

public class ChildClass : ParentClass       //ParentClass ���
{
    void Start()
    {
        Debug.Log(protectedValueParent);
    }
}