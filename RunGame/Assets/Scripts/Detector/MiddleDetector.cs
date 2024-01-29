using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MiddleDetector : CollisionObject
{
    public override void Activate(Runner runner)
    {
        runner.RevertPosition();
    }

}
