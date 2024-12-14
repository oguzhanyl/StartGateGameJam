using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTester : MonoBehaviour
{
    public status CharacterAtm;
    public status enemyAtm;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F11))
        {
            CharacterAtm.DealDamage(enemyAtm.gameObject);
        }
        if (Input.GetKeyDown(KeyCode.F12))
        {
            enemyAtm.DealDamage(CharacterAtm.gameObject);
        }
    }
}
