using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class change : MonoBehaviour
{
    private Color startColor;
    private Color endColor;
    public GameObject cube;
    private Material mat;
 
    private float t;

    private bool order;
 
    MeshRenderer cubeMeshRenderer;
 
    // Start is called before the first frame update
    void Start()
    {
        cubeMeshRenderer = this.gameObject.GetComponent<MeshRenderer>();
        startColor = Color.green;
        endColor = Color.red;
        if(cubeMeshRenderer.material.name == "default (Instance)"){
            order = true;
        }else{
            order = false;
        }
// //         対象のシェーダー情報を取得
//         Shader sh = this.gameObject.GetComponent<MeshRenderer>().material.shader;
//         //取得したシェーダーを元に新しいマテリアルを作成
//         mat = new Material(sh);
    }

    // Update is called once per frame
    void Update()
    {
        float distance = (cube.transform.position - this.transform.position).magnitude;
        // Debug.Log(this.gameObject + " " + distance);
//         Debug.Log(this.gameObject + "TransformPoint:" + cube.transform.TransformPoint (this.transform.localPosition));
        if(order == true){
            if(distance < 0.6f){
                startColor = Color.red;
                endColor = Color.yellow;
                if(distance <= 0.3f){
                    t = 0;
                }else{
                    t = (distance - 0.3f)/0.6f;
                }
            }else if(0.6f <= distance){
                startColor = Color.yellow;
                endColor = Color.green;
                if(distance <= 1.7f){
                    t = distance - 0.6f;
                }else{
                    t = 1;
                }
            }
        }
        
        // mat.color = Color.Lerp(startColor, endColor, t);
        // this.gameObject.GetComponent<MeshRenderer>().material = mat;
        cubeMeshRenderer.material.SetColor("_Color", Color.Lerp(startColor, endColor, t));
    }
}