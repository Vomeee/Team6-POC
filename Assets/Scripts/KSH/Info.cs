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
스트링 이넘 인트 ????



카메라 타겟 
스킬발사위치 
무기충돌체 위티
 */