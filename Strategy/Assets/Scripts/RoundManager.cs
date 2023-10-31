using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    #region Singleton
    private static RoundManager instance;
    public static RoundManager GetInstance()
    {
        if (instance == null)
        {
            instance = new RoundManager();
        }

        return instance;
    }
    #endregion
    [Header("Менеджеры")]

    [Header("Параметры раундменеджера")]
    [SerializeField] private int _roundNumber = 0;
    [SerializeField] private PlayerNumber _playerMove = PlayerNumber.First;

    [Header("Списки юнитов")]
    [SerializeField] private List<GameObject> TheQueueOfCharacters = new List<GameObject>();
    [SerializeField] private List<GameObject> FirstTeam = new List<GameObject>();
    [SerializeField] private List<GameObject> SecondTeam = new List<GameObject>();
    
    [Header("Клетки для стартовой позиции юнитов")]
    [SerializeField] private List<GameObject> FirstPlayerUnitsPosition = new List<GameObject>();
    [SerializeField] private List<GameObject> SecondPlayerUnitsPosition = new List<GameObject>();
    
    [Header("Для взаимодействия с активным юнитом")]
    [SerializeField] private GameObject _unit;
    [SerializeField] private bool _changingTheTarget = false;

    public IEnumerator StartRoundManager()
    {
        Debug.Log("Корутина менеджера запустилась");

        int i = 0;
        while (true)
        {
            if (_changingTheTarget) {
                GetComponent<GameManager>().TransferOfTheRoundManagerUnit(TheQueueOfCharacters[i]);
                if (i != TheQueueOfCharacters.Count)
                    i++;
                else
                {
                    SortingUnitsDuringTheGame();
                    i = 0;
                }

            }
            yield return null;
        }
    }

    #region Sorting method
    public void SortingUnitsDuringTheGame() //сортировка для юнитов во время игры
    {
        RemoveNullElements(FirstTeam);
        RemoveNullElements(SecondTeam);

        for (int i = 0;i <= FirstTeam.Count;i++)
        {
            //Доп проверки, надо решить - нужно ли их оставить
            if (FirstTeam[i] != null)
                FirstTeam[i].GetComponent<BaseUnit>().ReturnBaseScorePoint();
            else
                FirstTeam.RemoveAt(i);
        }
        for (int i = 0; i <= SecondTeam.Count; i++)
        {
            if (SecondTeam[i] != null)
                SecondTeam[i].GetComponent<BaseUnit>().ReturnBaseScorePoint();
            else
                SecondTeam.RemoveAt(i);
        }
        TheQueueOfCharacters.Clear();
        

        TheQueueOfCharacters = Sorting(FirstTeam, SecondTeam);
    }
    public void SortingUnitsAtTheStart(Player FirstPlayer, Player SecondPlayer,out Coroutine RoundManagerCorutine)
    {
        FirstTeam = FirstPlayer.GetUnits;
        FirstTeam.Sort((a,b) => b.GetComponent<BaseUnit>().GetSetScorePoint.CompareTo(a.GetComponent<BaseUnit>().GetSetScorePoint));
        SecondTeam = SecondPlayer.GetUnits;
        SecondTeam.Sort((a, b) => b.GetComponent<BaseUnit>().GetSetScorePoint.CompareTo(a.GetComponent<BaseUnit>().GetSetScorePoint));
        
        TheQueueOfCharacters = Sorting(FirstTeam,SecondTeam);
        RoundManagerCorutine = StartCoroutine(StartRoundManager());
    }

    private List<GameObject> Sorting(List<GameObject> FirstTeam,List<GameObject> SecondTeam)
    {
        Debug.Log("Сортировка началась!");
        List<GameObject> CompletedList = new List<GameObject>(FirstTeam.Count+SecondTeam.Count);

        if (FirstTeam.Count == SecondTeam.Count)
        {
            for (int i = 1; i <= CompletedList.Count; i++)
            {
                CompletedList.Add(FirstTeam[0]);
                int j = 1;
                int k = 0;
                if (CompletedList[i - 1].GetComponent<BaseUnit>().GetSetUnitNumber == PlayerNumber.First)
                {
                    CompletedList.Add(SecondTeam[k]);
                    k++;
                }
                else
                {
                    CompletedList.Add(FirstTeam[j]);
                    j++;
                }
            }
        }
        else
        {
            for (int i = 1; i <= CompletedList.Count; i++)
            {
                CompletedList.Add(FirstTeam[0]);
                int j = 1;
                int k = 0;
                if (FirstTeam.Count != SecondTeam.Count) {
                    if (CompletedList[i - 1].GetComponent<BaseUnit>().GetSetUnitNumber == PlayerNumber.First && k <= SecondTeam.Count)
                    {
                        CompletedList.Add(SecondTeam[k]);
                        k++;
                    }
                    else if (CompletedList[i - 1].GetComponent<BaseUnit>().GetSetUnitNumber == PlayerNumber.First || CompletedList[i - 1].GetComponent<BaseUnit>().GetSetUnitNumber == PlayerNumber.Second && k > SecondTeam.Count)
                    {
                        CompletedList.Add(FirstTeam[j]);
                        j++;
                    }
                    else if(CompletedList[i - 1].GetComponent<BaseUnit>().GetSetUnitNumber == PlayerNumber.Second && j <= FirstTeam.Count)
                    {
                        CompletedList.Add(FirstTeam[j]);
                        j++;
                    }else if (CompletedList[i - 1].GetComponent<BaseUnit>().GetSetUnitNumber == PlayerNumber.Second || CompletedList[i - 1].GetComponent<BaseUnit>().GetSetUnitNumber == PlayerNumber.First && j > FirstTeam.Count)
                    {
                        CompletedList.Add(SecondTeam[k]);
                        k++;
                    }
                }
            }
        }
        Debug.Log("Сортировка завершена!");
        return CompletedList;
    }
    private void RemoveNullElements(List<GameObject> List)
    {
        List.RemoveAll(element => element == null);
    }
    #endregion
    #region Methods of interaction in the game

    private void SelectedStartPositionsUnits()
    {

    }

    #endregion
    #region Getters and Setters
    public List<GameObject> GetFirstPlayerUnitsPosition
    {
        get { return FirstPlayerUnitsPosition; }
        set { FirstPlayerUnitsPosition = value; }
    }
    public List<GameObject> GetSecondPlayerUnitsPosition
    {
        get { return SecondPlayerUnitsPosition; }
        set { SecondPlayerUnitsPosition = value; }
    }
    public bool SetChangingTheTaget
    {
        set { _changingTheTarget = value; }
    }
    #endregion
}
