using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HuskyJumpscare : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private Sprite[] huskies;
    [SerializeField]
    private Image huskyRenderer;
    [SerializeField]
    private RectTransform[] targetBoundaries;
    [SerializeField]
    private RectTransform[] targets;
    private int targetNum = 3;
    [SerializeField]
    private GameObject canvas;
    [SerializeField]
    private BoxCollider2D playerBlock;
    [SerializeField]
    private float destroyTimer;
    [SerializeField]
    private float targetRadius;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private string openAnim;
    [SerializeField]
    private string closeAnim;
    private bool active;
    [SerializeField]
    private GameObject shootPrefab;
    #endregion

    private void Start()
    {
        ToggleHusky(true);
        GenerateHusky();
        ToggleHusky(false);
    }

    private void Update()
    {
        if (active && Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject a = Instantiate(shootPrefab, canvas.transform);
            a.GetComponent<RectTransform>().position = Input.mousePosition;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            ToggleHusky(true);
            Animations.instance.PlayAnimation(animator, openAnim);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            ToggleHusky(false);
            Animations.instance.PlayAnimation(animator, closeAnim);
        }
    }

    private void ToggleHusky(bool showing)
    {
        canvas.SetActive(showing);
        active = showing;
    }

    private void GenerateHusky()
    {
        huskyRenderer.sprite = huskies[Random.Range(0, huskies.Length)];

        int count = 0;
        int count2 = 0;

        while(count < targets.Length)
        {
            float x = Random.Range(targetBoundaries[0].position.x, targetBoundaries[1].position.x);
            float y = Random.Range(targetBoundaries[0].position.y, targetBoundaries[1].position.y);
            targets[count].position = new Vector3(x, y, 0);

            for (int i = 0; i < 3; i++)
            {
                if ((targets[count].position - targets[i].position).magnitude > targetRadius * 2 && count != i)
                {
                    count++;
                    break;
                }
            }

            if (count2 > 1000)
            {
                Debug.Log("gg");
                break;
            }
            count2++;
        }
    }

    public void TargetHit()
    {
        targetNum--;
        if(targetNum == 0)
        {
            StartCoroutine(KnockedDown());
        }
    }

    private IEnumerator KnockedDown()
    {
        yield return new WaitForSeconds(destroyTimer);
        Destroy(canvas);
        Destroy(this);
        Destroy(playerBlock);
    }
}
