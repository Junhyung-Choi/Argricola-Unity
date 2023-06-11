using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainActLessonFood2 : ButtonParents
{
    public int playerIndex;

    public override void OnClick()
    {
        //플레이어의 내려놓은 직업 카드가 0개 거나 1개일 때 -> 직업당 음식 1

        playerIndex = GameManager.instance.getCurrentPlayerId();

        //행동을 했음 표시
        GameManager.instance.IsDoingAct[4] = true;

        //플레이어의 현재 카드가 0개
        if (GameManager.instance.players[playerIndex].jobcard_owns.Count == 0)
        {
            //핸드에 있는 제일 처음 카드 Get
            GameManager.instance.players[playerIndex].jobcard_owns.Add( GameManager.instance.players[playerIndex].jobcard_hands[0] );
            Debug.Log("player " + playerIndex + " get job card!");
            
        }

        //플레이어의 현재 카드가 1개
        else
        {
            
                
               
            GameManager.instance.players[playerIndex].jobcard_owns.Add( GameManager.instance.players[playerIndex].jobcard_hands[1] );
            Debug.Log("player " + playerIndex + " get job card!");
                    
                
                
                    
            }
        

        //음식 감소 - 현재 최대 카드는 2개 이므로 여기서 공통으로 음식을 하나씩만 뺀다.
        ResourceManager.instance.minusResource(playerIndex, "food", 1);

        //행동을 한 후 가족 수 하나 줄이기
        ResourceManager.instance.minusResource(playerIndex, "family", 1);

        //turn이 끝났다는 flag 
        GameManager.instance.endTurnFlag = true;
    }
}