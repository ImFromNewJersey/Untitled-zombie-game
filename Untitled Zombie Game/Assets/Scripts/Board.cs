using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Board : MonoBehaviour
{

    Transform[] Boards;
    private int NextBoard = 0;
    private bool WaitedForBoard = true;

    public NavMeshObstacle BoardMaster;
    public Animator Animator;

    public AudioSource BreakBoard;
    public AudioSource RepairBoard;
    public AudioSource RepairBoardMons;

    private void Start()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == ("Zombie"))
        {
            if (WaitedForBoard)
            {
                StartCoroutine(Break());
            }
        }
        if (other.tag == "Player")
        {
            if (Input.GetKey("e"))
            {
                if (WaitedForBoard)
                {
                    StartCoroutine(Repair());
                }
            }
        }
    }

    IEnumerator Break()
    {
        WaitedForBoard = false;
        yield return new WaitForSeconds(1f);
        WaitedForBoard = true;
        switch (NextBoard)
        {
            case 0:
                Animator.SetBool("BreakBoard1", true);
                Animator.SetBool("RepairBoard1", false);
                Animator.SetBool("RepairBoard1", false);
                NextBoard--;
                BreakBoard.Play();
                //Debug.Log(NextBoard);
                break;
            case -1:
                Animator.SetBool("BreakBoard2", true);
                Animator.SetBool("BreakBoard1", false);
                Animator.SetBool("RepairBoard2", false);
                NextBoard--;
                BreakBoard.Play();
                //Debug.Log(NextBoard);
                break;
            case -2:
                Animator.SetBool("BreakBoard3", true);
                Animator.SetBool("BreakBoard2", false);
                Animator.SetBool("RepairBoard3", false);
                NextBoard--;
                BreakBoard.Play();
                //Debug.Log(NextBoard);
                break;
            case -3:
                Animator.SetBool("BreakBoard4", true);
                Animator.SetBool("BreakBoard3", false);
                Animator.SetBool("RepairBoard4", false);
                NextBoard--;
                BreakBoard.Play();
                //Debug.Log(NextBoard);
                break;
            case -4:
                Animator.SetBool("BreakBoard5", true);
                Animator.SetBool("BreakBoard4", false);
                Animator.SetBool("RepairBoard5", false);
                BoardMaster.enabled = false;
                //Debug.Log("Disabling obstacle");
                NextBoard--;
                BreakBoard.Play();
                //Debug.Log(NextBoard);
                break;
        }

    }

    IEnumerator Repair()
    {
        WaitedForBoard = false;
        yield return new WaitForSeconds(1f);
        WaitedForBoard = true;
        switch (NextBoard)
        {
            case -5:
                GameObject.FindWithTag("Game Manager").GetComponent<Score>().score += 50;
                RepairBoard.Play();
                RepairBoardMons.Play();
                Animator.SetBool("RepairBoard5", true);
                Animator.SetBool("BreakBoard5", false);
                Animator.SetBool("BreakBoard5", false);
                BoardMaster.enabled = true;
                NextBoard++;
                //Debug.Log(NextBoard);
                break;
            case -4:
                GameObject.FindWithTag("Game Manager").GetComponent<Score>().score += 50;
                RepairBoard.Play();
                RepairBoardMons.Play();
                Animator.SetBool("RepairBoard4", true);
                Animator.SetBool("BreakBoard4", false);
                Animator.SetBool("RepairBoard5", false);
                BoardMaster.enabled = true;
                NextBoard++;
                //Debug.Log(NextBoard);
                break;
            case -3:
                GameObject.FindWithTag("Game Manager").GetComponent<Score>().score += 50;
                RepairBoard.Play();
                RepairBoardMons.Play();
                Animator.SetBool("RepairBoard3", true);
                Animator.SetBool("BreakBoard3", false);
                Animator.SetBool("RepairBoard4", false);
                BoardMaster.enabled = true;
                NextBoard++;
                //Debug.Log(NextBoard);
                break;
            case -2:
                GameObject.FindWithTag("Game Manager").GetComponent<Score>().score += 50;
                RepairBoard.Play();
                RepairBoardMons.Play();
                Animator.SetBool("RepairBoard2", true);
                Animator.SetBool("BreakBoard2", false);
                Animator.SetBool("RepairBoard3", false);
                BoardMaster.enabled = true;
                NextBoard++;
                //Debug.Log(NextBoard);
                break;
            case -1:
                GameObject.FindWithTag("Game Manager").GetComponent<Score>().score += 50;
                RepairBoard.Play();
                RepairBoardMons.Play();
                Animator.SetBool("RepairBoard1", true);
                Animator.SetBool("BreakBoard1", false);
                Animator.SetBool("RepairBoard2", false);
                BoardMaster.enabled = true;
                NextBoard++;
                //Debug.Log(NextBoard);
                break;
        }

    }


}
