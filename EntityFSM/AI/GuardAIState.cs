using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GuardAIState : IAIState
{

    private bool m_bOnMove = false;
    private Vector3 m_position = Vector3.zero;
    private const int GUARD_DIST = 10;

    

    public GuardAIState()
    {

    }

    public override void RemoveTarget(IEntity target)
    {
        base.RemoveTarget(target);
    }

    public override void SetAttackPosition(Vector3 position)
    {
        base.SetAttackPosition(position);
    }

    public override void Update(List<IEntity> targets)
    {
        if(targets == null || targets.Count == 0)
        {
            m_controller.SwitchEntityAIState(new IdleAIState());
            return;
        }
        //还未获取位置
        if(m_position == Vector3.zero)
        {
            GetMovePosition();
        }

        if(m_bOnMove)
        {
            float dist = Vector3.Distance(m_position, m_controller.GetPosition());

            if( dist > 0.5f)
            {
                return;
            }
            //换下一个位置
            GetMovePosition();
        }

        m_bOnMove = true;
        m_controller.MoveTo(m_position);
    }


    private void GetMovePosition()
    {
        m_bOnMove = false;

        Vector3 pos = new Vector3(Random.Range(-GUARD_DIST, GUARD_DIST), 0, Random.Range(-GUARD_DIST,GUARD_DIST));

        m_position = m_controller.GetPosition() + pos;

    }
}
