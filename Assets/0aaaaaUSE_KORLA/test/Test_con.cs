using UnityEngine;
//Test_con



public class Test_con : MonoBehaviour
{
    public enum AttackType
    {
        Attack1,
        Attack2,
        Attack3,
        Attack4,
        AttackU,
        AttackD,
        AttackL,
        AttackR
    }

    public AttackType selectedAttack; // Select attack type from Inspector

    private void OnEnable()
    {
        Test.OnAttack += HandleAttack; // Subscribe to the attack event
    }

    private void OnDisable()
    {
        Test.OnAttack -= HandleAttack; // Unsubscribe from the event
    }

    private void HandleAttack(string attackName)
    {
        Debug.Log($"Received attack notification: {attackName}");

        // Handle animation triggers based on selected attack type
        switch (selectedAttack)
        {
            case AttackType.Attack1:
                if (attackName == "attack1") PerformActionForAttack1();
                break;
            case AttackType.Attack2:
                if (attackName == "attack2") PerformActionForAttack2();
                break;
            case AttackType.Attack3:
                if (attackName == "attack3") PerformActionForAttack3();
                break;
            case AttackType.Attack4:
                if (attackName == "attack4") PerformActionForAttack4();
                break;
            case AttackType.AttackU:
                if (attackName == "attackU") PerformActionForAttackU();
                break;
            case AttackType.AttackD:
                if (attackName == "attackD") PerformActionForAttackD();
                break;
            case AttackType.AttackL:
                if (attackName == "attackL") PerformActionForAttackL();
                break;
            case AttackType.AttackR:
                if (attackName == "attackR") PerformActionForAttackR();
                break;
            default:
                Debug.Log("Unknown attack type!");
                break;
        }
    }

    private void PerformActionForAttack1()
    {
        Debug.Log("Performing action for Attack 1!");
    }

    private void PerformActionForAttack2()
    {
        Debug.Log("Performing action for Attack 2!");
    }

    private void PerformActionForAttack3()
    {
        Debug.Log("Performing action for Attack 3!");
    }

    private void PerformActionForAttack4()
    {
        Debug.Log("Performing action for Attack 4!");
    }

    private void PerformActionForAttackU()
    {
        Debug.Log("Performing action for Attack U!");
    }

    private void PerformActionForAttackD()
    {
        Debug.Log("Performing action for Attack D!");
    }

    private void PerformActionForAttackL()
    {
        Debug.Log("Performing action for Attack L!");
    }

    private void PerformActionForAttackR()
    {
        Debug.Log("Performing action for Attack R!");
    }
}