using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Text;
using UnityEngine.UI;
using TMPro;
namespace STORYGAME
{
#if UNITY_EDITOR
    [CustomEditor(typeof(GameSystem))]
    public class GameSystemEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GameSystem gameSystem = (GameSystem)target;

            if (GUILayout.Button("Reset Story Models"))
            {
                gameSystem.ResetStoryModels();
            }
        }
    }
#endif

    public class GameSystem : MonoBehaviour
    {
        public static GameSystem Instance;      //Secne ���ο����� ����


        private void Awake()
        {
            Instance = this;
        }

        public enum GAMESTATE
        {
            STORYSHOW,
            STORYEND,
            ENDMODE
        }

        public GAMESTATE currentState;
        public Stats stats;
        public StoryModel[] storyModels;
        public int currentStoryIndex = 0;

        public void ChangeState(GAMESTATE temp)
        {
            currentState = temp;

            if(currentState == GAMESTATE.STORYSHOW)
            {
               StoryShow(currentStoryIndex);
            }
        }
        public void StoryShow(int number)
        {
            StoryModel tempStoryModels = FindStoryModel(number);

            //StorySystem.Instance.currentStoryModel = tempStoryModels;
            //StorySystem.instace.CoShowText();
        }

        public void ApplyChoice(StoryModel.Result result)
        {
            switch(result.resultType)
            {
                case StoryModel.Result.ResultType.ChangeHp:

                    //GameUI.Instance.UpdateHpUI()      //���߿� �߰�
                    ChangeStats(result);
                    break;

                case StoryModel.Result.ResultType.GoToNextStory:
                    currentStoryIndex = result.value;       //���� �̵� ���丮 ��ȣ�� �޾ƿͼ� ����
                    ChangeState(GAMESTATE.STORYSHOW);
                    ChangeStats(result);
                    break;

                case StoryModel.Result.ResultType.GoToRandomStory:
                    RandomStory();
                    ChangeState(GAMESTATE.STORYSHOW);
                    ChangeStats(result);
                    break;

                default:
                    Debug.LogError("Unknown effect Type");
                    break;
            }
        }
        public void ChangeStats(StoryModel.Result result)  // ���� ���� �Լ�
        {
            // �⺻ ����
            if (result.stats.hpPoint > 0) stats.hpPoint += result.stats.hpPoint;
            if (result.stats.spPoint > 0) stats.spPoint += result.stats.spPoint;
            //���� ����
            if (result.stats.currentHpPoint > 0) stats.currentHpPoint += result.stats.currentHpPoint;
            if (result.stats.currentSpPoint > 0) stats.currentSpPoint += result.stats.currentSpPoint;
            if (result.stats.currentXpPoint > 0) stats.currentXpPoint += result.stats.currentXpPoint;
            // �ɷ�ġ ����
            if (result.stats.strength > 0) stats.strength += result.stats.strength;
            if (result.stats.dexterity > 0) stats.dexterity += result.stats.dexterity;
            if (result.stats.consitiution > 0) stats.consitiution += result.stats.consitiution;
            if (result.stats.wisdom > 0) stats.wisdom += result.stats.wisdom;
            if (result.stats.Intelligence > 0) stats.Intelligence += result.stats.Intelligence;
            if (result.stats.charisma > 0) stats.charisma += result.stats.charisma;

        }
        StoryModel RandomStory()
        {
            StoryModel tempStoryModels = null;

            List<StoryModel> StoryModelList = new List<StoryModel>();

            for(int i = 0; i < storyModels.Length; i++)
            {
                if(storyModels[i].storyType == StoryModel.STORYTYPE.MAIN)
                {
                    StoryModelList.Add(storyModels[i]);
                }
            }
            tempStoryModels = StoryModelList[Random.Range(0, StoryModelList.Count)];
            currentStoryIndex = tempStoryModels.storyNumber;
            Debug.Log("currentStoryIndex" + currentStoryIndex);

            return tempStoryModels;
        }


        StoryModel FindStoryModel(int number)
        {
            StoryModel tempStoryModels = null;

            for (int i = 0; i < storyModels.Length; i++)
            {
                if(storyModels[i].storyNumber == number)
                {
                   tempStoryModels = storyModels[i];
                   break;
                }
            }
            return tempStoryModels;
        }

#if     UNITY_EDITOR
        [ContextMenu("Reset Story Models")]
        public void ResetStoryModels()
        {
            storyModels = Resources.LoadAll<StoryModel>("");
            //Resource ���� �Ʒ� ��� StoryModel �ҷ�����
        }
 #endif
    }
}