using UnityEngine;

public class AnimHandler : MonoBehaviour
{
    private Animator _animatorCached;

    private void Awake()
    {
        _animatorCached = GetComponent<Animator>();
    }

    private int SelectRandom()
    {
        return Random.Range(0, 3);
    }

    public void TransitAnimation()
    {
        int rand = SelectRandom();
        if (_animatorCached!=null)
        {
            _animatorCached.SetInteger("entryPoint", rand);
        }
    }
}
