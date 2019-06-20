using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command
{
    public virtual void Execute(Recerver receiver)
    {
        
    }
}

public class upCommond : Command
{
    public override void Execute(Recerver receiver)
    {
        //玩家角色向上移动
        receiver.MoveUp();
    }
}

public class downCommond : Command
{
    public override void Execute(Recerver receiver)
    {
        //玩家角色向下移动
        receiver.MoveDown();
    }
}

public class leftCommond : Command
{
    public override void Execute(Recerver receiver)
    {
        //玩家角色向左移动
        receiver.MoveLeft();
    }
}

public class rightCommond : Command
{
    public override void Execute(Recerver receiver)
    {
        //玩家角色向右移动
        receiver.MoveRight();
    }
}

public class redKeyCommond : Command
{
    public override void Execute(Recerver receiver)
    {
        //使用红钥匙
        receiver.UseRedKey();
    }
}

public class yellowKeyCommond : Command
{
    public override void Execute(Recerver receiver)
    {
        //使用黄钥匙
        receiver.UseYellowKey();
    }
}

public class AxeCommond : Command
{
    public override void Execute(Recerver receiver)
    {
        //使用斧子
        receiver.UseAxe();
    }
}

public class HammerCommond : Command
{
    public override void Execute(Recerver receiver)
    {
        //使用锤子
        receiver.UseHammer();
    }
}

public class BoardCommond : Command
{
    public override void Execute(Recerver receiver)
    {
        //使用木板
        receiver.UseBoard();
    }
}