﻿// 火屬性敵人
public class FireEnemy  : Enemy {
    
    public override EnemyType EType {
        get {
            return EnemyType.FireEnemy;
        }
    }

#region Visitor
    
    public override void Visit (IEnemyVisitor visitor) {
        visitor.Visit (this);
    }
    
#endregion
    
#region Template 例子
    
    // 能夠受到傷害的條件判斷由子類完成
    protected override bool TakeDamageCondition (AttackData data) {
        return data.Type != AttackType.Fire;
    }
    
    // 計算受到的傷害的具體值
    protected override int CalculateDamage (AttackData data) {
        if (data.Type == AttackType.Water) {
            return data.Damage * 2;
        } else if (data.Type == AttackType.Frozen) {
            return data.Damage / 2;
        }

        return data.Damage;
    }
    
#endregion

}
