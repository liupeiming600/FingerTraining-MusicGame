using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SonicBloom.Koreo;

public class ButtonEvent : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 endPos;
    public GameObject startCube;
    public GameObject endCube;
    public GameObject[] PreEffect;
    public int PreEffectNum = 0;

    public string eventID;//这个ID要和Tracks轨迹那个名字一致

    private void Start()
    {
        startPos = startCube.transform.position;
        endPos = endCube.transform.position;
        //第一个参数就是注册进那个轨迹，第二个参数就是注册的事件
        Koreographer.Instance.RegisterForEvents(eventID, Onclick);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            nextEffect();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            previousEffect();
        }
    }

    //这个是注册的事件，参数必须要有KoreographyEvent这个类型。
    public void Onclick(KoreographyEvent koreographyEvent)
    {
        GameObject CubeEffect = Instantiate(PreEffect[PreEffectNum]);
        CubeEffect.transform.position = startPos;
        CubeEffect.transform.LookAt(endPos);
        CubeEffect.GetComponent<Rigidbody>().AddForce(CubeEffect.transform.forward * 2000);
    }
    public void nextEffect()
    {
        if (PreEffectNum < PreEffect.Length - 1)
            PreEffectNum++;
        else
            PreEffectNum = 0;
    }

    public void previousEffect()
    {
        if (PreEffectNum > 0)
            PreEffectNum--;
        else
            PreEffectNum = PreEffect.Length - 1;
    }

}
