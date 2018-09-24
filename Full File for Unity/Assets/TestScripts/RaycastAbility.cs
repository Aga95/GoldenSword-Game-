using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Abilities/RaycastAbility")]
public class RaycastAbility : Ability {

    public int spellDamage = 1;
    public float spellRange = 50f;
    public float hitForce = 100f;
    public Color spellColor = Color.white;

    private RaycastShootTriggerable rcShoot;

    public override void Initialize(GameObject obj)
    {
        rcShoot = obj.GetComponent<RaycastShootTriggerable>();
        rcShoot.Initialize();

        rcShoot.gunDamage = spellDamage;
        rcShoot.weaponRange = spellRange;
        rcShoot.hitForce = hitForce;
        rcShoot.laserLine.material = new Material(Shader.Find("Unlit/Color"));
        rcShoot.laserLine.material.color = spellColor;
    }

    public override void TriggerAbility()
    {
        rcShoot.Fire();
    }

}
