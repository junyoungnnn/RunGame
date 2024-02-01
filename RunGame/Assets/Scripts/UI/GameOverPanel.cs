using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] Text bestScoreText;

    private void Update()
    {
        bestScoreText.text = DataManager.instance.data.bestScore.ToString() + "m";
    }

    public void Resume()
    {
        StartCoroutine(AsyncSceneLoader.instance.AsyncLoad(SceneID.GAME));

    }

    IEnumerator ViewScore()
    {
        yield return new WaitForSeconds(0.5f);

        bestScoreText.text = DataManager.instance.data.bestScore.ToString() + "m";
    }
}
