using UnityEngine;
using System.Collections.Generic;

public class Test : MonoBehaviour
{
    private List<char> moveHistory = new List<char>();
    private const int MaxHistorySize = 20;
    private Animator anim;

    // Movement characters
    private char[] moves = { 'U', 'D', 'L', 'R' }; // Up, Down, Left, Right
    private string[] attackAnimations = { "AttackAnimation1", "AttackAnimation2", "AttackAnimation3", "AttackAnimation4" };

    // Event to notify other scripts about the attack
    public delegate void AttackNotification(string attackName);
    public static event AttackNotification OnAttack;

    void Awake()
    {
        anim = GetComponent<Animator>();

        if (anim == null)
        {
            Debug.LogError("Animator component not found on this GameObject! Please ensure you have an Animator component.");
        }
    }

    void Update()
    {
        CheckInput();
        if (Input.GetMouseButtonDown(0))
        {
            CheckMoveSequence();
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log("Current move history: " + string.Join(", ", moveHistory));
        }
    }

    private void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.W)) AddMoveToHistory('U');
        if (Input.GetKeyDown(KeyCode.S)) AddMoveToHistory('D');
        if (Input.GetKeyDown(KeyCode.A)) AddMoveToHistory('L');
        if (Input.GetKeyDown(KeyCode.D)) AddMoveToHistory('R');
    }

    private void AddMoveToHistory(char move)
    {
        if (moveHistory.Count >= MaxHistorySize) moveHistory.RemoveAt(0);
        moveHistory.Add(move);
    }

    private void CheckMoveSequence()
    {
        if (moveHistory.Count < 4)
        {
            HandleNotEnoughMoves();
            return;
        }

        string[] sequences = { "ULDR", "URDL", "LLDR", "RDUL" }; // Sequences for attack1, attack2, etc.
        for (int i = 0; i < sequences.Length; i++)
        {
            if (IsSequenceMatch(sequences[i]))
            {
                TriggerAttackAnimation(i);
                moveHistory.Clear();
                return;
            }
        }
    }

    private bool IsSequenceMatch(string sequence)
    {
        // Check the sequence from the start of the moveHistory
        for (int i = 0; i < sequence.Length; i++)
        {
            if (moveHistory[i] != sequence[i]) return false;
        }
        return true;
    }

    private void TriggerAttackAnimation(int index)
    {
        if (anim != null) // Check if animator is initialized
        {
            Debug.Log($"Triggering {attackAnimations[index]}");
            anim.SetTrigger(attackAnimations[index]);
            NotifyAttack(attackAnimations[index]); // Notify the attack
        }
        else
        {
            Debug.LogError("Animator is not initialized, cannot trigger animation.");
        }
    }

    private void HandleNotEnoughMoves()
    {
        Debug.Log("Not enough moves to perform an action.");

        // Check if the last move was 'U'
        if (moveHistory.Count > 0)
        {
            char lastMove = moveHistory[moveHistory.Count - 1];
            switch (lastMove)
            {
                case 'U':
                    Debug.Log("Last move was 'U', triggering attackU animation.");
                    anim.SetTrigger("attackU");
                    NotifyAttack("attackU");
                    break;
                case 'D':
                    Debug.Log("Last move was 'D', triggering attackD animation.");
                    anim.SetTrigger("attackD");
                    NotifyAttack("attackD");
                    break;
                case 'L':
                    Debug.Log("Last move was 'L', triggering attackL animation.");
                    anim.SetTrigger("attackL");
                    NotifyAttack("attackL");
                    break;
                case 'R':
                    Debug.Log("Last move was 'R', triggering attackR animation.");
                    anim.SetTrigger("attackR");
                    NotifyAttack("attackR");
                    break;
            }
        }
    }

    private void NotifyAttack(string attackName)
    {
        OnAttack?.Invoke(attackName); // Call the event if there are subscribers
    }
}
