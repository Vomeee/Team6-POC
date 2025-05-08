using System.Linq;
using Unity.VisualScripting;
using UnityEngine;


public enum TagName { ActStart, CameraTarget }
public class Info : MonoBehaviour
{
    public TagName tag;
    

    public static GameObject FindInChildren(GameObject target, TagName name) 
    {
      var infos =  target.GetComponentsInChildren<Info>().ToList();

        for (int i = 0; i < infos.Count; i++) 
        {
            if(infos[i].tag == name)
                return infos[i].gameObject;
        }

        return null;
    }
}
/*
    public List<int> id;
��Ʈ�� �̳� ��Ʈ ????



ī�޶� Ÿ�� 
��ų�߻���ġ 
�����浹ü ��Ƽ
 */