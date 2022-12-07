using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShadowController : MonoBehaviour
{
    public List<Sprite> shadows;

    public SpriteRenderer sr;

    private int currentLevel = 1;

    private bool canStartReduceShadow = true;

    public float unhitCoolDown = 5f;

    private FadeInAndOutController _fadeInAndOutController;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        _fadeInAndOutController = FindObjectOfType<FadeInAndOutController>();

    }

    // Update is called once per frame
    private float timer = 0;

    public float Timer
    {
        get => timer;
        set => timer = value;
    }
    void Update()
    {
        if (canStartReduceShadow)
        {
            timer += Time.deltaTime;
            if (timer > unhitCoolDown)
            {
                timer = 0;
                //DecreaseShadow();
            }
        }
    }

    public int CurrentLevel
    {
        get => currentLevel;
        set => currentLevel = value;
    }

    [Button]
    public void IncreaseShadow()
    {
        if (currentLevel+1<shadows.Count)
        {
            canStartReduceShadow = true;
            currentLevel++;
            sr.sprite = shadows[currentLevel];
        }
        else
        {
            _fadeInAndOutController.DoFadeInAndOut();
            StartCoroutine(nameof(ReloadSceneRoutine));
        }
    }

    [Button]
    public void DecreaseShadow()
    {
        if (currentLevel-1>=0)
        {
            if (canStartReduceShadow)
            {
                currentLevel--;
                sr.sprite = shadows[currentLevel];
            }
           
        }
    }

    IEnumerator ReloadSceneRoutine()
    {
        yield return new WaitForSeconds(5f);
        //reload the scene
        SceneManager.LoadScene("ThirdFrame");
    }
}
