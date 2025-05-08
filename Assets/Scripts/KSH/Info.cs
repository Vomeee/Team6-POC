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
스트링 이넘 인트 ????



카메라 타겟 
스킬발사위치 
무기충돌체 위티
 */