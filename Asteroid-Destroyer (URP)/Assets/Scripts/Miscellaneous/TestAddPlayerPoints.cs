using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestAddPlayerPoints : MonoBehaviour
{
    public void AddPlayerPointsButton() => PlayerPoints.Instance.AddPlayerPoints(100);

    public void DeleteAllPlayerPrefsData() => PlayerPrefs.DeleteAll();
}
