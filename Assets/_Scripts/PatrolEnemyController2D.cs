using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemyController2D : GameActorController
{
    #region Inspector Properties

    [SerializeField] StompHelper stompCheck;

    #endregion

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();

        // testing code
        // TODO: Update with actual A.I. Behavior
        _vx = -1;

        if (stompCheck.IsStomped)
            gameObject.SetActive(false);

    }
}
