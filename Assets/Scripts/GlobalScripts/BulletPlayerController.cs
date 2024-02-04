using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    
    private GameController gameController;
    void Start()
    {
        gameController = GlobalObjects.Instance.gameController;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            gameController.ChangeShotType(0);
        }else if(Input.GetKeyDown(KeyCode.Alpha2)){
            gameController.ChangeShotType(1);
        }else if(Input.GetKeyDown(KeyCode.Alpha3)){
            gameController.ChangeShotType(2);
        }

        if(Input.GetKeyDown(KeyCode.Alpha7)){
            gameController.ChangeSpecialShotType(0);
        }else if(Input.GetKeyDown(KeyCode.Alpha8)){
            gameController.ChangeSpecialShotType(1);
        }else if(Input.GetKeyDown(KeyCode.Alpha9)){
            gameController.ChangeSpecialShotType(2);
        }
    }
}
