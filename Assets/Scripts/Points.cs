using System.Collections.Generic;
using TMPro;
using UnityEngine;
using YG;

public class Points : MonoBehaviour
{
    public int point;
    public int topPoints;

    [SerializeField] private AudioSource _mergeSound;
    [SerializeField] private TextMeshProUGUI _pointsText;
    [SerializeField] private TextMeshProUGUI _topPointsText;
    [SerializeField] private CreateObject _creatScript;
    [SerializeField] private List<GameObject> _goToAddSpawn;

    private List<MergeSystem> fruit;
    private int count;

    void Start()
    {
        count = 0;
        point = 0;
        topPoints = PlayerPrefs.GetInt("TOP");
        _topPointsText.text = $"рно {topPoints}";

        fruit = new List<MergeSystem>();
    }

    void Update()
    {
        GetComponentsInChildren<MergeSystem>(fruit);
        foreach (MergeSystem mergeSystem in fruit)
        {
            mergeSystem.callback = o => AddPoint(o);
        }
    }

    private void AddPoint(string tags)
    {
        switch (tags)
        {
            case "Cherry_Black":
                point += 1;
                if (count == 0)
                    AddNewFruit(count);
                break;

            case "Cranberry":
                point += 2;
                if (count == 1)
                    AddNewFruit(count);
                break;

            case "Cucumber":
                point += 3;
                if (count == 2)
                    AddNewFruit(count);
                break;

            case "Plum":
                point += 4;
                if (count == 3)
                    AddNewFruit(count);
                break;

            case "Dragonfruit":
                point += 5;
                if (count == 4)
                    AddNewFruit(count);
                break;

            case "Durian":
                point += 6;
                if (count == 5)
                    AddNewFruit(count);
                break;

            case "Fig":
                point += 7;
                if (count == 6)
                    AddNewFruit(count);
                break;

            case "Grapes":
                point += 8;
                if (count == 7)
                    AddNewFruit(count);
                break;

            case "Grapefruit":
                point += 9;
                if (count == 8)
                    AddNewFruit(count);
                break;

            case "Kiwi":
                point += 10;
                if (count == 9)
                    AddNewFruit(count);
                break;

            case "Lemon":
                point += 11;
                if (count == 10)
                    AddNewFruit(count);
                break;

            case "Apple":
                point += 12;
                if (count == 11)
                    AddNewFruit(count);
                break;

            case "Orange":
                point += 13;
                if (count == 12)
                    AddNewFruit(count);
                break;

            case "Pear":
                point += 14;
                if (count == 13)
                    AddNewFruit(count);
                break;

            case "Peach":
                point += 15;
                if (count == 14)
                    AddNewFruit(count);
                break;

            case "Apricot":
                point += 16;
                if (count == 15)
                    AddNewFruit(count);
                break;

            case "Strawberry":
                point += 17;
                if (count == 16)
                    AddNewFruit(count);
                break;

            case "Watermelon":
                point += 18;
                if (count == 17)
                    AddNewFruit(count);
                break;

            case "Melon":
                point += 19;
                if (count == 18)
                    AddNewFruit(count);
                break;

            default:
                point += 50;
                break;
        }

        _pointsText.text = point.ToString();
        _mergeSound.pitch = Random.Range(0.9f, 1.1f);
        _mergeSound.Play();

        if (point < topPoints) return;

        topPoints = point;
        _topPointsText.text = $"рно {topPoints}";

        PlayerPrefs.SetInt("TOP", topPoints);
        YandexGame.NewLeaderboardScores("LeaderboardScore", topPoints);
    }

    private void AddNewFruit(int numFruit)
    {
        if (count > _goToAddSpawn.Count) return;

        _creatScript._objToSpawn.Add(_goToAddSpawn[count]);
        numFruit++;
        count = numFruit;
    }
}
