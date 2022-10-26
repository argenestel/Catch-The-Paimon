using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerHitController : MonoBehaviour
{
    [SerializeField]
    private Camera arCamera;

    public TextMeshProUGUI _score;
    public int _counter;
    public int Level;
    public TextMeshProUGUI LevelText;
    private ParticleSystem _poppedParticles;

    public delegate void OnLevelChange();
    public static event OnLevelChange OnLevelChangeEvent;


    private void OnEnable()
    {
        SceneHandler.OnRestartEvent += RestartingGame;
    }
    private void OnDisable()
    {
        SceneHandler.OnRestartEvent -= RestartingGame;
    }

    private void RestartingGame()
    {
        Destroy(GameObject.FindGameObjectWithTag("Spawn"));
        _counter = 0;
        Level = 0;
    }
    void Start()
    {
        _counter = 0;
        Level = 0;
    }
    private void Update()
    {
        /*if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    _counter++;
                    Destroy(hit.collider.gameObject);
                    _poppedParticles = hit.collider.gameObject.GetComponentInChildren<ParticleSystem>();
                    _poppedParticles.Play(); 
                    _score.text = "Score: " + _counter;
                }
            }
        }*/

#if UNITY_EDITOR

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = arCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    _counter++;
                    Destroy(hit.collider.gameObject);
                    _poppedParticles = hit.collider.gameObject.GetComponentInChildren<ParticleSystem>();
                    _poppedParticles.Play();
                    _score.text = "Score: " + _counter;
                    LevelText.text = "Level: " + Level.ToString();
                }
            }
        }
#endif
    }

    public void Catch()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null)
            {
                _counter++;
                Destroy(hit.collider.gameObject);
                _poppedParticles = hit.collider.gameObject.GetComponentInChildren<ParticleSystem>();
                _poppedParticles.Play();
                _score.text = "Score: " + _counter;
                LevelChanger();
                LevelText.text = "Level: " +Level.ToString();
            }
        }
    }
    public void LevelChanger()
    {
        if (_counter % 5 == 0)
        {
            Level++;
            if (OnLevelChangeEvent != null)
            {
                OnLevelChangeEvent();
            }
        }
    }
}
