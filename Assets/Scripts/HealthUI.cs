using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField]
    private Image hearthPrefab;

    [SerializeField]
    private Transform heartsContainter;

    private List<Image> hearts = new();

    [ContextMenu(nameof(TestSetHearts))]
    private void TestSetHearts()
    {
        SetHearts(3);
    }

    public void SetHearts(int count)
    {
        for (int i = 0; i < count; i++)
        {
            var newHeart = Instantiate(hearthPrefab, heartsContainter);
            hearts.Add(newHeart);
        }
    }

    [ContextMenu(nameof(AddHearth))]
    public void AddHearth()
    {
        var newHeart = Instantiate(hearthPrefab, heartsContainter);
        hearts.Add(newHeart);
    }

    [ContextMenu(nameof(RemoveHearth))]
    public void RemoveHearth()
    {
        if (hearts.Count <= 0)
        {
            return;
        }

        Destroy(hearts[0].gameObject);
        hearts.RemoveAt(0);
    }
}
