using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace STORYGAME
{
    public class Enums
    {
        public enum StoryType
        {
            MAIN,
            SUB,
            SERIAL
        }

        public enum EventType
        {
            NONE,
            GoToBattle = 100,
            CheckSTR = 1000,
            CheckDEX,
            CheckCON,
            CheckINT,
            CheckWIS,
            CheckCHA
        }

        public enum ResultType
        {
            ChangeHp,
            ChangeSp,
            AddExperience = 100,
            GoToShop = 1000,
            GoToNextStory = 2000,
            GoToRandomStory = 3000,
            GoToEnding = 10000
        }
    }

    [System.Serializable]
    public class Stats
    {
        //체력과 정신력
        public int hpPoint;
        public int spPoint;

        public int currentHpPoint;
        public int currentSpPoint;
        public int currentXpPoint;

        //기본 스택 설정 (Ex D&D)
        public int strength;
        public int dexterity;
        public int consitiution;
        public int Intelligence;
        public int wisdom;
        public int charisma;
    }
}
