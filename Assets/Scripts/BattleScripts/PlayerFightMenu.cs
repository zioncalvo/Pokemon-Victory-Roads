using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerFightMenu : MonoBehaviour
{

    public delegate void MoveHandler(float x, float y);
    public event MoveHandler PerformPlayerMove;


    public GameObject fightMenu;
    [SerializeField] GameObject actionMenu;
    [SerializeField] GameObject moveSelector;
    [SerializeField] TextMeshProUGUI moveType;
    [SerializeField] TextMeshProUGUI currentMovePP;
    [SerializeField] TextMeshProUGUI maxMovePP;
    [SerializeField] DialogueBox whatHappenedText;

    public float x = 0f;
    public float y = 0f;

    [SerializeField] List<TextMeshProUGUI> moveText;
    public List<Move> playerMoves = new List<Move>();

    public BattleUnit playerUnit;

    void Start()
    {
        SetMoveNames(playerUnit.Pokemon.Moves);
        moveSelector.gameObject.transform.position = new Vector3(110, 220, 0);
    }

    void Update()
    {
        fightMenuSelection();
    }

    public void fightMenuSelection()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            x = 0f;
            y = 0f;
            setMoveInformation();
            fightMenu.gameObject.SetActive(false);
            actionMenu.gameObject.SetActive(true);
        }

        //player move 2->4
        if(Input.GetKeyDown(KeyCode.DownArrow) && y < 1f && playerMoves.Count == 4f && x == 1 && y + 1 == 1)
        {
            y++;
            setMoveInformation();
        }

        //player move 1->3
        if(Input.GetKeyDown(KeyCode.DownArrow) && y < 1f && playerMoves.Count >= 3f && x == 0 && y + 1 == 1)
        {
            y++;
            setMoveInformation();
        }

        if(Input.GetKeyDown(KeyCode.UpArrow) && y == 1f)
        {
            y--;
            setMoveInformation();
        }

        //player move 1 -> 2
        if(Input.GetKeyDown(KeyCode.RightArrow) && x < 1f && playerMoves.Count >= 2f && x + 1 == 1 && y == 0)
        {
            x++;
            setMoveInformation();
        }

        //player move 3 -> 4
        if(Input.GetKeyDown(KeyCode.RightArrow) && x < 1f && playerMoves.Count >= 4f && x + 1 == 1 && y == 1)
        {
            x++;
            setMoveInformation();
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow) && x == 1f)
        {
            x--;
            setMoveInformation();
        }

        // Move 1
        if(x == 0f && y == 0f)
        {
            moveSelector.transform.position = new Vector3(110f, 220f, 0f);
        }
        // Move 2
        if(x == 1f && y == 0f)
        {
            moveSelector.transform.position = new Vector3  (740f, 220f, 0f);
        }
        // Move 3
        if(x == 0f && y == 1f)
        {
            moveSelector.transform.position = new Vector3  (110f, 90f, 0f);
        }
        // Move 4
        if(x == 1f && y == 1f)
        {
            moveSelector.transform.position = new Vector3  (740f, 90f, 0f);
        }

        if(Input.GetKeyDown(KeyCode.Z))
        {
            PerformPlayerMove(x, y);
            fightMenu.gameObject.SetActive(false);
        }
    }

    public void SetMoveNames(List<Move> moves)
    {
        playerMoves = moves;
        setMoveInformation();
        for(int i = 0; i < moveText.Count; i++)
        {
            if(i < moves.Count)
            {
                moveText[i].text = moves[i].Base.Name;
            }
            else
            {
                moveText[i].text = " - " ;
            }
        }
    }

    public void setMoveInformation()
    {
        // Make sure playerMoves isn't empty
        if (playerMoves.Count != 0) 
        {
            // Move 1
            if(x == 0f && y == 0f)
            {
                moveType.text = playerMoves[0].Base.MoveType.ToString();
            }
            // Move 2
            if(x == 1f && y == 0f)
            {
                moveType.text = playerMoves[1].Base.MoveType.ToString();
            }
            // Move 3
            if(x == 0f && y == 1f)
            {
                moveType.text = playerMoves[2].Base.MoveType.ToString();
            }
            // Move 4
            if(x == 1f && y == 1f)
            {
                moveType.text = playerMoves[3].Base.MoveType.ToString();
            }
        }
        
    }    
}
