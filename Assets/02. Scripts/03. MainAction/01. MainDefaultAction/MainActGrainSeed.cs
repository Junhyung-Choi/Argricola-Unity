using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 갈대밭
public class MainActGrainSeed : ButtonParents
{
    public int playerIndex;

    public override void OnClick()
    {
        playerIndex = GameManager.instance.getCurrentPlayerId();
        int userPlayerId = GameManager.instance.localPlayerIndex;
        if(playerIndex == userPlayerId && GameManager.instance.IsDoingAct[8]==false)
        {   
            MainboardUIController.instance.ActivatePlayerOnButton(this, playerIndex);
            GameManager.instance.queueActionType = ActionType.SEED;
            //행동을 했음 표시
            GameManager.instance.IsDoingAct[8] = true;
            GameManager.instance.actionQueue.Enqueue("grainSeed");
            GameManager.instance.PopQueue();
        }
    }
    public void GrainSeedStart()
    {
        ResourceManager.instance.addResource(GameManager.instance.getCurrentPlayerId(), "wheat", 1);

        //채소 장수 카드를 보유중이라면 나무 1개 추가
        if (GameManager.instance.players[GameManager.instance.getCurrentPlayerId()].HasJobCard("vegetableSeller"))
        {
            GameManager.instance.players[GameManager.instance.getCurrentPlayerId()].ActCard("vegetableSeller");
        }

        //장작 채집자 카드
        if (GameManager.instance.players[GameManager.instance.getCurrentPlayerId()].HasJobCard("woodPicker"))
        {
            GameManager.instance.players[GameManager.instance.getCurrentPlayerId()].ActCard("woodPicker");
        }

        //쇠스랑
        if (GameManager.instance.players[GameManager.instance.getCurrentPlayerId()].HasJobCard("rake"))
        {
            //농지에 어떤 플레이어가 행동 중이라면
            if ( GameManager.instance.IsDoingAct[9] == true )
            //쇠스랑 효과 발동 가능
            GameManager.instance.players[GameManager.instance.getCurrentPlayerId()].ActCard("rake");
        }

        Debug.Log("Player " + GameManager.instance.getCurrentPlayerId() + " get " + 1 + " wheat!");

        ResourceManager.instance.minusResource(GameManager.instance.getCurrentPlayerId(), "family", 1);

        GameManager.instance.PopQueue();
    }    
}
