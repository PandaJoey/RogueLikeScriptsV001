using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {


    [SerializeField] GameObject weapon;
    [SerializeField] GameObject weaponSlot;
    [SerializeField] GameObject enemy;
    float damage = 100f;

    PlayerController playerController;
    SwordAttack swordAttack;
    

    GameObject weaponSlotParent;
    GameObject weaponToEquip;

    Animator playerAttackAnimator;

    const string WEAPONSLOT_PARENT_NAME = "Weapon Slot";
    // Start is called before the first frame update
    void Start() {
        playerController = GetComponent<PlayerController>();
        swordAttack = GetComponent<SwordAttack>();
        playerAttackAnimator = GetComponent<Animator>();
        AddWeaponToSlot();
        EquipWeapon();


    }

    // Update is called once per frame
    void Update() {
        Attack();
    }


    public void EquipWeapon() {
        weaponToEquip = Instantiate(weapon, weaponSlot.transform.position, Quaternion.identity, weaponSlot.transform);
        weaponToEquip.transform.parent = weaponSlotParent.transform;
    }

    private void AddWeaponToSlot() {
        weaponSlotParent = GameObject.Find(WEAPONSLOT_PARENT_NAME);
        if (!weaponSlotParent) {
            weaponSlotParent = new GameObject(WEAPONSLOT_PARENT_NAME);
        }
    }

    public void Attack() {
        if(Input.GetButtonDown("Attack")) {
            playerAttackAnimator.SetBool("isAttacking", true);
            weapon.GetComponent<SwordAttack>().AttackAnimation();
            weapon.GetComponent<SwordAttack>().DealDamage(damage);
        }else {
            playerAttackAnimator.SetBool("isAttacking", false);
        }

    }

   /*

    public void StrikeCurrentTarget(float damage) {
        if (enemy && weapon.GetComponent<CapsuleCollider2D>().IsTouching(enemy.GetComponent<BoxCollider2D>())) {
            enemy.GetComponent<EnemyHealth>().EnemieTakeDamage(damage);
        }
    }
    */

}
