using System;
using UnityEngine;

public class MergeSystem : MonoBehaviour
{
    public string tagObj;
    public bool doMerge = false;
    public GameObject mergeTo;
    public Action<string> callback;

    [SerializeField] private GameObject _smoke;

    private int _id;

    private void Start()
    {
        _id = GetInstanceID();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (doMerge == false) return;

        if (col.gameObject.CompareTag(tagObj))
        {
            if (_id < col.gameObject.GetComponent<MergeSystem>()._id) return;

            Destroy(col.gameObject);
            Destroy(gameObject);

            var pos = (col.transform.position + gameObject.transform.position) / 2;
            var rot = (col.transform.rotation * gameObject.transform.rotation);

            GameObject _obj = Instantiate(mergeTo, pos, rot);
            GameObject smoke = Instantiate(_smoke, _obj.transform.position, Quaternion.identity);
            smoke.transform.localScale = _obj.transform.localScale;

            string tag = _obj.GetComponent<MergeSystem>()?.tagObj;

            if (tag == null) tag = "EndFruit";

            callback?.Invoke(tag);

            if (tag == "EndFruit") return;

            _obj.transform.SetParent(col.transform.parent);

            _obj.AddComponent<Rigidbody2D>();
            _obj.GetComponent<MergeSystem>().doMerge = true;
        }
    }
}
