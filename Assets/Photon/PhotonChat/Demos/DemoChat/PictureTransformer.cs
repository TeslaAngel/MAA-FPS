using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

using UnityEngine.UI;


public class PictureTransformer : MonoBehaviour
{

    public string ToImageString;
    public string channelTag;
    public Texture2D RP;

    //base64转图片
    public void Base64ToTexture2d(string Base64STR)
    {
        Texture2D pic = new Texture2D(1111, 1111);
        byte[] data = System.Convert.FromBase64String(Base64STR);
        pic.LoadImage(data);
        //byte[] bytes = pic.EncodeToPNG();

        //下面是为了方便了解图片的信息写的
        string year = System.DateTime.Now.Year.ToString();
        string month = System.DateTime.Now.Month.ToString();
        string day = System.DateTime.Now.Day.ToString();
        string hour = System.DateTime.Now.Hour.ToString();
        string minute = System.DateTime.Now.Minute.ToString();
        string secend = System.DateTime.Now.Second.ToString();
        //存储路径
        //string FileFullPath = Application.dataPath/*这是获取assets前的文件路径*/ + "/" + year + "-" + month + "-" + day + "-" + hour + "-" + minute + "-" + secend + ".png";

        //File.WriteAllBytes(FileFullPath, bytes);
        //return FileFullPath;
        RP = pic;
    }


    //图片转base64string
    public string Texture2dToBase64(string texture2d_path)
    {
        //将图片文件转为流文件
        FileStream fs = new System.IO.FileStream(texture2d_path, System.IO.FileMode.Open, System.IO.FileAccess.Read);
        byte[] thebytes = new byte[fs.Length];

        fs.Read(thebytes, 0, (int)fs.Length);
        //转为base64string
        string base64_texture2d = Convert.ToBase64String(thebytes);
        return base64_texture2d;
    }


    // Start is called before the first frame update
    void Start()
    {
        if (ToImageString != null && GetComponent<Image>()!=null)
        {
            //string ffp = Base64ToTexture2d(ToImageString);
            Base64ToTexture2d(ToImageString);
            Sprite sprite = Sprite.Create(RP, new Rect(0, 0, RP.width, RP.height),new Vector2(0.5f, 0.5f),100);
            if (GetComponent<Image>() != null)
                GetComponent<Image>().overrideSprite = sprite;
            else if(GetComponent<RawImage>()!=null)
                GetComponent<RawImage>().texture = RP;
            //GetComponent<Image>().material.mainTexture = RP;

        }

        GameObject[] AImages = GameObject.FindGameObjectsWithTag("NetImage");
        for(int I = 0; I < AImages.Length; I++)
        {
            if (AImages[I] == gameObject)
                return;
            if(AImages[I].GetComponent<PictureTransformer>().channelTag==channelTag && AImages[I].GetComponent<RectTransform>().anchoredPosition.x == GetComponent<RectTransform>().anchoredPosition.x)
            {
                if (Math.Abs(AImages[I].GetComponent<RectTransform>().anchoredPosition.y - GetComponent<RectTransform>().anchoredPosition.y) < 64)
                {
                    GetComponent<RectTransform>().anchoredPosition = new Vector2(AImages[I].GetComponent<RectTransform>().anchoredPosition.x+128, GetComponent<RectTransform>().anchoredPosition.y);
                    print("Move");
                }
            }
        }
    }
    
}
