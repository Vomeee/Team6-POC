using System.Linq;
using Unity.VisualScripting;
using UnityEngine;


public enum TagName { ActStart, CameraTarget }
public class Info : MonoBehaviour
{
    public TagName id;
    

    public static GameObject FindInChildren(GameObject _go, TagName name) 
    {
      var tags=  _go.GetComponentsInChildren<Info>().ToList();

        for (int i = 0; i < tags.Count; i++) 
        {
            if(tags[i].id == name)
                return tags[i].gameObject;
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