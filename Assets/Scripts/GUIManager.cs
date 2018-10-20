using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections;
using System.Collections.Generic;


public class GUIManager : MonoBehaviour
{
    public GameObject laserIconTemplate;

    private Text score;
    private Text hint;
    private Button exitButton;
    private Button againButton;
    private List<GameObject> laserIcons;

    void Start()
    {
        score = GameObject.Find("Score").GetComponent<Text>();
        hint = GameObject.Find("Hint").GetComponent<Text>();
        exitButton = GameObject.Find("ExitButton").GetComponent<Button>();
        againButton = GameObject.Find("AgainButton").GetComponent<Button>();       
        laserIcons = new List<GameObject>();

        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        againButton.onClick.AddListener(gameManager.StartGame);
        exitButton.onClick.AddListener(Application.Quit);
    }

    public void UpdateScore(int score)
    {
        this.score.text = score.ToString();
    }

    public void GameOver(int finalScore)
    {
        laserIcons.ForEach(x => x.SetActive(false));

        againButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
        score.text = string.Format("Игра окончена! Ваш счёт: {0}", finalScore);
    }

    public void StartGame()
    {
        againButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
        hint.gameObject.SetActive(false);
    }

    public void OnLaserChargesCountChanged(int count)
    {
        while (count > laserIcons.Count)
        {
            GameObject next = Instantiate(laserIconTemplate);
            next.transform.SetParent(transform);
            if (laserIcons.Count > 0)
            {
                Vector3 lastPosition = laserIcons.Last().transform.localPosition;
                next.transform.localPosition = new Vector3(lastPosition.x + 12.5f, lastPosition.y, 0f);
            }
            else
            {
                next.transform.position = new Vector3(25f, 25f, 0f);
                Vector3 local = next.transform.localPosition;
                next.transform.localPosition = new Vector3(local.x, local.y, 0f);
            }
            laserIcons.Add(next);
        }
        for (int i = 0; i < count; i++)
            laserIcons[i].SetActive(true);
        for (int i = count; i < laserIcons.Count; i++)
            laserIcons[i].SetActive(false);
    }

    public void ShowHint(string hint)
    {
        IEnumerator coroutine = Hint(hint);
        StartCoroutine(coroutine);
    }

    private IEnumerator Hint(string message)
    {
        yield return new WaitForSeconds(1f);
        hint.text = message;
        hint.gameObject.SetActive(true);
        Color color = hint.color;
        color.a = 0.0f;
        for (int i = 0; i < 5; i++)
        {
            color.a += 0.2f;
            yield return new WaitForSeconds(0.1f);
            hint.color = color;
        }
        yield return new WaitForSeconds(1.5f);
        for (int i = 0; i < 5; i++)
        {
            color.a -= 0.2f;
            yield return new WaitForSeconds(0.1f);
            hint.color = color;
        }
        hint.gameObject.SetActive(false); 
    }
}
