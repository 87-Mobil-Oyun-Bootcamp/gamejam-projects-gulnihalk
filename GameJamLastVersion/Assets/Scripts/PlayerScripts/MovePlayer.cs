using TMPro;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    #region Variables

    [SerializeField] private Animator myAnimationController;
    [SerializeField] public float forwardSpeed;
    [SerializeField] float maxLimit;
    [SerializeField] float minLimit;
    [SerializeField] Canvas canvas;
    [SerializeField] FishCountUI fishCountUI;
    public Animator playerAnim;
    public static MovePlayer Instance;
    public System.Action Finished;
    TextMeshProUGUI[] textArray;
    bool canMove;

    #endregion

    #region Monobehaviour Callbacks

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (!canMove && Input.GetMouseButtonDown(0))
            canMove = true;
        

        Running();
    }
    #endregion

    #region Other Methods
    void Running()
    {
        if (canMove)
        {
            transform.Translate(transform.forward * forwardSpeed * Time.deltaTime, Space.World);
            myAnimationController.SetBool("isStart", true);
        }
    }

    public void Turn(float movementValue)
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x + movementValue, minLimit, maxLimit), transform.position.y, transform.position.z);
    }
    #endregion

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            myAnimationController.SetBool("isEnd", true);
            forwardSpeed = 0;
            canvas.gameObject.SetActive(true);
            Finished?.Invoke();

            textArray = canvas.GetComponentsInChildren<TextMeshProUGUI>();
            foreach (TextMeshProUGUI text in textArray)
            {
                if (text.tag == "theOne")
                {
                    text.SetText(fishCountUI.fishCount.ToString());
                }
            }
        }
    }
}
