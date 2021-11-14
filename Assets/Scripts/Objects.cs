using System.Collections.Generic;
using UnityEngine;

public class Objects : MonoBehaviour
{
    public static List<Moving> isMoves = new List<Moving>();//移動してる動物がいないかチェックするリスト

    Rigidbody2D rigid;
    Moving moving = new Moving();//移動チェック変数

    /// <summary>
    /// リストに追加&Rigidbody2D取得
    /// </summary>
    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        isMoves.Add(moving);
    }

    /// <summary>
    /// 固定フレームレートで移動チェック
    /// </summary>
    void FixedUpdate()
    {
        if (moving.isFalling)
        {
            if (rigid.IsSleeping())
            {
                moving.isMove = false;
                moving.isFalling = false;
            }
            else
            {
                moving.isMove = true;
            }
        }
    }
}

/// <summary>
/// 移動チェッククラス
///
/// 理由：bool型をリストで渡すと値として認識されてしまった。
/// 苦肉の策として、参照してもらうためにクラスを作りました。
/// いい方法があれば教えてもらえると助かります……
/// </summary>
public class Moving
{
    public bool isMove;
    public bool isFalling = false;
}
