using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using YG;

public class CreateObject : MonoBehaviour
{
    [Range(0, 1)] public float value;

    public float delayTime = 1f;
    public List<GameObject> _objToSpawn;

    [SerializeField] private Transform _parentLine;
    [SerializeField] private Transform _parentObj;
    [SerializeField] private AudioSource _click;

    private GameObject _obj;
    private List<Transform> _line;
    private float _startTime;

    private void Awake()
    {
        value = 0;
        _line = new List<Transform>();
        _parentLine.GetComponentsInChildren<Transform>(_line);

        CreatObj();
        StartCoroutine(PlusValue());
    }

    private void Start()
    {
        YandexGame.FullscreenShow();
    }

    private void Update()
    {
        if (Time.time - _startTime < delayTime) return;

        if (EventSystem.current.IsPointerOverGameObject()) return;

        if (Input.GetMouseButtonDown(0))
        {
            _click.pitch = Random.Range(0.9f, 1.1f);
            _click.Play();

            var doMerge = _obj.GetComponent<MergeSystem>();
            doMerge.doMerge = true;

            _obj.AddComponent<Rigidbody2D>();
            _obj.GetComponent<PolygonCollider2D>().isTrigger = false;

            CreatObj();

            _startTime = Time.time;
        }
    }

    private void CreatObj()
    {
        int rndObj = Random.Range(0, _objToSpawn.Count);

        _obj = Instantiate(_objToSpawn[rndObj], new Vector2(5, 5), Quaternion.identity);
        _obj.transform.SetParent(_parentObj);
        _obj.GetComponent<PolygonCollider2D>().isTrigger = true;

        var doMerge = _obj.GetComponent<MergeSystem>();
        doMerge.doMerge = false;
    }

    private IEnumerator PlusValue()
    {
        while (value <= 1)
        {
            yield return new WaitForSeconds(0.01f);
            value += 0.01f;

            Move();
        }
        StartCoroutine(MinusValue());
    }

    private IEnumerator MinusValue()
    {
        while (value >= 0)
        {
            yield return new WaitForSeconds(0.01f);
            value -= 0.01f;

            Move();
        }
        StartCoroutine(PlusValue());
    }

    private void Move()
    {
        _obj.transform.position = Vector3.Lerp(_line[1].position, _line[2].position, value);
        _obj.transform.Rotate(Vector3.forward);
        //Debug.DrawLine(_line[1].position, _line[2].position, Color.grey, 0.01f);
    }
}
