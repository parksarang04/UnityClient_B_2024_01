using STORYGAME;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewStory", menuName = "ScriptableObject/StoryTableObject")]

public class StoryModel : ScriptableObject
{
    public int storyNumber;
    public Texture2D MainImage;
    public bool storyDone;

    public enum STORYTYPE
    {
        MAIN,
        SUB,
        SERIAL
    }

    public STORYTYPE storyType;

    [TextArea(10, 10)]      //�ν����� text ���� ����
    public string storyText;
    public Option[] options; // ������ �迭

    [System.Serializable]
    public class Option
    {
        public string optionText;
        public string buttonText;

        public EventCheck eventCheck;
    }

    public class EventCheck
    {
        public int checkValue;
        public enum EventType : int
        {
            None,
            GoToBattle,
            CheckSTR,
            CheckDEX,
            CheckCON,
            CheckINT,
            CheckWIS,
            CheckCHA
        }

        public EventType type;

        public Result[] successResult;      //�������� ���� ���� �� �ݿ�
        public Result[] failedResult;       //�������� ���� ���� �� �ݿ�
    }

    [System.Serializable]
    public class Result
    {
        public enum ResultType : int
        {
            ChangeHp,
            ChangeSp,
            AddExperience,
            GoToShop,
            GoToNextStory,
            GoToRandomStory,
            GoToEnding
        }

        public ResultType resultType;
        public int value;
        public Stats stats;
    }
}
