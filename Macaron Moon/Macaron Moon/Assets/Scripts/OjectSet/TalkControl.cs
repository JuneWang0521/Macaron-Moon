using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkControl : MonoBehaviour
{
    public GameObject[] controlGameObjects;
    public string[] stateNames;
    public bool[] talkStates;

    public void CheckTalkState(string talkNPC)
    {
        if (talkNPC == "NPC_Trigger")
        {
            for (int i = 0; i < stateNames.Length; i++)
            {
                if (stateNames[i] == "NPC")
                {
                    talkStates[i] = true;
                }
            }
        }
        else if (talkNPC == "LeftWall_Trigger")
        {
            for (int i = 0; i < stateNames.Length; i++)
            {
                if (stateNames[i] == "LeftWall")
                {
                    talkStates[i] = true;
                }
            }
        }
        else if (talkNPC == "RightWall_Trigger")
        {
            for (int i = 0; i < stateNames.Length; i++)
            {
                if (stateNames[i] == "RightWall")
                {
                    talkStates[i] = true;
                }
            }
        }

        for (int i = 0; i < controlGameObjects.Length; i++)
        {
            //在这里底下加入对对象的控制
            if (controlGameObjects[i].name == "Cat")
            {
                ControlOfNPC(i);
            }

            if(controlGameObjects[i].name == "图层 1")
            {
                ControlOfImage(i);
            }

            if (controlGameObjects[i].name == "LightControl")
            {
                ControlOfLightControl(i);
            }

            if(controlGameObjects[i].name == "Main Camera")
            {
                ControlOfMainCamera(i);
            }
        }
    }

    public void ControlOfNPC(int index)
    {
        int trueCount = 0;

        for (int i = 0; i < stateNames.Length; i++)
        {
            if (stateNames[i] == "RightWall")
            {
                if (talkStates[i])
                    trueCount++;
            }
            else if (stateNames[i] == "LeftWall")
            {
                if (talkStates[i])
                    trueCount++;
            }
        }

        if (trueCount == 2)
        {
            controlGameObjects[index].SetActive(true);
        }
    }

    public void ControlOfImage(int index)
    {
        for (int i = 0; i < stateNames.Length; i++)
        {
            if (stateNames[i] == "NPC")
            {
                if (talkStates[i])
                {
                    controlGameObjects[index].GetComponent<BackWallFade>().allowFade = true;
                }
            }
        }
    }

    public void ControlOfLightControl(int index)
    {
        for (int i = 0; i < stateNames.Length; i++)
        {
            if (stateNames[i] == "NPC")
            {
                if (talkStates[i])
                {
                    controlGameObjects[index].GetComponent<LightControl>().allowToShine = true;
                }
            }
        }
    }

    public void ControlOfMainCamera(int index)
    {
        for (int i = 0; i < stateNames.Length; i++)
        {
            if (stateNames[i] == "NPC")
            {
                if (talkStates[i])
                {
                    controlGameObjects[index].GetComponent<MusicControl>().allowPlay = true;
                    controlGameObjects[index].GetComponent<MusicControl>().checkAllow();
                }
            }
        }
    }
}
