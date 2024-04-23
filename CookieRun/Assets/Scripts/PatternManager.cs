using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternManager : MonoBehaviour
{
    private List<GameObject> availablePatterns = new List<GameObject>();
    private List<GameObject> usedPatterns = new List<GameObject>();

    public GameObject StartPattern;
    public List<GameObject> patternList = new List<GameObject>();

    public float Speed = 0.0f;
    public float delayTime = 0.0f;
    public float posX = 0.0f;

    private void Start()
    {
        availablePatterns.AddRange(patternList);
        StartCoroutine("CreatePattern");
    }

    IEnumerator CreatePattern()
    {
        GameObject s_pattern = Instantiate(StartPattern, new Vector2(0.0f, 0.0f), Quaternion.identity);
        s_pattern.GetComponent<Pattern>().Init(Speed);

        while (!GameManager.instance.gameOver)
        {
            // ������ ��� ���Ǹ� �ٽ� �ʱ�ȭ
            if (availablePatterns.Count == 0)
                availablePatterns.AddRange(usedPatterns);

            // ��� ������ ���� �߿��� �����ϰ� ����
            int index = Random.Range(0, availablePatterns.Count);
            GameObject selectedPattern = availablePatterns[index];

            // ���õ� ������ ����� ������� �̵��ϰ� ��� ������ ��Ͽ��� ����
            usedPatterns.Add(selectedPattern);
            availablePatterns.RemoveAt(index);

            // ������ �����ϰ� �ʱ�ȭ
            GameObject t_pattern = Instantiate(selectedPattern, new Vector2(posX, 0.0f), Quaternion.identity);
            t_pattern.GetComponent<Pattern>().Init(Speed);

            yield return new WaitForSeconds(delayTime);
        }
    }
}
