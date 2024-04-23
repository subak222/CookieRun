using UnityEngine;
using UnityEngine.UI;

public class Point : MonoBehaviour
{
    [SerializeField]
    private Slider hp;
    [SerializeField]
    private Text score;
    [SerializeField]
    private Text coin;

    public float decreaseRate = 0.02f;

    private void Start()
    {
        // �����̴��� ���� 1�� �ʱ�ȭ
        hp.value = 1f;
        // 1�ʸ��� DecreaseSlider �Լ��� ȣ��
        InvokeRepeating("DecreaseSlider", 0f, 1f);
    }

    private void DecreaseSlider()
    {
        // �����̴��� ���� ���ҽ�Ŵ
        hp.value -= decreaseRate;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // �浹�� ������Ʈ�� ���̾� �̸��� ������
        string layerName = LayerMask.LayerToName(other.gameObject.layer);

        // �浹�� ������Ʈ�� player ������Ʈ���� ���̾ ��ġ�ϴ��� Ȯ��
        switch (layerName)
        {
            case "Jelly":
                AddScore(385, other);
                break;
            case "YellowBear":
                AddScore(2600, other);
                break;
            case "PinkBear":
                AddScore(4680, other);
                break;
            case "Sliver":
                AddScore(260, other);
                AddCoin(1);
                break;
            case "SmallGold":
                AddScore(1000, other);
                AddCoin(10);
                break;
            case "BigGold":
                AddScore(5590, other);
                AddCoin(100);
                break;
            case "obstacle":
                hp.value -= 0.05f;
                break;
            case "bigHeart":
                hp.value += 0.3f;
                Destroy(other.gameObject);
                break;
            case "smallHeart":
                Debug.Log("df");
                hp.value += 0.1f;
                Destroy(other.gameObject);
                break;
        }
    }

    // ������ �߰��ϴ� �Լ�
    private void AddScore(int points, Collider2D other)
    {
        // ���� ������ �����ͼ� �߰��� ������ ���ϰ�, �ؽ�Ʈ�� ������Ʈ
        int currentScore = int.Parse(score.text);
        int newScore = currentScore + points;
        score.text = newScore.ToString();

        // �浹�� ������Ʈ ����
        Destroy(other.gameObject);
    }

    private void AddCoin(int coins)
    {
        int currentCoin = int.Parse(coin.text);
        int newCoin = currentCoin + coins;
        coin.text = newCoin.ToString();
    }
}
