using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern : MonoBehaviour
{
    private const float ENDPOSX = -40.0f;
    private float moveSpeed;

    public void Init(float moveSpeed)
    {
        this.moveSpeed = moveSpeed;
    }

    private void Update()
    {
        // ������ �̵���Ŵ
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        // ������ ���� ��ġ(ENDPOSX) ���Ϸ� �̵��ϸ� ������Ʈ�� �ı�
        if (transform.position.x <= ENDPOSX)
        {
            Destroy(gameObject);
        }

        // ���� ���� �� ������ ����
        if (GameManager.instance.gameOver)
        {
            moveSpeed = 0f;
        }
    }
}
